using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal
{
    public partial class Form9CustomerMain : Form
    {
        // True jika user klik Logout (minta kembali ke Login Form),
        // False jika form ditutup via X (tutup aplikasi).
        public bool LogoutRequested { get; private set; } = false;

        // ID akun customer yang sedang login (dibutuhkan untuk beli tiket & tiket saya).
        public int LoggedInAkunId { get; private set; } = 0;
        private string _loggedInNama = "";

        public Form9CustomerMain()
        {
            InitializeComponent();

            this.picTiket.Click += new System.EventHandler(this.Tiket_Click);
            this.picLogout.Click += new System.EventHandler(this.Logout_Click);
            this.btnCari.Click += new System.EventHandler(this.Cari_Click);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form9CustomerMain_FormClosed);

            // --- Logic Customer Main (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form9CustomerMain_Load);
        }

        /// <summary>
        /// Set user login (kompatibilitas: hanya nama). ID dicoba dikenali dari database.
        /// </summary>
        public void SetLoggedInUser(string nama)
        {
            int id = 0;
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var cocok = db.Akun.Where(a => a.Nama == nama).Select(a => a.ID).ToList();
                    if (cocok.Count == 1)
                        id = cocok[0];
                }
            }
            catch { /* abaikan, ID tetap 0 */ }
            SetLoggedInUser(id, nama);
        }

        /// <summary>
        /// Set user login lengkap (ID + nama). Dipanggil dari form Login.
        /// </summary>
        public void SetLoggedInUser(int akunId, string nama)
        {
            LoggedInAkunId = akunId;
            _loggedInNama = (nama ?? "").Trim();
            lblSapaan.Text = "Mau terbang ke mana hari ini, " + _loggedInNama + "?";
        }

        #region Load & Autocomplete

        private void Form9CustomerMain_Load(object sender, EventArgs e)
        {
            dtpTanggal.MinDate = DateTime.Today;
            // Format tanggal default spek: DD-MM-YYYY.
            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = "dd-MM-yyyy";
            // Bawaan = besok (jadwal hari ini sebagian besar sudah lewat jamnya).
            dtpTanggal.Value = DateTime.Today.AddDays(1);
            numPenumpang.Minimum = 1;
            // Maksimal 3 mengikuti jumlah panel penumpang di form Beli Tiket.
            numPenumpang.Maximum = 3;
            numPenumpang.Value = 1;

            MuatAutoCompleteBandara();
        }

        /// <summary>
        /// Isi saran ketik (autocomplete) kolom Dari/Tujuan dari tabel Bandara.
        /// Format saran: "CGK - Soekarno Hatta".
        /// </summary>
        private void MuatAutoCompleteBandara()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    string[] daftar = db.Bandara
                        .OrderBy(b => b.Nama)
                        .Select(b => b.KodeIATA + " - " + b.Nama)
                        .ToArray();

                    var sumber = new AutoCompleteStringCollection();
                    sumber.AddRange(daftar);
                    txtDari.AutoCompleteCustomSource = sumber;
                    txtTujuan.AutoCompleteCustomSource = sumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data bandara dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Pencarian

        /// <summary>
        /// Ubah ketikan user menjadi ID Bandara. Menerima Kode IATA ("CGK"),
        /// teks saran ("CGK - Soekarno Hatta"), atau Nama ("Soekarno Hatta").
        /// Return null jika cocok, atau pesan error jika tidak.
        /// </summary>
        private string ResolveBandara(string input, string label, out int bandaraId)
        {
            bandaraId = 0;
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Trim sisi database juga agar spasi nyasar di data lama tidak menggagalkan pencarian.
                    var daftar = db.Bandara
                        .Select(b => new { b.ID, b.KodeIATA, b.Nama })
                        .ToList()
                        .Select(b => new { b.ID, KodeIATA = b.KodeIATA.Trim(), Nama = b.Nama.Trim() })
                        .ToList();

                    if (daftar.Count == 0)
                        return "Data bandara masih kosong. Hubungi admin.";

                    var byKode = daftar.FirstOrDefault(b =>
                        string.Equals(b.KodeIATA, input, StringComparison.OrdinalIgnoreCase));
                    if (byKode != null)
                    {
                        bandaraId = byKode.ID;
                        return null;
                    }

                    var byTampil = daftar.FirstOrDefault(b =>
                        string.Equals(b.KodeIATA + " - " + b.Nama, input, StringComparison.OrdinalIgnoreCase));
                    if (byTampil != null)
                    {
                        bandaraId = byTampil.ID;
                        return null;
                    }

                    var byNama = daftar.Where(b =>
                        string.Equals(b.Nama, input, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (byNama.Count == 1)
                    {
                        bandaraId = byNama[0].ID;
                        return null;
                    }
                    if (byNama.Count > 1)
                        return "Ada beberapa bandara bernama \"" + input + "\". " +
                            "Pilih memakai Kode IATA dari daftar saran.";

                    return "Bandara " + label + " \"" + input + "\" tidak ditemukan. " +
                        "Pilih dari daftar saran (contoh: CGK - Soekarno Hatta).";
                }
            }
            catch (Exception ex)
            {
                return "Gagal memeriksa bandara ke database.\n" + ex.Message;
            }
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            string dariInput = (txtDari.Text ?? "").Trim();
            string tujuanInput = (txtTujuan.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(dariInput))
            {
                MessageBox.Show("Bandara keberangkatan wajib diisi.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDari.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tujuanInput))
            {
                MessageBox.Show("Bandara tujuan wajib diisi.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTujuan.Focus();
                return;
            }

            DateTime tanggal = dtpTanggal.Value.Date;
            if (tanggal < DateTime.Today)
            {
                MessageBox.Show("Tanggal berangkat tidak boleh lampau (minimal hari ini).", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int penumpang = Convert.ToInt32(numPenumpang.Value);
            if (penumpang < 1 || penumpang > 3)
            {
                MessageBox.Show("Jumlah penumpang harus antara 1 sampai 3 per pemesanan.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dariId, tujuanId;
            string errDari = ResolveBandara(dariInput, "keberangkatan", out dariId);
            if (errDari != null)
            {
                MessageBox.Show(errDari, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDari.Focus();
                return;
            }
            string errTujuan = ResolveBandara(tujuanInput, "tujuan", out tujuanId);
            if (errTujuan != null)
            {
                MessageBox.Show(errTujuan, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTujuan.Focus();
                return;
            }
            if (dariId == tujuanId)
            {
                MessageBox.Show("Bandara keberangkatan dan tujuan tidak boleh sama.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            using (Form10ListPenerbangan list = new Form10ListPenerbangan())
            {
                list.SetKriteria(dariId, tujuanId, tanggal, penumpang, LoggedInAkunId);
                list.ShowDialog(this);
            }
            this.Show();
        }

        #endregion

        private void Tiket_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form12TiketSaya tiket = new Form12TiketSaya())
            {
                tiket.AkunId = LoggedInAkunId;
                tiket.ShowDialog(this);
            }
            this.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogoutRequested = true;
            this.Close(); // kembali ke Login Form
        }

        private void Form9CustomerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Jika ditutup via X (bukan logout), tutup aplikasi.
            if (!LogoutRequested)
            {
                Application.Exit();
            }
        }
    }
}
