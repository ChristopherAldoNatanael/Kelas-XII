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
    public partial class Form12TiketSaya : Form
    {
        /// <summary>
        /// ID akun customer yang sedang login (diisi dari Customer Main).
        /// </summary>
        public int AkunId { get; set; } = 0;

        public Form12TiketSaya()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);

            // --- Logic Tiket Saya (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form12TiketSaya_Load);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke Customer Main Form
        }

        private void Form12TiketSaya_Load(object sender, EventArgs e)
        {
            if (AkunId == 0)
            {
                MessageBox.Show("Sesi login tidak valid. Silakan login ulang.",
                    "Tiket Saya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            MuatTiket();
        }

        /// <summary>
        /// Ubah menit menjadi teks "XX jam YY menit" sesuai format spek.
        /// </summary>
        private static string ToDurasiText(int totalMenit)
        {
            return (totalMenit / 60) + " jam " + (totalMenit % 60) + " menit";
        }

        /// <summary>
        /// Tampilkan semua tiket milik user beserta status penerbangan terakhirnya.
        /// Status diambil dari riwayat perubahan terbaru; jika belum ada riwayat,
        /// ditampilkan "Sesuai Jadwal". Delay ditampilkan
        /// "Delay (selama ±XX jam YY menit)". ID transaksi disimpan di Row.Tag.
        /// </summary>
        private void MuatTiket()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    int akunId = AkunId;
                    var tiket = db.TransaksiHeader
                        .Where(t => t.AkunID == akunId)
                        .OrderBy(t => t.JadwalPenerbangan.TanggalWaktuKeberangkatan)
                        .Select(t => new
                        {
                            TransaksiID = t.ID,
                            Kode = t.JadwalPenerbangan.KodePenerbangan,
                            Berangkat = t.JadwalPenerbangan.TanggalWaktuKeberangkatan,
                            Durasi = t.JadwalPenerbangan.DurasiPenerbangan,
                            DariID = t.JadwalPenerbangan.BandaraKeberangkatanID,
                            KeID = t.JadwalPenerbangan.BandaraTujuanID,
                            MaskapaiID = t.JadwalPenerbangan.MaskapaiID,
                            JadwalID = t.JadwalPenerbanganID,
                            Jumlah = t.JumlahPenumpang
                        })
                        .ToList();

                    var bandara = db.Bandara
                        .Select(b => new { b.ID, b.KodeIATA, b.Nama })
                        .ToList()
                        .ToDictionary(b => b.ID, b => b.Nama + " (" + b.KodeIATA + ")");
                    var maskapai = db.Maskapai
                        .Select(m => new { m.ID, m.Nama })
                        .ToList()
                        .ToDictionary(m => m.ID, m => m.Nama);

                    // Status terakhir per jadwal (dari riwayat perubahan terbaru).
                    var riwayat = db.PerubahanStatusJadwalPenerbangan
                        .Select(p => new
                        {
                            p.JadwalPenerbanganID,
                            p.WaktuPerubahanTerjadi,
                            NamaStatus = p.StatusPenerbangan.Nama,
                            p.PerkiraanDurasiDelay
                        })
                        .ToList();
                    var statusTerakhir = riwayat
                        .GroupBy(p => p.JadwalPenerbanganID)
                        .ToDictionary(
                            g => g.Key,
                            g => g.OrderByDescending(p => p.WaktuPerubahanTerjadi).First());

                    dgvTiket.Rows.Clear();
                    // Spek: hanya tiket yang MASIH AKTIF = penerbangan belum berangkat
                    // dan status terakhirnya bukan "Dibatalkan".
                    DateTime sekarang = DateTime.Now;
                    var aktif = tiket
                        .Where(t => t.Berangkat > sekarang
                            && !(statusTerakhir.ContainsKey(t.JadwalID)
                                && string.Equals(statusTerakhir[t.JadwalID].NamaStatus,
                                    "Dibatalkan", StringComparison.OrdinalIgnoreCase)))
                        .ToList();
                    foreach (var t in aktif)
                    {
                        DateTime tiba = t.Berangkat.AddMinutes(t.Durasi);
                        string dari = bandara.ContainsKey(t.DariID) ? bandara[t.DariID] : "-";
                        string ke = bandara.ContainsKey(t.KeID) ? bandara[t.KeID] : "-";
                        string namaMaskapai = maskapai.ContainsKey(t.MaskapaiID) ? maskapai[t.MaskapaiID] : "-";
                        string status = "Sesuai Jadwal";
                        if (statusTerakhir.ContainsKey(t.JadwalID))
                        {
                            var st = statusTerakhir[t.JadwalID];
                            status = st.NamaStatus;
                            if (string.Equals(st.NamaStatus, "Delay", StringComparison.OrdinalIgnoreCase)
                                && st.PerkiraanDurasiDelay.HasValue)
                            {
                                status = "Delay (selama ±" + ToDurasiText(st.PerkiraanDurasiDelay.Value) + ")";
                            }
                        }

                        int rowIndex = dgvTiket.Rows.Add(
                            t.Kode,
                            namaMaskapai,
                            dari,
                            ke,
                            t.Berangkat.ToString("dd-MM-yyyy"),
                            t.Berangkat.ToString("HH:mm") + " - " + tiba.ToString("HH:mm"),
                            status + " (" + t.Jumlah + " pnp)"
                        );
                        dgvTiket.Rows[rowIndex].Tag = t.TransaksiID;
                    }
                    dgvTiket.ClearSelection();

                    if (aktif.Count == 0)
                    {
                        MessageBox.Show("Belum ada tiket aktif. Yuk cari penerbangan dan pesan tiket pertamamu!",
                            "Tiket Saya", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tiket dari database.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
