using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Sederhana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            double angka1, angka2, hasil;

            // TryParse akan mengembalikan nilai true jika berhasil diubah, dan false jika gagal (misal kosong)
            bool isAngka1Valid = double.TryParse(txtAngka1.Text, out angka1);
            bool isAngka2Valid = double.TryParse(txtAngka2.Text, out angka2);

            if (isAngka1Valid && isAngka2Valid)
            {
                hasil = angka1 + angka2;
                lblHasil.Text = hasil.ToString();
            }
            else
            {
                // Jika salah satu TextBox kosong atau bukan angka
                lblHasil.Text = "Input tidak valid!";
                // Atau bisa pakai MessageBox:
                // MessageBox.Show("Harap masukkan angka yang benar pada kedua kolom!", "Peringatan");
            }
        }

        private void btnKurang_Click(object sender, EventArgs e)
        {
            double angka1, angka2, hasil;

            // Validasi input
            bool isAngka1Valid = double.TryParse(txtAngka1.Text, out angka1);
            bool isAngka2Valid = double.TryParse(txtAngka2.Text, out angka2);

            if (isAngka1Valid && isAngka2Valid)
            {
                hasil = angka1 - angka2; // Operasi pengurangan
                lblHasil.Text = hasil.ToString();
            }
            else
            {
                lblHasil.Text = "Input tidak valid!";
            }
        }

        private void btnKali_Click(object sender, EventArgs e)
        {
            double angka1, angka2, hasil;

            // Validasi input
            bool isAngka1Valid = double.TryParse(txtAngka1.Text, out angka1);
            bool isAngka2Valid = double.TryParse(txtAngka2.Text, out angka2);

            if (isAngka1Valid && isAngka2Valid)
            {
                hasil = angka1 * angka2; // Operasi perkalian (pakai bintang)
                lblHasil.Text = hasil.ToString();
            }
            else
            {
                lblHasil.Text = "Input tidak valid!";
            }
        }

        private void btnBagi_Click(object sender, EventArgs e)
        {
            double angka1, angka2, hasil;

            // Validasi input
            bool isAngka1Valid = double.TryParse(txtAngka1.Text, out angka1);
            bool isAngka2Valid = double.TryParse(txtAngka2.Text, out angka2);

            if (isAngka1Valid && isAngka2Valid)
            {
                // PENGAMAN TAMBAHAN: Cek apakah Angka 2 bernilai 0
                if (angka2 == 0)
                {
                    lblHasil.Text = "Tidak bisa bagi dengan 0!";
                }
                else
                {
                    hasil = angka1 / angka2; // Operasi pembagian (pakai garis miring)
                    lblHasil.Text = hasil.ToString();
                }
            }
            else
            {
                lblHasil.Text = "Input tidak valid!";
            }
        }

        private void txtAngka1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Logika: Jika yang ditekan BUKAN angka, DAN BUKAN tombol kontrol (seperti Backspace), 
            // DAN BUKAN titik desimal (.), maka tolak!
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // e.Handled = true artinya "Jangan tampilkan tombol ini di layar"
            }

            // (Opsional) Hanya izinkan satu titik desimal saja
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtAngka2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
