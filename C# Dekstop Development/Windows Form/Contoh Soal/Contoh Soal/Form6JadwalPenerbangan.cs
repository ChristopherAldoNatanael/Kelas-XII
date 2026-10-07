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
    public partial class Form6JadwalPenerbangan : Form
    {
        // True jika user klik Logout (minta kembali ke Login),
        // False jika form ditutup via X (kembali ke form sebelumnya).
        public bool LogoutRequested { get; private set; } = false;
        private bool sidebarExpanded = true;

        // Null = mode tambah baru, ada isi = mode ubah (menyimpan ID Jadwal yg sedang diedit).
        private int? _editingId = null;

        public Form6JadwalPenerbangan()
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

            // --- Logic Master Jadwal Penerbangan (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form6JadwalPenerbangan_Load);
            this.dgvJadwal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJadwal_CellContentClick);
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.BtnBatal_Click);
        }

        #region Load & Tampil Data

        private void Form6JadwalPenerbangan_Load(object sender, EventArgs e)
        {
            // Batas input disamakan dengan spek + skema DB:
            // Kode format "XX-9999" (2 huruf + strip + 4 digit),
            // TanggalWaktuKeberangkatan datetime, DurasiPenerbangan int (menit,
            // diinput "XX jam YY menit"), HargaPerTiket float.
            // Format tanggal default spek: DD-MM-YYYY.
            txtKode.MaxLength = 7;
            txtWaktu.MaxLength = 5;
            txtDurasi.MaxLength = 15;
            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = "dd-MM-yyyy";
            dtpTanggal.MinDate = DateTime.Today;
            numHarga.Minimum = 1;
            numHarga.Maximum = 100000000;

            MuatComboBandara();
            MuatComboMaskapai();
            MuatJadwal();
            ResetForm();
        }

        /// <summary>
        /// Isi ComboBox bandara keberangkatan &amp; tujuan dari tabel Bandara.
        /// Tampil: "CGK - Soekarno Hatta" agar mudah dipilih.
        /// </summary>
        private void MuatComboBandara()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.Bandara
                                   .OrderBy(b => b.Nama)
                                   .Select(b => new
                                   {
                                       b.ID,
                                       Tampil = b.KodeIATA + " - " + b.Nama
                                   })
                                   .ToList();

                    cmbDari.DataSource = new List<object>(daftar.Cast<object>());
                    cmbDari.DisplayMember = "Tampil";
                    cmbDari.ValueMember = "ID";
                    cmbDari.SelectedIndex = -1;

                    cmbKe.DataSource = new List<object>(daftar.Cast<object>());
                    cmbKe.DisplayMember = "Tampil";
                    cmbKe.ValueMember = "ID";
                    cmbKe.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data bandara dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Isi ComboBox maskapai dari tabel Maskapai.
        /// </summary>
        private void MuatComboMaskapai()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.Maskapai
                                   .OrderBy(m => m.Nama)
                                   .Select(m => new { m.ID, m.Nama })
                                   .ToList();

                    cmbMaskapaiInput.DataSource = daftar;
                    cmbMaskapaiInput.DisplayMember = "Nama";
                    cmbMaskapaiInput.ValueMember = "ID";
                    cmbMaskapaiInput.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data maskapai dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Isi DataGridView dari tabel JadwalPenerbangan + nama relasi.
        /// Urut tanggal &amp; waktu keberangkatan MENURUN (paling jauh pertama),
        /// durasi format "XX jam YY menit" sesuai spek.
        /// ID disimpan di Row.Tag agar kolom UI tidak berubah.
        /// </summary>
        private void MuatJadwal()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var jadwal = db.JadwalPenerbangan
                                   .OrderByDescending(j => j.TanggalWaktuKeberangkatan)
                                   .ToList();

                    var bandara = db.Bandara
                                     .Select(b => new { b.ID, b.KodeIATA, b.Nama })
                                     .ToList()
                                     .ToDictionary(b => b.ID, b => b.KodeIATA + " - " + b.Nama);
                    var maskapai = db.Maskapai
                                      .Select(m => new { m.ID, m.Nama })
                                      .ToList()
                                      .ToDictionary(m => m.ID, m => m.Nama);

                    dgvJadwal.Rows.Clear();
                    foreach (var j in jadwal)
                    {
                        string dari = bandara.ContainsKey(j.BandaraKeberangkatanID)
                            ? bandara[j.BandaraKeberangkatanID] : "-";
                        string ke = bandara.ContainsKey(j.BandaraTujuanID)
                            ? bandara[j.BandaraTujuanID] : "-";
                        string namaMaskapai = maskapai.ContainsKey(j.MaskapaiID)
                            ? maskapai[j.MaskapaiID] : "-";

                        int rowIndex = dgvJadwal.Rows.Add(
                            j.KodePenerbangan,
                            dari,
                            ke,
                            namaMaskapai,
                            j.TanggalWaktuKeberangkatan.ToString("dd-MM-yyyy"),
                            j.TanggalWaktuKeberangkatan.ToString("HH:mm"),
                            ToDurasiText(j.DurasiPenerbangan),
                            "Rp " + Convert.ToDecimal(j.HargaPerTiket).ToString("N0")
                        );
                        dgvJadwal.Rows[rowIndex].Tag = j.ID;
                    }
                    dgvJadwal.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat jadwal penerbangan dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ubah menit menjadi teks "XX jam YY menit" sesuai format spek.
        /// Contoh: 90 -&gt; "1 jam 30 menit".
        /// </summary>
        private static string ToDurasiText(int totalMenit)
        {
            return (totalMenit / 60) + " jam " + (totalMenit % 60) + " menit";
        }

        /// <summary>
        /// Urai teks "XX jam YY menit" menjadi total menit.
        /// Return null jika format/angka tidak valid.
        /// </summary>
        private static int? ParseDurasiText(string teks)
        {
            if (string.IsNullOrWhiteSpace(teks))
                return null;
            string t = Regex.Replace(teks.Trim(), @"\s+", " ");
            Match m = Regex.Match(t, @"^(\d+)\s+jam\s+(\d+)\s+menit$", RegexOptions.IgnoreCase);
            if (!m.Success)
                return null;
            int xx, yy;
            if (!int.TryParse(m.Groups[1].Value, out xx)) return null;
            if (!int.TryParse(m.Groups[2].Value, out yy)) return null;
            if (yy > 59) return null;
            int total = xx * 60 + yy;
            if (total < 10 || total > 1440) return null;
            return total;
        }

        #endregion

        #region Validasi & Form State

        /// <summary>
        /// Validasi semua input. Return null jika valid, atau pesan error jika tidak.
        /// Mencakup: wajib isi, format &amp; tipe data, panjang sesuai skema DB,
        /// FK harus terdaftar, rute Dari != Ke, tanggal jam tidak boleh lampau,
        /// durasi &amp; harga dalam range wajar, dan duplikat Kode Penerbangan.
        /// </summary>
        private string ValidasiInput(out int dariId, out int keId, out int maskapaiId,
            out DateTime berangkat, out int durasiMenit, out double harga)
        {
            dariId = 0; keId = 0; maskapaiId = 0;
            berangkat = DateTime.MinValue; durasiMenit = 0; harga = 0;

            // Kode dinormalisasi: spasi dibuang, huruf kapital ("ga -1234" -> "GA-1234").
            string kode = (txtKode.Text ?? "").Trim().ToUpper().Replace(" ", "");
            string waktuText = (txtWaktu.Text ?? "").Trim();
            string durasiText = (txtDurasi.Text ?? "").Trim();

            // --- Kode Penerbangan (spek): 2 huruf + strip + 4 digit, contoh "GA-1234" ---
            if (string.IsNullOrWhiteSpace(kode))
                return "Kode penerbangan wajib diisi (contoh: GA-1234).";
            if (!Regex.IsMatch(kode, @"^[A-Z]{2}-\d{4}$"))
                return "Kode penerbangan \"" + txtKode.Text.Trim() + "\" tidak valid. " +
                    "Format: dua huruf + strip + empat digit angka (contoh: GA-1234).";

            // --- Bandara asal & tujuan: wajib dipilih, harus beda, harus terdaftar (FK) ---
            if (cmbDari.SelectedValue == null || !int.TryParse(cmbDari.SelectedValue.ToString(), out dariId))
                return "Bandara keberangkatan (Dari) wajib dipilih.";
            if (cmbKe.SelectedValue == null || !int.TryParse(cmbKe.SelectedValue.ToString(), out keId))
                return "Bandara tujuan (Ke) wajib dipilih.";
            if (dariId == keId)
                return "Bandara keberangkatan dan tujuan tidak boleh sama.";

            // --- Maskapai: wajib dipilih ---
            if (cmbMaskapaiInput.SelectedValue == null || !int.TryParse(cmbMaskapaiInput.SelectedValue.ToString(), out maskapaiId))
                return "Maskapai wajib dipilih.";

            // --- Waktu: format 24 jam (ditoleransi: titik/spasi otomatis jadi ':') ---
            // Contoh yang diterima: "08:30", "8:30", "20.30" -> dinormalisasi ke "HH:mm".
            waktuText = waktuText.Replace(" ", "").Replace(".", ":");
            if (string.IsNullOrWhiteSpace(waktuText))
                return "Waktu keberangkatan wajib diisi (format JJ:MM, contoh: 08:30).";
            if (!Regex.IsMatch(waktuText, @"^([01]?\d|2[0-3]):[0-5]\d$"))
                return "Waktu keberangkatan \"" + txtWaktu.Text.Trim() + "\" tidak valid. Gunakan format 24 jam JJ:MM (contoh: 08:30).";
            TimeSpan jam;
            if (!TimeSpan.TryParse(waktuText, out jam))
                return "Waktu keberangkatan \"" + txtWaktu.Text.Trim() + "\" tidak valid.";
            txtWaktu.Text = jam.ToString(@"hh\:mm"); // tampilkan bentuk baku HH:mm

            // --- Tanggal + Waktu gabung: tidak boleh lampau (datetime NOT NULL) ---
            berangkat = dtpTanggal.Value.Date + jam;
            if (berangkat <= DateTime.Now)
                return "Jadwal keberangkatan harus di masa depan (tanggal + jam tidak boleh lampau).";

            // --- Durasi (spek): format "XX jam YY menit", disimpan sebagai menit (int) ---
            if (string.IsNullOrWhiteSpace(durasiText))
                return "Durasi penerbangan wajib diisi (format: \"XX jam YY menit\", contoh: \"2 jam 30 menit\").";
            int? durasiHasil = ParseDurasiText(durasiText);
            if (!durasiHasil.HasValue)
                return "Durasi penerbangan \"" + txtDurasi.Text.Trim() + "\" tidak valid. " +
                    "Gunakan format \"XX jam YY menit\" (menit 0-59, total 10 menit - 24 jam). Contoh: \"2 jam 30 menit\".";
            durasiMenit = durasiHasil.Value;
            txtDurasi.Text = ToDurasiText(durasiMenit); // tampilkan bentuk baku

            // --- Harga: minimal 1 (float NOT NULL, sesuai spek) ---
            harga = Convert.ToDouble(numHarga.Value);
            if (harga < 1)
                return "Harga per tiket minimal Rp 1.";
            if (harga > 100000000)
                return "Harga per tiket maksimal Rp 100.000.000.";

            // --- Cek FK ke database + duplikat kode (kecuali data yg sedang diedit) ---
            try
            {
                int cekDari = dariId, cekKe = keId, cekMaskapai = maskapaiId;
                string kodeCek = kode;
                int? editId = _editingId;
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (!db.Bandara.Any(b => b.ID == cekDari))
                        return "Bandara keberangkatan tidak terdaftar di database.";
                    if (!db.Bandara.Any(b => b.ID == cekKe))
                        return "Bandara tujuan tidak terdaftar di database.";
                    if (!db.Maskapai.Any(m => m.ID == cekMaskapai))
                        return "Maskapai tidak terdaftar di database.";

                    bool duplikat = editId.HasValue
                        ? db.JadwalPenerbangan.Any(j => j.KodePenerbangan == kodeCek && j.ID != editId.Value)
                        : db.JadwalPenerbangan.Any(j => j.KodePenerbangan == kodeCek);
                    if (duplikat)
                        return "Kode penerbangan \"" + kodeCek + "\" sudah terdaftar. Gunakan kode lain.";
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
            txtKode.Clear();
            txtWaktu.Text = "00:00";
            txtDurasi.Clear();
            dtpTanggal.Value = DateTime.Today;
            numHarga.Value = numHarga.Minimum;
            if (cmbDari.DataSource != null) cmbDari.SelectedIndex = -1;
            if (cmbKe.DataSource != null) cmbKe.SelectedIndex = -1;
            if (cmbMaskapaiInput.DataSource != null) cmbMaskapaiInput.SelectedIndex = -1;
            btnSimpan.Text = "Simpan";
            dgvJadwal.ClearSelection();
            txtKode.Focus();
        }

        #endregion

        #region Simpan / Batal

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            int dariId, keId, maskapaiId, durasiMenit;
            DateTime berangkat;
            double harga;
            string error = ValidasiInput(out dariId, out keId, out maskapaiId,
                out berangkat, out durasiMenit, out harga);
            if (error != null)
            {
                MessageBox.Show(error, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string kode = txtKode.Text.Trim().ToUpper().Replace(" ", "");

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    if (_editingId.HasValue)
                    {
                        // --- UPDATE ---
                        JadwalPenerbangan ent = db.JadwalPenerbangan.Find(_editingId.Value);
                        if (ent == null)
                        {
                            MessageBox.Show("Data jadwal tidak ditemukan (mungkin sudah dihapus).",
                                "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            MuatJadwal();
                            ResetForm();
                            return;
                        }

                        ent.KodePenerbangan = kode;
                        ent.BandaraKeberangkatanID = dariId;
                        ent.BandaraTujuanID = keId;
                        ent.MaskapaiID = maskapaiId;
                        ent.TanggalWaktuKeberangkatan = berangkat;
                        ent.DurasiPenerbangan = durasiMenit;
                        ent.HargaPerTiket = harga;

                        db.SaveChanges();
                        MessageBox.Show("Jadwal penerbangan berhasil diperbarui.", "Ubah",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // --- INSERT ---
                        JadwalPenerbangan baru = new JadwalPenerbangan
                        {
                            KodePenerbangan = kode,
                            BandaraKeberangkatanID = dariId,
                            BandaraTujuanID = keId,
                            MaskapaiID = maskapaiId,
                            TanggalWaktuKeberangkatan = berangkat,
                            DurasiPenerbangan = durasiMenit,
                            HargaPerTiket = harga
                        };
                        db.JadwalPenerbangan.Add(baru);
                        db.SaveChanges();
                        MessageBox.Show("Jadwal penerbangan berhasil disimpan.", "Simpan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                MuatJadwal();
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

        private void DgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var kolom = dgvJadwal.Columns[e.ColumnIndex];
            object tag = dgvJadwal.Rows[e.RowIndex].Tag;
            if (tag == null || !(tag is int))
                return;
            int id = (int)tag;

            if (kolom.Name == "colUbah")
                MulaiEdit(id);
            else if (kolom.Name == "colHapus")
                HapusJadwal(id);
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
                    JadwalPenerbangan j = db.JadwalPenerbangan.Find(id);
                    if (j == null)
                    {
                        MessageBox.Show("Data jadwal tidak ditemukan (mungkin sudah dihapus).",
                            "Ubah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatJadwal();
                        return;
                    }

                    _editingId = j.ID;
                    txtKode.Text = j.KodePenerbangan;
                    txtDurasi.Text = ToDurasiText(j.DurasiPenerbangan);
                    txtWaktu.Text = j.TanggalWaktuKeberangkatan.ToString("HH:mm");

                    DateTime tanggal = j.TanggalWaktuKeberangkatan.Date;
                    dtpTanggal.Value = tanggal < dtpTanggal.MinDate ? dtpTanggal.MinDate
                        : (tanggal > dtpTanggal.MaxDate ? dtpTanggal.MaxDate : tanggal);
                    numHarga.Value = Math.Max(numHarga.Minimum,
                        Math.Min(numHarga.Maximum, Convert.ToDecimal(j.HargaPerTiket)));

                    try { cmbDari.SelectedValue = j.BandaraKeberangkatanID; }
                    catch { /* biarkan pilihan lama */ }
                    try { cmbKe.SelectedValue = j.BandaraTujuanID; }
                    catch { /* biarkan pilihan lama */ }
                    try { cmbMaskapaiInput.SelectedValue = j.MaskapaiID; }
                    catch { /* biarkan pilihan lama */ }

                    btnSimpan.Text = "Update";
                    txtKode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data jadwal.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hapus jadwal setelah konfirmasi. Ditolak jika sudah ada transaksi
        /// atau riwayat status perubahan.
        /// </summary>
        private void HapusJadwal(int id)
        {
            DialogResult confirm = MessageBox.Show(
                "Hapus jadwal penerbangan ini?\nData yang sudah dihapus tidak dapat dikembalikan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Cegah hapus jika jadwal sudah dipakai transaksi / punya riwayat status.
                    if (db.TransaksiHeader.Any(t => t.JadwalPenerbanganID == id))
                    {
                        MessageBox.Show("Jadwal tidak dapat dihapus karena sudah memiliki " +
                            "data transaksi penjualan tiket.",
                            "Hapus Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (db.PerubahanStatusJadwalPenerbangan.Any(p => p.JadwalPenerbanganID == id))
                    {
                        MessageBox.Show("Jadwal tidak dapat dihapus karena sudah memiliki " +
                            "riwayat perubahan status penerbangan.",
                            "Hapus Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    JadwalPenerbangan ent = db.JadwalPenerbangan.Find(id);
                    if (ent == null)
                    {
                        MessageBox.Show("Data jadwal tidak ditemukan (mungkin sudah dihapus).",
                            "Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatJadwal();
                        return;
                    }

                    db.JadwalPenerbangan.Remove(ent);
                    db.SaveChanges();
                    MessageBox.Show("Jadwal penerbangan berhasil dihapus.", "Hapus",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Jika yg dihapus sedang diedit, kembalikan ke mode tambah.
                if (_editingId.HasValue && _editingId.Value == id)
                    ResetForm();
                else
                    dgvJadwal.ClearSelection();

                MuatJadwal();
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
            // Sudah di Master Jadwal Penerbangan, tidak perlu pindah form.
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
