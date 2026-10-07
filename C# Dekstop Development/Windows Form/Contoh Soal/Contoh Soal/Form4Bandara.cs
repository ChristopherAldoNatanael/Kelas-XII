using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal
{
    public partial class Form4Bandara : Form
    {
        // True jika user klik Logout (minta kembali ke Login),
        // False jika form ditutup via X (kembali ke Dashboard).
        public bool LogoutRequested { get; private set; } = false;
        private bool sidebarExpanded = true;

        // Null = mode tambah baru, ada isi = mode ubah (menyimpan ID Bandara yg sedang diedit).
        private int? _editingId = null;

        public Form4Bandara()
        {
            InitializeComponent();

            this.lblNavBandara.Click += new System.EventHandler(this.NavBandara_Click);
            this.picNavBandara.Click += new System.EventHandler(this.NavBandara_Click);
            this.lblNavMaskapai.Click += new System.EventHandler(this.NavMaskapai_Click);
            this.picNavMaskapai.Click += new System.EventHandler(this.NavMaskapai_Click);
            this.lblNavJadwal.Click += new System.EventHandler(this.NavJadwal_Click);
            this.picNavJadwal.Click += new System.EventHandler(this.NavJadwal_Click);
            this.lblNavPromo.Click += new System.EventHandler(this.NavPromo_Click);
            this.picNavPromo.Click += new System.EventHandler(this.NavPromo_Click);
            this.lblNavStatus.Click += new System.EventHandler(this.NavStatus_Click);
            this.picNavStatus.Click += new System.EventHandler(this.NavStatus_Click);

            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);

            this.lblLogout.Click += new System.EventHandler(this.Logout_Click);
            this.picLogout.Click += new System.EventHandler(this.Logout_Click);

            // --- Logic Master Bandara (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form4Bandara_Load);
            this.dgvBandara.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBandara_CellContentClick);
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.BtnBatal_Click);
        }

        #region Load & Tampil Data

        private void Form4Bandara_Load(object sender, EventArgs e)
        {
            // Batas input disamakan dengan skema DB (EDMX):
            // Nama varchar(200), KodeIATA varchar(5, logika IATA=3), Kota varchar(200),
            // JumlahTerminal int, Alamat varchar(MAX).
            txtNama.MaxLength = 200;
            txtKodeIATA.MaxLength = 3;
            txtKota.MaxLength = 200;
            txtAlamatInput.MaxLength = 1000;
            numTerminal.Minimum = 1;
            numTerminal.Maximum = 50;

            MuatNegara();
            MuatBandara();
            ResetForm();
        }

        /// <summary>
        /// Isi ComboBox Negara dari tabel Negara (diurutkan abjad).
        /// </summary>
        private void MuatNegara()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.Negara
                                   .OrderBy(n => n.Nama)
                                   .Select(n => new { n.ID, n.Nama })
                                   .ToList();

                    cmbNegara.DataSource = daftar;
                    cmbNegara.DisplayMember = "Nama";
                    cmbNegara.ValueMember = "ID";
                    cmbNegara.SelectedIndex = -1; // paksa user memilih
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data negara dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Isi DataGridView dari tabel Bandara + nama Negara. ID disimpan di Row.Tag
        /// agar kolom UI tidak berubah.
        /// </summary>
        private void MuatBandara()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.Bandara
                                   .Include(b => b.Negara)
                                   .OrderBy(b => b.Nama)
                                   .ToList();

                    dgvBandara.Rows.Clear();
                    foreach (var b in daftar)
                    {
                        int rowIndex = dgvBandara.Rows.Add(
                            b.Nama,
                            b.KodeIATA,
                            b.Kota,
                            b.Negara != null ? b.Negara.Nama : "-",
                            b.JumlahTerminal,
                            b.Alamat
                        );
                        dgvBandara.Rows[rowIndex].Tag = b.ID;
                    }
                    dgvBandara.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data bandara dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Validasi & Form State

        /// <summary>
        /// Validasi semua input. Return null jika valid, atau pesan error jika tidak.
        /// Mencakup: wajib isi, format &amp; tipe data, panjang min/maks sesuai skema DB,
        /// karakter yang diizinkan, range angka, FK Negara, dan duplikat Kode IATA.
        /// Kode IATA dinormalisasi ke huruf kapital 3 karakter.
        /// </summary>
        private string ValidasiInput(out string kodeIataBersih, out int negaraId)
        {
            // Kode IATA dinormalisasi: spasi dibuang, huruf kapital 3 karakter
            // ("c g k" -> "CGK"), agar input wajar tidak ditolak sia-sia.
            kodeIataBersih = (txtKodeIATA.Text ?? "").Trim().ToUpper().Replace(" ", "");
            negaraId = 0;

            string nama = (txtNama.Text ?? "").Trim();
            string kota = (txtKota.Text ?? "").Trim();
            string alamat = (txtAlamatInput.Text ?? "").Trim();

            // --- Nama: wajib, 3-200 char, tidak boleh angka saja, karakter wajar nama bandara ---
            if (string.IsNullOrWhiteSpace(nama))
                return "Nama bandara wajib diisi.";
            if (nama.Length < 3)
                return "Nama bandara minimal 3 karakter.";
            if (nama.Length > 200)
                return "Nama bandara maksimal 200 karakter (mengikuti kolom database).";
            if (Regex.IsMatch(nama, @"^\d+$"))
                return "Nama bandara tidak boleh hanya berisi angka.";
            if (!Regex.IsMatch(nama, @"^[A-Za-z0-9\s\.\'’\-,()]+$"))
                return "Nama bandara hanya boleh berisi huruf, angka, spasi, titik, koma, tanda petik, strip, dan kurung.";

            // --- Kode IATA: wajib, tepat 3 huruf A-Z, tanpa angka/spasi ---
            if (string.IsNullOrWhiteSpace(kodeIataBersih))
                return "Kode IATA wajib diisi (contoh: CGK).";
            if (!Regex.IsMatch(kodeIataBersih, @"^[A-Z]{3}$"))
                return "Kode IATA harus tepat 3 huruf (A-Z) tanpa angka/simbol, contoh: CGK.";

            // --- Kota: wajib, 3-200 char, huruf saja + karakter umum nama kota ---
            if (string.IsNullOrWhiteSpace(kota))
                return "Kota wajib diisi.";
            if (kota.Length < 3)
                return "Nama kota minimal 3 karakter.";
            if (kota.Length > 200)
                return "Nama kota maksimal 200 karakter (mengikuti kolom database).";
            if (Regex.IsMatch(kota, @"^\d+$"))
                return "Nama kota tidak boleh hanya berisi angka.";
            if (!Regex.IsMatch(kota, @"^[A-Za-z\s\.\'’\-]+$"))
                return "Nama kota hanya boleh berisi huruf, spasi, titik, petik, dan strip (tanpa angka/simbol).";
            if (Regex.IsMatch(kota, @"\d"))
                return "Nama kota tidak boleh mengandung angka.";

            // --- Negara: wajib dipilih & harus terdaftar di DB (validasi FK / tipe int) ---
            if (cmbNegara.SelectedValue == null || !int.TryParse(cmbNegara.SelectedValue.ToString(), out negaraId))
                return "Negara wajib dipilih.";
            try
            {
                int cekNegaraId = negaraId;
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (!db.Negara.Any(n => n.ID == cekNegaraId))
                        return "Negara yang dipilih tidak terdaftar di database. Muat ulang data negara.";
                }
            }
            catch (Exception ex)
            {
                return "Gagal memeriksa Negara ke database.\n" + ex.Message;
            }

            // --- JumlahTerminal: tipe int via NumericUpDown, validasi range 1-50 ---
            if (numTerminal.Value < 1 || numTerminal.Value > 50)
                return "Jumlah terminal harus antara 1 sampai 50.";
            if (numTerminal.Value != Math.Floor(numTerminal.Value))
                return "Jumlah terminal harus bilangan bulat.";

            // --- Alamat: wajib, minimal 10 char (alamat asli), maks 1000 agar tidak abuse varchar(MAX) ---
            if (string.IsNullOrWhiteSpace(alamat))
                return "Alamat wajib diisi.";
            if (alamat.Length < 10)
                return "Alamat minimal 10 karakter (isi alamat lengkap, mis. nama jalan + nomor).";
            if (alamat.Length > 1000)
                return "Alamat maksimal 1000 karakter.";

            // Cek duplikat Kode IATA & Nama (kecuali data yg sedang diedit).
            // Perbandingan string di SQL Server mengikuti collation CI (case-insensitive),
            // sehingga "Soekarno-Hatta" vs "SOEKARNO-HATTA" tetap terdeteksi duplikat.
            try
            {
                string kodeCek = kodeIataBersih;
                string namaCek = nama;
                int? editId = _editingId;
                using (BandaraEntities db = new BandaraEntities())
                {
                    bool duplikatKode = editId.HasValue
                        ? db.Bandara.Any(b => b.KodeIATA == kodeCek && b.ID != editId.Value)
                        : db.Bandara.Any(b => b.KodeIATA == kodeCek);
                    if (duplikatKode)
                        return "Kode IATA \"" + kodeCek + "\" sudah terdaftar. Gunakan kode lain.";

                    bool duplikatNama = editId.HasValue
                        ? db.Bandara.Any(b => b.Nama == namaCek && b.ID != editId.Value)
                        : db.Bandara.Any(b => b.Nama == namaCek);
                    if (duplikatNama)
                        return "Nama bandara \"" + namaCek + "\" sudah terdaftar. Gunakan nama lain.";
                }
            }
            catch (Exception ex)
            {
                return "Gagal memeriksa data ke database.\n" + ex.Message;
            }

            return null;
        }

        /// <summary>
        /// Kembalikan form ke kondisi awal (mode tambah baru).
        /// </summary>
        private void ResetForm()
        {
            _editingId = null;
            txtNama.Clear();
            txtKodeIATA.Clear();
            txtKota.Clear();
            txtAlamatInput.Clear();
            numTerminal.Value = numTerminal.Minimum;
            if (cmbNegara.DataSource != null)
                cmbNegara.SelectedIndex = -1;
            btnSimpan.Text = "Simpan";
            dgvBandara.ClearSelection();
            txtNama.Focus();
        }

        #endregion

        #region Simpan / Batal

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            string kodeIata;
            int negaraId;
            string error = ValidasiInput(out kodeIata, out negaraId);
            if (error != null)
            {
                MessageBox.Show(error, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nama = txtNama.Text.Trim();
            string kota = txtKota.Text.Trim();
            string alamat = txtAlamatInput.Text.Trim();
            int jumlahTerminal = Convert.ToInt32(numTerminal.Value);

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (_editingId.HasValue)
                    {
                        // --- UPDATE ---
                        Bandara ent = db.Bandara.Find(_editingId.Value);
                        if (ent == null)
                        {
                            MessageBox.Show("Data bandara tidak ditemukan (mungkin sudah dihapus).",
                                "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MuatBandara();
                            ResetForm();
                            return;
                        }

                        ent.Nama = nama;
                        ent.KodeIATA = kodeIata;
                        ent.Kota = kota;
                        ent.NegaraID = negaraId;
                        ent.JumlahTerminal = jumlahTerminal;
                        ent.Alamat = alamat;

                        db.SaveChanges();
                        MessageBox.Show("Data bandara berhasil diperbarui.", "Ubah",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // --- INSERT ---
                        Bandara baru = new Bandara
                        {
                            Nama = nama,
                            KodeIATA = kodeIata,
                            Kota = kota,
                            NegaraID = negaraId,
                            JumlahTerminal = jumlahTerminal,
                            Alamat = alamat
                        };
                        db.Bandara.Add(baru);
                        db.SaveChanges();
                        MessageBox.Show("Data bandara berhasil disimpan.", "Simpan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MuatBandara();
                ResetForm();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
            {
                string msg = dbEx.InnerException != null && dbEx.InnerException.InnerException != null
                    ? dbEx.InnerException.InnerException.Message
                    : dbEx.Message;
                MessageBox.Show("Gagal menyimpan ke database.\n" + msg,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan ke database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region Ubah / Hapus (kolom tombol grid)

        private void DgvBandara_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var kolom = dgvBandara.Columns[e.ColumnIndex];
            object tag = dgvBandara.Rows[e.RowIndex].Tag;
            if (tag == null || !(tag is int))
                return;
            int id = (int)tag;

            if (kolom.Name == "colUbah")
                MulaiEdit(id);
            else if (kolom.Name == "colHapus")
                HapusBandara(id);
        }

        /// <summary>
        /// Muat satu baris ke form input untuk diedit.
        /// </summary>
        private void MulaiEdit(int id)
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    Bandara b = db.Bandara.Find(id);
                    if (b == null)
                    {
                        MessageBox.Show("Data bandara tidak ditemukan (mungkin sudah dihapus).",
                            "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatBandara();
                        return;
                    }

                    _editingId = b.ID;
                    txtNama.Text = b.Nama;
                    txtKodeIATA.Text = b.KodeIATA;
                    txtKota.Text = b.Kota;
                    txtAlamatInput.Text = b.Alamat;
                    numTerminal.Value = Math.Max(numTerminal.Minimum,
                        Math.Min(numTerminal.Maximum, b.JumlahTerminal));

                    // Sinkronkan ComboBox Negara (refresh jika perlu).
                    try { cmbNegara.SelectedValue = b.NegaraID; }
                    catch { /* abaikan, biarkan pilihan lama */ }

                    btnSimpan.Text = "Update";
                    txtNama.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data bandara.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hapus bandara setelah konfirmasi. Ditolak jika dipakai di jadwal penerbangan.
        /// </summary>
        private void HapusBandara(int id)
        {
            DialogResult confirm = MessageBox.Show(
                "Hapus data bandara ini?\nData yang sudah dihapus tidak dapat dikembalikan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Cegah hapus jika bandara masih dipakai sebagai keberangkatan/tujuan.
                    bool dipakai = db.JadwalPenerbangan.Any(j =>
                        j.BandaraKeberangkatanID == id || j.BandaraTujuanID == id);
                    if (dipakai)
                    {
                        MessageBox.Show("Bandara tidak dapat dihapus karena masih digunakan " +
                            "pada jadwal penerbangan (keberangkatan/tujuan).",
                            "Hapus Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Bandara ent = db.Bandara.Find(id);
                    if (ent == null)
                    {
                        MessageBox.Show("Data bandara tidak ditemukan (mungkin sudah dihapus).",
                            "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatBandara();
                        return;
                    }

                    db.Bandara.Remove(ent);
                    db.SaveChanges();
                    MessageBox.Show("Data bandara berhasil dihapus.", "Hapus",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Jika yg dihapus sedang diedit, kembalikan ke mode tambah.
                if (_editingId.HasValue && _editingId.Value == id)
                    ResetForm();
                else
                    dgvBandara.ClearSelection();

                MuatBandara();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
            {
                string msg = dbEx.InnerException != null && dbEx.InnerException.InnerException != null
                    ? dbEx.InnerException.InnerException.Message
                    : dbEx.Message;
                MessageBox.Show("Gagal menghapus data (kemungkinan masih berelasi dengan data lain).\n" + msg,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus data.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Navigasi (bawaan, tidak diubah)

        private void NavBandara_Click(object sender, EventArgs e)
        {
            // Sudah di Master Bandara, tidak perlu pindah form.
        }

        private void NavMaskapai_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form5Maskapai maskapai = new Form5Maskapai())
            {
                maskapai.ShowDialog(this);
                if (maskapai.LogoutRequested)
                {
                    LogoutRequested = true;
                    this.Close();
                    return;
                }
            }
            this.Show();
        }

        private void NavJadwal_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form6JadwalPenerbangan jadwal = new Form6JadwalPenerbangan())
            {
                jadwal.ShowDialog(this);
                if (jadwal.LogoutRequested)
                {
                    LogoutRequested = true;
                    this.Close();
                    return;
                }
            }
            this.Show();
        }

        private void NavPromo_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form7KodePromo promo = new Form7KodePromo())
            {
                promo.ShowDialog(this);
                if (promo.LogoutRequested)
                {
                    LogoutRequested = true;
                    this.Close();
                    return;
                }
            }
            this.Show();
        }

        private void NavStatus_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form8UbahStatusPenerbangan status = new Form8UbahStatusPenerbangan())
            {
                status.ShowDialog(this);
                if (status.LogoutRequested)
                {
                    LogoutRequested = true;
                    this.Close();
                    return;
                }
            }
            this.Show();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            sidebarExpanded = !sidebarExpanded;
            pnlSidebar.Width = sidebarExpanded ? 222 : 60;
            foreach (Control c in new Control[] { lblNavBandara, lblNavMaskapai, lblNavJadwal, lblNavPromo, lblNavStatus, lblLogout })
                c.Visible = sidebarExpanded;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogoutRequested = true;
            this.Close();
        }

        #endregion
    }
}
