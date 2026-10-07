using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoh_Soal
{
    public partial class Form10ListPenerbangan : Form
    {
        public Form10ListPenerbangan()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);
            this.btnFilter.Click += new System.EventHandler(this.Filter_Click);
            this.dgvJadwal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJadwal_CellContentClick);

            // --- Logic List Penerbangan (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form10ListPenerbangan_Load);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke Customer Main Form
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            MuatJadwal();
        }

        #region Kriteria Pencarian (diisi dari Customer Main, backend only)

        // Kriteria pencarian aktif dari Customer Main.
        private int _dariId = 0;
        private int _tujuanId = 0;
        private DateTime _tanggal = DateTime.Today;
        private int _penumpang = 1;
        private int _akunId = 0;
        private string _dariTxt = "?";
        private string _keTxt = "?";

        public int CariDariId { get { return _dariId; } }
        public int CariTujuanId { get { return _tujuanId; } }
        public DateTime CariTanggal { get { return _tanggal; } }
        public int CariPenumpang { get { return _penumpang; } }
        public int CariAkunId { get { return _akunId; } }

        /// <summary>
        /// Terima kriteria pencarian dari Customer Main dan tampilkan ringkasannya.
        /// </summary>
        public void SetKriteria(int dariId, int tujuanId, DateTime tanggal, int penumpang, int akunId)
        {
            _dariId = dariId;
            _tujuanId = tujuanId;
            _tanggal = tanggal.Date;
            _penumpang = penumpang;
            _akunId = akunId;

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    Bandara dari = db.Bandara.Find(dariId);
                    Bandara ke = db.Bandara.Find(tujuanId);
                    string dariTxt = dari != null ? dari.Nama + " (" + dari.KodeIATA + ")" : "?";
                    string keTxt = ke != null ? ke.Nama + " (" + ke.KodeIATA + ")" : "?";
                    lblParam.Text = dariTxt + "  →  " + keTxt
                        + "   •   " + _tanggal.ToString("ddd, dd MMM yyyy")
                        + "   •   " + _penumpang + " Penumpang";
                    _dariTxt = dariTxt;
                    _keTxt = keTxt;
                }
            }
            catch
            {
                // Biarkan teks bawaan designer jika database tidak terjangkau.
            }
        }

        #endregion

        #region Daftar & Filter Jadwal

        private void Form10ListPenerbangan_Load(object sender, EventArgs e)
        {
            if (_dariId == 0 || _tujuanId == 0)
            {
                MessageBox.Show("Lakukan pencarian penerbangan terlebih dahulu.", "Pencarian",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            // Bawaan spek: urut harga menaik (termurah paling atas).
            if (cmbUrut.SelectedIndex < 0 && cmbUrut.Items.Count > 0)
                cmbUrut.SelectedIndex = 0;
            MuatJadwal();
        }

        /// <summary>
        /// Cek apakah jam berangkat masuk rentang waktu yang dicentang.
        /// Jika tidak ada yang dicentang, semua jam ditampilkan.
        /// </summary>
        private bool DalamRentangWaktu(DateTime berangkat)
        {
            bool adaFilter = chkWaktu1.Checked || chkWaktu2.Checked
                || chkWaktu3.Checked || chkWaktu4.Checked;
            if (!adaFilter)
                return true;

            int jam = berangkat.Hour;
            if (chkWaktu1.Checked && jam >= 0 && jam < 6) return true;
            if (chkWaktu2.Checked && jam >= 6 && jam < 12) return true;
            if (chkWaktu3.Checked && jam >= 12 && jam < 18) return true;
            if (chkWaktu4.Checked && jam >= 18 && jam < 24) return true;
            return false;
        }

        /// <summary>
        /// Urutkan hasil sesuai pilihan "Urutkan Berdasarkan".
        /// Bawaan (tidak dipilih): keberangkatan paling awal.
        /// </summary>
        private List<JadwalPenerbangan> TerapkanUrutan(List<JadwalPenerbangan> src)
        {
            string urut = cmbUrut.SelectedItem != null ? cmbUrut.SelectedItem.ToString() : "";
            switch (urut)
            {
                case "Harga Terendah":
                    return src.OrderBy(j => j.HargaPerTiket).ToList();
                case "Keberangkatan Paling Awal":
                    return src.OrderBy(j => j.TanggalWaktuKeberangkatan).ToList();
                case "Keberangkatan Paling Akhir":
                    return src.OrderByDescending(j => j.TanggalWaktuKeberangkatan).ToList();
                case "Kedatangan Paling Awal":
                    return src.OrderBy(j => j.TanggalWaktuKeberangkatan.AddMinutes(j.DurasiPenerbangan)).ToList();
                case "Kedatangan Paling Akhir":
                    return src.OrderByDescending(j => j.TanggalWaktuKeberangkatan.AddMinutes(j.DurasiPenerbangan)).ToList();
                case "Durasi Tercepat":
                    return src.OrderBy(j => j.DurasiPenerbangan).ThenBy(j => j.HargaPerTiket).ToList();
                default:
                    // Bawaan spek: harga terendah paling atas.
                    return src.OrderBy(j => j.HargaPerTiket).ToList();
            }
        }

        /// <summary>
        /// Tampilkan jadwal sesuai rute + tanggal (hanya yang belum berangkat),
        /// lalu terapkan filter jam dan urutan. ID disimpan di Row.Tag.
        /// </summary>
        private void MuatJadwal()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    DateTime tgl = _tanggal.Date;
                    DateTime now = DateTime.Now;

                    var daftar = db.JadwalPenerbangan
                        .Where(j => j.BandaraKeberangkatanID == _dariId
                            && j.BandaraTujuanID == _tujuanId
                            && DbFunctions.TruncateTime(j.TanggalWaktuKeberangkatan) == tgl
                            && j.TanggalWaktuKeberangkatan > now)
                        .ToList();

                    var bandara = db.Bandara
                        .Select(b => new { b.ID, b.KodeIATA, b.Nama })
                        .ToList()
                        .ToDictionary(b => b.ID, b => b.Nama + " (" + b.KodeIATA + ")");
                    var maskapai = db.Maskapai
                        .Select(m => new { m.ID, m.Nama })
                        .ToList()
                        .ToDictionary(m => m.ID, m => m.Nama);

                    var tampil = TerapkanUrutan(
                        daftar.Where(j => DalamRentangWaktu(j.TanggalWaktuKeberangkatan)).ToList());

                    dgvJadwal.Rows.Clear();
                    foreach (var j in tampil)
                    {
                        DateTime berangkat = j.TanggalWaktuKeberangkatan;
                        DateTime tiba = berangkat.AddMinutes(j.DurasiPenerbangan);
                        string dari = bandara.ContainsKey(j.BandaraKeberangkatanID)
                            ? bandara[j.BandaraKeberangkatanID] : "-";
                        string ke = bandara.ContainsKey(j.BandaraTujuanID)
                            ? bandara[j.BandaraTujuanID] : "-";
                        string namaMaskapai = maskapai.ContainsKey(j.MaskapaiID)
                            ? maskapai[j.MaskapaiID] : "-";

                        int rowIndex = dgvJadwal.Rows.Add(
                            j.KodePenerbangan,
                            namaMaskapai,
                            dari,
                            ke,
                            "Rp " + Convert.ToDecimal(j.HargaPerTiket).ToString("N0"),
                            berangkat.ToString("dd-MM-yyyy"),
                            berangkat.ToString("HH:mm") + " - " + tiba.ToString("HH:mm")
                        );
                        dgvJadwal.Rows[rowIndex].Tag = j.ID;
                    }
                    dgvJadwal.ClearSelection();

                    if (tampil.Count == 0)
                    {
                        MessageBox.Show("Tidak ada penerbangan " + _dariTxt + "  →  " + _keTxt +
                            "\npada " + _tanggal.ToString("ddd, dd MMM yyyy") + ".\n" +
                            "Coba tanggal lain atau longgarkan filter waktu.",
                            "Pencarian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat daftar penerbangan dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void DgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgvJadwal.Columns[e.ColumnIndex].Name == "colBeli")
            {
                object tag = dgvJadwal.Rows[e.RowIndex].Tag;
                if (tag == null || !(tag is int))
                    return;

                this.Hide();
                using (Form11BeliTiket beli = new Form11BeliTiket())
                {
                    beli.SetData((int)tag, _penumpang, _akunId);
                    beli.ShowDialog(this);
                    if (beli.KonfirmasiBerhasil)
                    {
                        this.Close(); // konfirmasi -> kembali ke Customer Main Form
                        return;
                    }
                }
                this.Show();
            }
        }
    }
}
