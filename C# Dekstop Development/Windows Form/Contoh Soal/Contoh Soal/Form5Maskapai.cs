using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal
{
    public partial class Form5Maskapai : Form
    {
        // True jika user klik Logout (minta kembali ke Login),
        // False jika form ditutup via X (kembali ke form sebelumnya).
        public bool LogoutRequested { get; private set; } = false;
        private bool sidebarExpanded = true;

        // Null = mode tambah baru, ada isi = mode ubah (menyimpan ID Maskapai yg sedang diedit).
        private int? _editingId = null;

        public Form5Maskapai()
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

            // --- Logic Master Maskapai (backend only, UI tidak diubah) ---
            // NOTE: event Load sudah di-wire via Designer, jangan di-wire ulang di sini.
            this.dgvMaskapai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMaskapai_CellContentClick);
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.BtnBatal_Click);
        }

        #region Load & Tampil Data

        private void Form5Maskapai_Load(object sender, EventArgs e)
        {
            // Batas input disamakan dengan skema DB (EDMX):
            // Nama varchar(200), Perusahaan varchar(200),
            // JumlahKru int, Deskripsi varchar(MAX NOT NULL).
            txtNama.MaxLength = 200;
            txtPerusahaan.MaxLength = 200;
            txtDeskripsiInput.MaxLength = 1000;
            numKru.Minimum = 1;
            numKru.Maximum = 100;

            MuatMaskapai();
            ResetForm();
        }

        /// <summary>
        /// Isi DataGridView dari tabel Maskapai. ID disimpan di Row.Tag
        /// agar kolom UI tidak berubah.
        /// </summary>
        private void MuatMaskapai()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.Maskapai
                                   .OrderBy(m => m.Nama)
                                   .ToList();

                    dgvMaskapai.Rows.Clear();
                    foreach (var m in daftar)
                    {
                        int rowIndex = dgvMaskapai.Rows.Add(
                            m.Nama,
                            m.Perusahaan,
                            m.JumlahKru,
                            m.Deskripsi
                        );
                        dgvMaskapai.Rows[rowIndex].Tag = m.ID;
                    }
                    dgvMaskapai.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data maskapai dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Validasi & Form State

        /// <summary>
        /// Validasi semua input. Return null jika valid, atau pesan error jika tidak.
        /// Mencakup: wajib isi, format &amp; tipe data, panjang min/maks sesuai skema DB,
        /// karakter yang diizinkan, range angka, dan duplikat Nama.
        /// </summary>
        private string ValidasiInput()
        {
            string nama = (txtNama.Text ?? "").Trim();
            string perusahaan = (txtPerusahaan.Text ?? "").Trim();
            string deskripsi = (txtDeskripsiInput.Text ?? "").Trim();

            // --- Nama: wajib, 3-200 char, tidak boleh angka saja ---
            if (string.IsNullOrWhiteSpace(nama))
                return "Nama maskapai wajib diisi.";
            if (nama.Length < 3)
                return "Nama maskapai minimal 3 karakter.";
            if (nama.Length > 200)
                return "Nama maskapai maksimal 200 karakter (mengikuti kolom database).";
            if (Regex.IsMatch(nama, @"^\d+$"))
                return "Nama maskapai tidak boleh hanya berisi angka.";
            if (!Regex.IsMatch(nama, @"^[A-Za-z0-9\s\.\'’\-,&()]+$"))
                return "Nama maskapai hanya boleh berisi huruf, angka, spasi, titik, koma, petik, strip, &, dan kurung.";

            // --- Perusahaan: wajib, 3-200 char, tidak boleh angka saja ---
            if (string.IsNullOrWhiteSpace(perusahaan))
                return "Perusahaan wajib diisi.";
            if (perusahaan.Length < 3)
                return "Nama perusahaan minimal 3 karakter.";
            if (perusahaan.Length > 200)
                return "Nama perusahaan maksimal 200 karakter (mengikuti kolom database).";
            if (Regex.IsMatch(perusahaan, @"^\d+$"))
                return "Nama perusahaan tidak boleh hanya berisi angka.";
            if (!Regex.IsMatch(perusahaan, @"^[A-Za-z0-9\s\.\'’\-,&()]+$"))
                return "Nama perusahaan hanya boleh berisi huruf, angka, spasi, titik, koma, petik, strip, &, dan kurung.";

            // --- JumlahKru: tipe int via NumericUpDown, validasi range 1-100 ---
            if (numKru.Value < 1 || numKru.Value > 100)
                return "Jumlah kru harus antara 1 sampai 100.";
            if (numKru.Value != Math.Floor(numKru.Value))
                return "Jumlah kru harus bilangan bulat.";

            // --- Deskripsi: wajib (NOT NULL di DB), 10-1000 char ---
            if (string.IsNullOrWhiteSpace(deskripsi))
                return "Deskripsi wajib diisi.";
            if (deskripsi.Length < 10)
                return "Deskripsi minimal 10 karakter (jelaskan singkat tentang maskapai).";
            if (deskripsi.Length > 1000)
                return "Deskripsi maksimal 1000 karakter.";

            // --- Cek duplikat Nama (kecuali data yg sedang diedit) ---
            try
            {
                string namaCek = nama;
                int? editId = _editingId;
                using (BandaraEntities db = new BandaraEntities())
                {
                    bool duplikat = editId.HasValue
                        ? db.Maskapai.Any(m => m.Nama == namaCek && m.ID != editId.Value)
                        : db.Maskapai.Any(m => m.Nama == namaCek);
                    if (duplikat)
                        return "Nama maskapai \"" + namaCek + "\" sudah terdaftar. Gunakan nama lain.";
                }
            }
            catch (Exception ex)
            {
                return "Gagal memeriksa nama maskapai ke database.\n" + ex.Message;
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
            txtPerusahaan.Clear();
            txtDeskripsiInput.Clear();
            numKru.Value = numKru.Minimum;
            btnSimpan.Text = "Simpan";
            dgvMaskapai.ClearSelection();
            txtNama.Focus();
        }

        #endregion

        #region Simpan / Batal

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            string error = ValidasiInput();
            if (error != null)
            {
                MessageBox.Show(error, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nama = txtNama.Text.Trim();
            string perusahaan = txtPerusahaan.Text.Trim();
            string deskripsi = txtDeskripsiInput.Text.Trim();
            int jumlahKru = Convert.ToInt32(numKru.Value);

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (_editingId.HasValue)
                    {
                        // --- UPDATE ---
                        Maskapai ent = db.Maskapai.Find(_editingId.Value);
                        if (ent == null)
                        {
                            MessageBox.Show("Data maskapai tidak ditemukan (mungkin sudah dihapus).",
                                "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MuatMaskapai();
                            ResetForm();
                            return;
                        }

                        ent.Nama = nama;
                        ent.Perusahaan = perusahaan;
                        ent.JumlahKru = jumlahKru;
                        ent.Deskripsi = deskripsi;

                        db.SaveChanges();
                        MessageBox.Show("Data maskapai berhasil diperbarui.", "Ubah",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // --- INSERT ---
                        Maskapai baru = new Maskapai
                        {
                            Nama = nama,
                            Perusahaan = perusahaan,
                            JumlahKru = jumlahKru,
                            Deskripsi = deskripsi
                        };
                        db.Maskapai.Add(baru);
                        db.SaveChanges();
                        MessageBox.Show("Data maskapai berhasil disimpan.", "Simpan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MuatMaskapai();
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

        private void DgvMaskapai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var kolom = dgvMaskapai.Columns[e.ColumnIndex];
            object tag = dgvMaskapai.Rows[e.RowIndex].Tag;
            if (tag == null || !(tag is int))
                return;
            int id = (int)tag;

            if (kolom.Name == "colUbah")
                MulaiEdit(id);
            else if (kolom.Name == "colHapus")
                HapusMaskapai(id);
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
                    Maskapai m = db.Maskapai.Find(id);
                    if (m == null)
                    {
                        MessageBox.Show("Data maskapai tidak ditemukan (mungkin sudah dihapus).",
                            "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatMaskapai();
                        return;
                    }

                    _editingId = m.ID;
                    txtNama.Text = m.Nama;
                    txtPerusahaan.Text = m.Perusahaan;
                    txtDeskripsiInput.Text = m.Deskripsi;
                    numKru.Value = Math.Max(numKru.Minimum,
                        Math.Min(numKru.Maximum, m.JumlahKru));

                    btnSimpan.Text = "Update";
                    txtNama.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data maskapai.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hapus maskapai setelah konfirmasi. Ditolak jika dipakai di jadwal penerbangan.
        /// </summary>
        private void HapusMaskapai(int id)
        {
            DialogResult confirm = MessageBox.Show(
                "Hapus data maskapai ini?\nData yang sudah dihapus tidak dapat dikembalikan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Cegah hapus jika maskapai masih dipakai di jadwal penerbangan.
                    bool dipakai = db.JadwalPenerbangan.Any(j => j.MaskapaiID == id);
                    if (dipakai)
                    {
                        MessageBox.Show("Maskapai tidak dapat dihapus karena masih digunakan " +
                            "pada jadwal penerbangan.",
                            "Hapus Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Maskapai ent = db.Maskapai.Find(id);
                    if (ent == null)
                    {
                        MessageBox.Show("Data maskapai tidak ditemukan (mungkin sudah dihapus).",
                            "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatMaskapai();
                        return;
                    }

                    db.Maskapai.Remove(ent);
                    db.SaveChanges();
                    MessageBox.Show("Data maskapai berhasil dihapus.", "Hapus",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Jika yg dihapus sedang diedit, kembalikan ke mode tambah.
                if (_editingId.HasValue && _editingId.Value == id)
                    ResetForm();
                else
                    dgvMaskapai.ClearSelection();

                MuatMaskapai();
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
            this.Hide();
            using (Form4Bandara bandara = new Form4Bandara())
            {
                bandara.ShowDialog(this);
                if (bandara.LogoutRequested)
                {
                    LogoutRequested = true;
                    this.Close();
                    return;
                }
            }
            this.Show();
        }

        private void NavMaskapai_Click(object sender, EventArgs e)
        {
            // Sudah di Master Maskapai, tidak perlu pindah form.
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
