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
    public partial class Form11BeliTiket : Form
    {
        // True jika pembayaran dikonfirmasi (kembali ke Customer Main Form),
        // False jika kembali/menutup (kembali ke List Penerbangan Form).
        public bool KonfirmasiBerhasil { get; private set; } = false;

        public Form11BeliTiket()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);
            this.btnPakai.Click += new System.EventHandler(this.Pakai_Click);
            this.btnKonfirmasi.Click += new System.EventHandler(this.Konfirmasi_Click);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke List Penerbangan Form
        }

        private void Pakai_Click(object sender, EventArgs e)
        {
            // Design only: validasi kode promo mengikuti saat CRUD diimplementasikan.
        }

        private void Konfirmasi_Click(object sender, EventArgs e)
        {
            // Design only: simpan transaksi mengikuti saat CRUD diimplementasikan.
            KonfirmasiBerhasil = true;
            this.Close(); // kembali ke Customer Main Form (ditangani pemanggil)
        }
    }
}
