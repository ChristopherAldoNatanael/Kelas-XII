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
    public partial class Form11BeliTiket : Form
    {
        // True jika pembayaran dikonfirmasi (kembali ke Customer Main Form),
        // False jika kembali/menutup (kembali ke List Penerbangan Form).
        public bool KonfirmasiBerhasil { get; private set; } = false;

        // Konteks pembelian (diisi dari List Penerbangan).
        private int _jadwalId = 0;
        private int _penumpang = 1;
        private int _akunId = 0;

        public int BeliJadwalId { get { return _jadwalId; } }
        public int BeliPenumpang { get { return _penumpang; } }
        public int BeliAkunId { get { return _akunId; } }

        /// <summary>
        /// Terima konteks pembelian dari List Penerbangan.
        /// </summary>
        public void SetData(int jadwalId, int penumpang, int akunId)
        {
            _jadwalId = jadwalId;
            _penumpang = penumpang < 1 ? 1 : (penumpang > 3 ? 3 : penumpang);
            _akunId = akunId;
        }

        // State harga & promo yang sedang berlaku di form ini.
        private double _hargaPerTiket = 0;
        private int? _promoId = null;
        private double _persenPromo = 0;
        private double _maksPromo = 0;
        private string _kodePromo = "";

        private ComboBox[] _cmbTitel;
        private TextBox[] _txtNama;

        public Form11BeliTiket()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);
            this.btnPakai.Click += new System.EventHandler(this.Pakai_Click);
            this.btnKonfirmasi.Click += new System.EventHandler(this.Konfirmasi_Click);

            _cmbTitel = new ComboBox[] { cmbTitel1, cmbTitel2, cmbTitel3 };
            _txtNama = new TextBox[] { txtNama1, txtNama2, txtNama3 };

            // --- Logic Beli Tiket (backend only, UI tidak diubah) ---
            this.Load += new System.EventHandler(this.Form11BeliTiket_Load);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke List Penerbangan Form
        }

        #region Load & Ringkasan

        private void Form11BeliTiket_Load(object sender, EventArgs e)
        {
            if (_jadwalId == 0 || _akunId == 0)
            {
                MessageBox.Show("Sesi pembelian tidak valid. Ulangi pencarian penerbangan.",
                    "Beli Tiket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            if (!MuatDetail())
                return;

            AturPanelPenumpang();
            HitungTotal();
        }

        /// <summary>
        /// Isi ringkasan penerbangan dari database. Return false jika jadwal
        /// tidak ada / sudah berangkat (form ditutup).
        /// </summary>
        private bool MuatDetail()
        {
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    JadwalPenerbangan j = db.JadwalPenerbangan.Find(_jadwalId);
                    if (j == null)
                    {
                        MessageBox.Show("Jadwal penerbangan tidak ditemukan (mungkin sudah dihapus).",
                            "Beli Tiket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return false;
                    }
                    if (j.TanggalWaktuKeberangkatan <= DateTime.Now)
                    {
                        MessageBox.Show("Penerbangan ini sudah berangkat dan tidak bisa dipesan.",
                            "Beli Tiket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return false;
                    }

                    _hargaPerTiket = j.HargaPerTiket;

                    Bandara dari = db.Bandara.Find(j.BandaraKeberangkatanID);
                    Bandara ke = db.Bandara.Find(j.BandaraTujuanID);
                    Maskapai m = db.Maskapai.Find(j.MaskapaiID);

                    string dariTxt = dari != null ? dari.Nama + " (" + dari.KodeIATA + ")" : "-";
                    string keTxt = ke != null ? ke.Nama + " (" + ke.KodeIATA + ")" : "-";
                    DateTime berangkat = j.TanggalWaktuKeberangkatan;
                    DateTime tiba = berangkat.AddMinutes(j.DurasiPenerbangan);

                    lblPenerbangan.Text = "Penerbangan " + j.KodePenerbangan;
                    lblRute.Text = dariTxt + "  →  " + keTxt;
                    lblMaskapai.Text = m != null ? m.Nama : "-";
                    lblTanggal.Text = berangkat.ToString("dddd, dd MMM yyyy");
                    lblWaktu.Text = berangkat.ToString("HH:mm") + " - " + tiba.ToString("HH:mm");
                    lblJml.Text = _penumpang + " penumpang";
                    txtPromo.Clear();
                    _promoId = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat detail penerbangan.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return false;
            }
        }

        /// <summary>
        /// Tampilkan panel penumpang sesuai jumlah (UI hanya menyediakan 3 panel).
        /// </summary>
        private void AturPanelPenumpang()
        {
            pnlP2.Visible = _penumpang >= 2;
            pnlP3.Visible = _penumpang >= 3;
            for (int i = 0; i < 3; i++)
            {
                _cmbTitel[i].SelectedIndex = 0;
                _txtNama[i].Clear();
            }
            _txtNama[0].MaxLength = 200;
            _txtNama[1].MaxLength = 200;
            _txtNama[2].MaxLength = 200;
        }

        /// <summary>
        /// Hitung subtotal - diskon promo dan tampilkan di lblTotal ("IDR ...").
        /// </summary>
        private void HitungTotal()
        {
            double subtotal = _hargaPerTiket * _penumpang;
            double diskon = 0;
            if (_promoId.HasValue)
            {
                diskon = subtotal * _persenPromo / 100;
                if (diskon > _maksPromo)
                    diskon = _maksPromo;
            }
            double total = subtotal - diskon;
            lblTotal.Text = "IDR " + Convert.ToDecimal(total).ToString("N0");
        }

        #endregion

        #region Kode Promo

        private void Pakai_Click(object sender, EventArgs e)
        {
            string kode = (txtPromo.Text ?? "").Trim().ToUpper().Replace(" ", "");

            // Kotak dikosongkan = lepas promo yang terpasang.
            if (string.IsNullOrWhiteSpace(kode))
            {
                if (_promoId.HasValue)
                {
                    _promoId = null;
                    _kodePromo = "";
                    HitungTotal();
                    MessageBox.Show("Kode promo dilepas.", "Kode Promo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Masukkan kode promo terlebih dahulu.", "Kode Promo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    KodePromo promo = db.KodePromo.FirstOrDefault(k => k.Kode == kode);
                    if (promo == null)
                    {
                        MessageBox.Show("Kode promo \"" + txtPromo.Text.Trim() + "\" tidak ditemukan.",
                            "Kode Promo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (promo.BerlakuSampai.Date < DateTime.Today)
                    {
                        MessageBox.Show("Kode promo \"" + promo.Kode + "\" sudah kedaluwarsa " +
                            "(berlaku sampai " + promo.BerlakuSampai.ToString("dd-MM-yyyy") + ").",
                            "Kode Promo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _promoId = promo.ID;
                    _kodePromo = promo.Kode;
                    _persenPromo = promo.PersentaseDiskon;
                    _maksPromo = promo.MaksimumDiskon;
                    HitungTotal();

                    double subtotal = _hargaPerTiket * _penumpang;
                    double diskon = subtotal * _persenPromo / 100;
                    if (diskon > _maksPromo)
                        diskon = _maksPromo;
                    MessageBox.Show("Promo \"" + promo.Kode + "\" dipakai!\n" +
                        "Diskon " + promo.PersentaseDiskon.ToString("N0") + "% (maks Rp " +
                        Convert.ToDecimal(promo.MaksimumDiskon).ToString("N0") + ").\n" +
                        "Hemat Rp " + Convert.ToDecimal(diskon).ToString("N0") + ".",
                        "Kode Promo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memeriksa kode promo.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Konfirmasi (CREATE Transaksi)

        private class DataPenumpang
        {
            public string Titel;
            public string Nama;
        }

        /// <summary>
        /// Validasi titel + nama semua penumpang. Return null jika valid.
        /// Aturan nama mengikuti hint form: sesuai KTP (tanpa tanda baca/gelar).
        /// </summary>
        private string ValidasiPenumpang(out List<DataPenumpang> daftar)
        {
            daftar = new List<DataPenumpang>();
            for (int i = 0; i < _penumpang; i++)
            {
                string titel = _cmbTitel[i].SelectedItem != null
                    ? _cmbTitel[i].SelectedItem.ToString() : "";
                if (titel != "Tuan" && titel != "Nyonya")
                    return "Pilih titel penumpang #" + (i + 1) + " (Tuan / Nyonya).";

                string nama = (_txtNama[i].Text ?? "").Trim();
                if (string.IsNullOrWhiteSpace(nama))
                    return "Nama lengkap penumpang #" + (i + 1) + " wajib diisi.";
                if (nama.Length < 3)
                    return "Nama penumpang #" + (i + 1) + " minimal 3 karakter.";
                if (nama.Length > 200)
                    return "Nama penumpang #" + (i + 1) + " maksimal 200 karakter.";
                if (!Regex.IsMatch(nama, @"^[A-Za-z\s]+$"))
                    return "Nama penumpang #" + (i + 1) + " hanya boleh huruf dan spasi " +
                        "(sesuai KTP, tanpa tanda baca dan gelar).";

                daftar.Add(new DataPenumpang { Titel = titel, Nama = nama });
            }
            return null;
        }

        private void Konfirmasi_Click(object sender, EventArgs e)
        {
            List<DataPenumpang> daftar;
            string error = ValidasiPenumpang(out daftar);
            if (error != null)
            {
                MessageBox.Show(error, "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    // Cek ulang jadwal (masih ada & belum berangkat).
                    JadwalPenerbangan j = db.JadwalPenerbangan.Find(_jadwalId);
                    if (j == null)
                    {
                        MessageBox.Show("Jadwal penerbangan tidak ditemukan (mungkin sudah dihapus).",
                            "Beli Tiket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (j.TanggalWaktuKeberangkatan <= DateTime.Now)
                    {
                        MessageBox.Show("Penerbangan ini sudah berangkat dan tidak bisa dipesan.",
                            "Beli Tiket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cek ulang promo (masih ada & belum kedaluwarsa).
                    int? promoId = null;
                    double persen = 0, maks = 0;
                    if (_promoId.HasValue)
                    {
                        KodePromo promo = db.KodePromo.Find(_promoId.Value);
                        if (promo == null || promo.BerlakuSampai.Date < DateTime.Today)
                        {
                            MessageBox.Show("Kode promo \"" + _kodePromo + "\" sudah tidak berlaku. " +
                                "Kosongkan kode promo (tombol Pakai) lalu konfirmasi ulang.",
                                "Kode Promo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        promoId = promo.ID;
                        persen = promo.PersentaseDiskon;
                        maks = promo.MaksimumDiskon;
                    }

                    // Hitung ulang dari data database (bukan cache form).
                    double subtotal = j.HargaPerTiket * daftar.Count;
                    double diskon = 0;
                    if (promoId.HasValue)
                    {
                        diskon = subtotal * persen / 100;
                        if (diskon > maks)
                            diskon = maks;
                    }
                    double total = subtotal - diskon;

                    TransaksiHeader header = new TransaksiHeader
                    {
                        AkunID = _akunId,
                        TanggalTransaksi = DateTime.Now,
                        JadwalPenerbanganID = j.ID,
                        JumlahPenumpang = daftar.Count,
                        TotalHarga = total,
                        KodePromoID = promoId
                    };
                    db.TransaksiHeader.Add(header);
                    db.SaveChanges();

                    foreach (var p in daftar)
                    {
                        db.TransaksiDetail.Add(new TransaksiDetail
                        {
                            TransaksiHeaderID = header.ID,
                            TitelPenumpang = p.Titel,
                            NamaLengkapPenumpang = p.Nama
                        });
                    }
                    db.SaveChanges();

                    KonfirmasiBerhasil = true;
                    MessageBox.Show("Pembayaran berhasil! Tiket Anda sudah diterbitkan.\n" +
                        "Total dibayar: IDR " + Convert.ToDecimal(total).ToString("N0") + ".",
                        "Bromo Airlines", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // kembali ke Customer Main Form (ditangani pemanggil)
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
            {
                string msg = dbEx.InnerException != null && dbEx.InnerException.InnerException != null
                    ? dbEx.InnerException.InnerException.Message
                    : dbEx.Message;
                MessageBox.Show("Gagal menyimpan transaksi.\n" + msg,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan transaksi.\n" + ex.Message,
                    "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
