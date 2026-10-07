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
    public partial class Form8UbahStatusPenerbangan : Form
    {
        // True jika user klik Logout (minta kembali ke Login),
        // False jika form ditutup via X (kembali ke form sebelumnya).
        public bool LogoutRequested { get; private set; } = false;
        private bool sidebarExpanded = true;

        // ID Jadwal yang sedang diubah statusnya. Null = panel tutup / belum pilih.
        private int? _jadwalId = null;
        private string _kodeDipilih = "";

        public Form8UbahStatusPenerbangan()
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

            // --- Logic Ubah Status (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form8UbahStatusPenerbangan_Load);
            this.dgvStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStatus_CellContentClick);
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            this.btnSimpan.Click += new System.EventHandler(this.BtnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.BtnBatal_Click);
        }

        #region Load & Tampil Data

        private void Form8UbahStatusPenerbangan_Load(object sender, EventArgs e)
        {
            // Perkiraan delay dalam menit (kolom nullable int): 5 - 1440.
            txtPerkiraan.MaxLength = 4;

            MuatStatus();
            MuatJadwal();
            SembunyikanPanel();
        }

        /// <summary>
        /// Isi ComboBox status dari tabel StatusPenerbangan (menggantikan
        /// item hardcode agar status baru di database ikut muncul).
        /// </summary>
        private void MuatStatus()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var daftar = db.StatusPenerbangan
                        .OrderBy(s => s.Nama)
                        .Select(s => new { s.ID, s.Nama })
                        .ToList();

                    cmbStatus.DataSource = daftar;
                    cmbStatus.DisplayMember = "Nama";
                    cmbStatus.ValueMember = "ID";
                    cmbStatus.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data status dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ubah menit menjadi teks "XX jam YY menit" sesuai format spek.
        /// </summary>
        private static string ToDurasiText(int totalMenit)
        {
            return (totalMenit / 60) + " jam " + (totalMenit % 60) + " menit";
        }

        /// <summary>
        /// Isi grid dengan SEMUA jadwal + status terakhirnya.
        /// Status diambil dari riwayat terbaru; tanpa riwayat = "Sesuai Jadwal".
        /// Delay ditampilkan "Delay (selama ±XX jam YY menit)" sesuai spek.
        /// TerakhirDiubah format "dd-MM-yyyy HH:mm:ss" sesuai spek.
        /// ID jadwal disimpan di Row.Tag agar kolom UI tidak berubah.
        /// Riwayat bersifat append-only (tanpa hapus) sesuai kaidah data historis.
        /// </summary>
        private void MuatJadwal()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    var jadwal = db.JadwalPenerbangan
                        .OrderBy(j => j.TanggalWaktuKeberangkatan)
                        .Select(j => new
                        {
                            j.ID,
                            j.KodePenerbangan,
                            j.MaskapaiID,
                            j.BandaraKeberangkatanID,
                            j.BandaraTujuanID,
                            j.TanggalWaktuKeberangkatan,
                            j.DurasiPenerbangan
                        })
                        .ToList();

                    var bandara = db.Bandara
                        .Select(b => new { b.ID, b.KodeIATA })
                        .ToList()
                        .ToDictionary(b => b.ID, b => b.KodeIATA);
                    var maskapai = db.Maskapai
                        .Select(m => new { m.ID, m.Nama })
                        .ToList()
                        .ToDictionary(m => m.ID, m => m.Nama);

                    var riwayat = db.PerubahanStatusJadwalPenerbangan
                        .Select(p => new
                        {
                            p.JadwalPenerbanganID,
                            p.WaktuPerubahanTerjadi,
                            NamaStatus = p.StatusPenerbangan.Nama,
                            p.PerkiraanDurasiDelay
                        })
                        .ToList();
                    var terakhir = riwayat
                        .GroupBy(p => p.JadwalPenerbanganID)
                        .ToDictionary(
                            g => g.Key,
                            g => g.OrderByDescending(p => p.WaktuPerubahanTerjadi).First());

                    dgvStatus.Rows.Clear();
                    foreach (var j in jadwal)
                    {
                        DateTime berangkat = j.TanggalWaktuKeberangkatan;
                        string status = "Sesuai Jadwal";
                        string diubah = "-";
                        if (terakhir.ContainsKey(j.ID))
                        {
                            var t = terakhir[j.ID];
                            status = t.NamaStatus;
                            if (string.Equals(t.NamaStatus, "Delay", StringComparison.OrdinalIgnoreCase)
                                && t.PerkiraanDurasiDelay.HasValue)
                            {
                                status = "Delay (selama ±" + ToDurasiText(t.PerkiraanDurasiDelay.Value) + ")";
                            }
                            diubah = t.WaktuPerubahanTerjadi.ToString("dd-MM-yyyy HH:mm:ss");
                        }

                        int rowIndex = dgvStatus.Rows.Add(
                            j.KodePenerbangan,
                            maskapai.ContainsKey(j.MaskapaiID) ? maskapai[j.MaskapaiID] : "-",
                            bandara.ContainsKey(j.BandaraKeberangkatanID) ? bandara[j.BandaraKeberangkatanID] : "-",
                            bandara.ContainsKey(j.BandaraTujuanID) ? bandara[j.BandaraTujuanID] : "-",
                            berangkat.ToString("dd-MM-yyyy"),
                            berangkat.ToString("HH:mm"),
                            ToDurasiText(j.DurasiPenerbangan),
                            status,
                            diubah
                        );
                        dgvStatus.Rows[rowIndex].Tag = j.ID;
                    }
                    dgvStatus.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat jadwal penerbangan dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Panel Ubah (pilih jadwal, simpan riwayat)

        /// <summary>
        /// Panel hanya dibuka lewat tombol Ubah; kolom Perkiraan Delay hanya
        /// relevan (dan wajib) saat status yang dipilih adalah Delay.
        /// </summary>
        private void DgvStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvStatus.Columns[e.ColumnIndex].Name != "colUbah")
                return;

            object tag = dgvStatus.Rows[e.RowIndex].Tag;
            if (tag == null || !(tag is int))
                return;

            _jadwalId = (int)tag;
            _kodeDipilih = Convert.ToString(dgvStatus.Rows[e.RowIndex].Cells["colKode"].Value);
            pnlStatus.Visible = true;
            if (cmbStatus.DataSource != null)
                cmbStatus.SelectedIndex = -1;
            txtPerkiraan.Clear();
            AturVisibilitasPerkiraan();
            cmbStatus.Focus();
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            AturVisibilitasPerkiraan();
        }

        private void AturVisibilitasPerkiraan()
        {
            bool isDelay = string.Equals(cmbStatus.Text, "Delay", StringComparison.OrdinalIgnoreCase);
            lblPerkiraan.Visible = isDelay;
            txtPerkiraan.Visible = isDelay;
            if (!isDelay)
                txtPerkiraan.Clear();
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            SembunyikanPanel();
        }

        private void SembunyikanPanel()
        {
            _jadwalId = null;
            _kodeDipilih = "";
            pnlStatus.Visible = false;
            if (cmbStatus.DataSource != null)
                cmbStatus.SelectedIndex = -1;
            txtPerkiraan.Clear();
            AturVisibilitasPerkiraan();
            dgvStatus.ClearSelection();
        }

        /// <summary>
        /// Simpan perubahan sebagai baris riwayat BARU (append-only).
        /// Validasi: jadwal terpilih, status terdaftar, perkiraan delay wajib
        /// angka menit 5-1440 khusus untuk Delay (selain itu disimpan NULL).
        /// </summary>
        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (!_jadwalId.HasValue)
            {
                MessageBox.Show("Pilih jadwal dulu lewat tombol Ubah pada daftar.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedValue == null || !int.TryParse(cmbStatus.SelectedValue.ToString(), out int statusId))
            {
                MessageBox.Show("Status wajib dipilih.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            bool isDelay = string.Equals(cmbStatus.Text, "Delay", StringComparison.OrdinalIgnoreCase);
            string perkiraanText = (txtPerkiraan.Text ?? "").Trim().Replace(" ", "");
            int? perkiraan = null;
            if (isDelay)
            {
                if (string.IsNullOrWhiteSpace(perkiraanText))
                {
                    MessageBox.Show("Perkiraan durasi delay wajib diisi untuk status Delay (dalam menit).",
                        "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPerkiraan.Focus();
                    return;
                }
                int angka;
                if (!Regex.IsMatch(perkiraanText, @"^\d+$") || !int.TryParse(perkiraanText, out angka))
                {
                    MessageBox.Show("Perkiraan durasi delay \"" + txtPerkiraan.Text.Trim() +
                        "\" tidak valid. Isi angka menit saja (contoh: 45).",
                        "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPerkiraan.Focus();
                    return;
                }
                if (angka < 5 || angka > 1440)
                {
                    MessageBox.Show("Perkiraan durasi delay harus antara 5 sampai 1440 menit.",
                        "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPerkiraan.Focus();
                    return;
                }
                perkiraan = angka;
            }

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    int jadwalId = _jadwalId.Value;
                    JadwalPenerbangan j = db.JadwalPenerbangan.Find(jadwalId);
                    if (j == null)
                    {
                        MessageBox.Show("Jadwal tidak ditemukan (mungkin sudah dihapus).",
                            "Ubah Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatJadwal();
                        SembunyikanPanel();
                        return;
                    }

                    StatusPenerbangan st = db.StatusPenerbangan.Find(statusId);
                    if (st == null)
                    {
                        MessageBox.Show("Status tidak terdaftar di database.",
                            "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MuatStatus();
                        return;
                    }

                    // Cegah dobel-klik tak sengaja: status sama beruntun perlu konfirmasi.
                    string statusTerakhir = db.PerubahanStatusJadwalPenerbangan
                        .Where(p => p.JadwalPenerbanganID == jadwalId)
                        .OrderByDescending(p => p.WaktuPerubahanTerjadi)
                        .Select(p => p.StatusPenerbangan.Nama)
                        .FirstOrDefault();
                    if (string.Equals(statusTerakhir, st.Nama, StringComparison.OrdinalIgnoreCase))
                    {
                        DialogResult ulang = MessageBox.Show(
                            "Status terakhir penerbangan " + j.KodePenerbangan +
                            " sudah \"" + st.Nama + "\".\nTetap simpan sebagai riwayat baru?",
                            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ulang != DialogResult.Yes)
                            return;
                    }

                    db.PerubahanStatusJadwalPenerbangan.Add(new PerubahanStatusJadwalPenerbangan
                    {
                        JadwalPenerbanganID = jadwalId,
                        StatusPenerbanganID = st.ID,
                        WaktuPerubahanTerjadi = DateTime.Now,
                        PerkiraanDurasiDelay = perkiraan
                    });
                    db.SaveChanges();

                    MessageBox.Show("Status penerbangan " + j.KodePenerbangan +
                        " berhasil diubah menjadi \"" + st.Nama + "\".",
                        "Ubah Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MuatJadwal();
                SembunyikanPanel();
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
            // Sudah di Ubah Status Penerbangan, tidak perlu pindah form.
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
