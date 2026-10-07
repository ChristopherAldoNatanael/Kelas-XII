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
    public partial class Form7KodePromo : Form
    {
        // True jika user klik Logout (minta kembali ke Login),
        // False jika form ditutup via X (kembali ke form sebelumnya).
        public bool LogoutRequested { get; private set; } = false;
        private bool sidebarExpanded = true;

        // Null = mode tambah baru, ada isi = mode ubah (menyimpan ID Promo yg sedang diedit).
        private int? _editingId = null;

        public Form7KodePromo()
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

            // --- Logic Master Kode Promo (backend only, UI tidak diubah) ---
            // NOTE: event Load sudah di-wire via Designer, jangan di-wire ulang di sini.
            this.dgvPromo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPromo_CellContentClick);
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.BtnBatal_Click);
        }

        #region Load & Tampil Data

        private void Form7KodePromo_Load(object sender, EventArgs e)
        {
            // Batas input disamakan dengan skema DB (kolom KodePromo):
            // Kode varchar(100), PersentaseDiskon float, MaksimumDiskon float,
            // BerlakuSampai date, Deskripsi text (NOT NULL semua).
            txtKodePromo.MaxLength = 50;
            txtDeskripsiInput.MaxLength = 1000;
            numPersen.Minimum = 1;
            numPersen.Maximum = 100;
            numMaks.Minimum = 1;
            numMaks.Maximum = 100000000;
            dtpBerlaku.Format = DateTimePickerFormat.Custom;
            dtpBerlaku.CustomFormat = "dd-MM-yyyy";
            dtpBerlaku.MinDate = DateTime.Today;

            MuatPromo();
            ResetForm();
        }

        /// <summary>
        /// Isi DataGridView dari tabel KodePromo. ID disimpan di Row.Tag
        /// agar kolom UI tidak berubah.
        /// </summary>
        private void MuatPromo()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.KodePromo
                                   .OrderBy(k => k.BerlakuSampai)
                                   .ToList();

                    dgvPromo.Rows.Clear();
                    foreach (var k in daftar)
                    {
                        int rowIndex = dgvPromo.Rows.Add(
                            k.Kode,
                            k.PersentaseDiskon.ToString("N0") + "%",
                            "Rp " + Convert.ToDecimal(k.MaksimumDiskon).ToString("N0"),
                            k.BerlakuSampai.ToString("dd-MM-yyyy"),
                            k.Deskripsi
                        );
                        dgvPromo.Rows[rowIndex].Tag = k.ID;
                    }
                    dgvPromo.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kode promo dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Validasi & Form State

        /// <summary>
        /// Validasi semua input. Return null jika valid, atau pesan error jika tidak.
        /// Mencakup: wajib isi, format &amp; tipe data, panjang sesuai skema DB,
        /// persen 1-100, tanggal berlaku tidak boleh lampau, dan duplikat Kode.
        /// </summary>
        private string ValidasiInput(out string kodeBersih, out double persen,
            out double maks, out DateTime berlaku)
        {
            // Kode dinormalisasi: spasi dibuang, huruf kapital ("hemat 10" -> "HEMAT10").
            kodeBersih = (txtKodePromo.Text ?? "").Trim().ToUpper().Replace(" ", "");
            persen = 0; maks = 0; berlaku = DateTime.MinValue;

            string deskripsi = (txtDeskripsiInput.Text ?? "").Trim();

            // --- Kode: wajib, 3-50 char, huruf/angka/strip/underscore ---
            if (string.IsNullOrWhiteSpace(kodeBersih))
                return "Kode promo wajib diisi (contoh: HEMAT20).";
            if (kodeBersih.Length < 3)
                return "Kode promo minimal 3 karakter.";
            if (kodeBersih.Length > 50)
                return "Kode promo maksimal 50 karakter.";
            if (!Regex.IsMatch(kodeBersih, @"^[A-Z0-9\-_]+$"))
                return "Kode promo \"" + txtKodePromo.Text.Trim() + "\" tidak valid. Hanya boleh huruf kapital, angka, strip, dan underscore (tanpa spasi/simbol lain).";

            // --- Berlaku Sampai: wajib >= hari ini (kolom date, promo lampau tak bisa disimpan) ---
            berlaku = dtpBerlaku.Value.Date;
            if (berlaku < DateTime.Today)
                return "Tanggal berlaku promo tidak boleh lampau (minimal hari ini).";

            // --- Persentase: 1-100 (float NOT NULL, persen valid) ---
            persen = Convert.ToDouble(numPersen.Value);
            if (persen < 1 || persen > 100)
                return "Persentase diskon harus antara 1 sampai 100.";
            if (numPersen.Value != Math.Floor(numPersen.Value))
                return "Persentase diskon harus bilangan bulat.";

            // --- Maksimum Diskon: minimal 1 (float NOT NULL, sesuai spek) ---
            maks = Convert.ToDouble(numMaks.Value);
            if (maks < 1)
                return "Maksimum diskon minimal Rp 1.";
            if (maks > 100000000)
                return "Maksimum diskon maksimal Rp 100.000.000.";

            // --- Deskripsi: wajib (NOT NULL di DB), 10-1000 char ---
            if (string.IsNullOrWhiteSpace(deskripsi))
                return "Deskripsi wajib diisi.";
            if (deskripsi.Length < 10)
                return "Deskripsi minimal 10 karakter (jelaskan syarat promo).";
            if (deskripsi.Length > 1000)
                return "Deskripsi maksimal 1000 karakter.";

            // --- Cek duplikat Kode (kecuali data yg sedang diedit) ---
            try
            {
                string kodeCek = kodeBersih;
                int? editId = _editingId;
                using (BandaraEntities db = new BandaraEntities())
                {
                    bool duplikat = editId.HasValue
                        ? db.KodePromo.Any(k => k.Kode == kodeCek && k.ID != editId.Value)
                        : db.KodePromo.Any(k => k.Kode == kodeCek);
                    if (duplikat)
                        return "Kode promo \"" + kodeCek + "\" sudah terdaftar. Gunakan kode lain.";
                }
            }
            catch (Exception ex)
            {
                return "Gagal memeriksa kode promo ke database.\n" + ex.Message;
            }

            return null;
        }

        /// <summary>
        /// Kembalikan form ke kondisi awal (mode tambah baru).
        /// </summary>
        private void ResetForm()
        {
            _editingId = null;
            txtKodePromo.Clear();
            txtDeskripsiInput.Clear();
            numPersen.Value = numPersen.Minimum;
            numMaks.Value = numMaks.Minimum;
            dtpBerlaku.MinDate = DateTime.Today;
            if (dtpBerlaku.Value.Date < DateTime.Today)
                dtpBerlaku.Value = DateTime.Today;
            btnSimpan.Text = "Simpan";
            dgvPromo.ClearSelection();
            txtKodePromo.Focus();
        }

        #endregion

        #region Simpan / Batal

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            string kode;
            double persen, maks;
            DateTime berlaku;
            string error = ValidasiInput(out kode, out persen, out maks, out berlaku);
            if (error != null)
            {
                MessageBox.Show(error, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string deskripsi = txtDeskripsiInput.Text.Trim();

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (_editingId.HasValue)
                    {
                        // --- UPDATE ---
                        KodePromo ent = db.KodePromo.Find(_editingId.Value);
                        if (ent == null)
                        {
                            MessageBox.Show("Data promo tidak ditemukan (mungkin sudah dihapus).",
                                "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MuatPromo();
                            ResetForm();
                            return;
                        }

                        ent.Kode = kode;
                        ent.PersentaseDiskon = persen;
                        ent.MaksimumDiskon = maks;
                        ent.BerlakuSampai = berlaku;
                        ent.Deskripsi = deskripsi;

                        db.SaveChanges();
                        MessageBox.Show("Kode promo berhasil diperbarui.", "Ubah",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // --- INSERT ---
                        KodePromo baru = new KodePromo
                        {
                            Kode = kode,
                            PersentaseDiskon = persen,
                            MaksimumDiskon = maks,
                            BerlakuSampai = berlaku,
                            Deskripsi = deskripsi
                        };
                        db.KodePromo.Add(baru);
                        db.SaveChanges();
                        MessageBox.Show("Kode promo berhasil disimpan.", "Simpan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MuatPromo();
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

        private void DgvPromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var kolom = dgvPromo.Columns[e.ColumnIndex];
            object tag = dgvPromo.Rows[e.RowIndex].Tag;
            if (tag == null || !(tag is int))
                return;
            int id = (int)tag;

            if (kolom.Name == "colUbah")
                MulaiEdit(id);
            else if (kolom.Name == "colHapus")
                HapusPromo(id);
        }

        /// <summary>
        /// Muat satu baris ke form input untuk diedit.
        /// MinDate dilonggarkan agar promo yang sudah kedaluwarsa tetap bisa
        /// ditampilkan (saat Simpan, tanggal wajib diperpanjang ke hari ini / sesudahnya).
        /// </summary>
        private void MulaiEdit(int id)
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    KodePromo k = db.KodePromo.Find(id);
                    if (k == null)
                    {
                        MessageBox.Show("Data promo tidak ditemukan (mungkin sudah dihapus).",
                            "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatPromo();
                        return;
                    }

                    _editingId = k.ID;
                    txtKodePromo.Text = k.Kode;
                    txtDeskripsiInput.Text = k.Deskripsi;
                    numPersen.Value = Math.Max(numPersen.Minimum,
                        Math.Min(numPersen.Maximum, Convert.ToDecimal(k.PersentaseDiskon)));
                    numMaks.Value = Math.Max(numMaks.Minimum,
                        Math.Min(numMaks.Maximum, Convert.ToDecimal(k.MaksimumDiskon)));

                    DateTime tanggal = k.BerlakuSampai.Date;
                    dtpBerlaku.MinDate = tanggal < DateTime.Today ? tanggal : DateTime.Today;
                    dtpBerlaku.Value = tanggal;

                    btnSimpan.Text = "Update";
                    txtKodePromo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data promo.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hapus promo setelah konfirmasi. Ditolak jika sudah dipakai transaksi.
        /// </summary>
        private void HapusPromo(int id)
        {
            DialogResult confirm = MessageBox.Show(
                "Hapus kode promo ini?\nData yang sudah dihapus tidak dapat dikembalikan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Cegah hapus jika promo sudah dipakai pada transaksi.
                    if (db.TransaksiHeader.Any(t => t.KodePromoID == id))
                    {
                        MessageBox.Show("Kode promo tidak dapat dihapus karena sudah digunakan " +
                            "pada transaksi penjualan tiket.",
                            "Hapus Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    KodePromo ent = db.KodePromo.Find(id);
                    if (ent == null)
                    {
                        MessageBox.Show("Data promo tidak ditemukan (mungkin sudah dihapus).",
                            "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatPromo();
                        return;
                    }

                    db.KodePromo.Remove(ent);
                    db.SaveChanges();
                    MessageBox.Show("Kode promo berhasil dihapus.", "Hapus",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Jika yg dihapus sedang diedit, kembalikan ke mode tambah.
                if (_editingId.HasValue && _editingId.Value == id)
                    ResetForm();
                else
                    dgvPromo.ClearSelection();

                MuatPromo();
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
            // Sudah di Master Kode Promo, tidak perlu pindah form.
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
