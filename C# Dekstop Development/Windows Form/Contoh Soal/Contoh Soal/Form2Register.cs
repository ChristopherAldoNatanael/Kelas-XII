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
    public partial class Form2Register : Form
    {
        public Form2Register()
        {
            InitializeComponent();
            this.btnDaftar.Click += new System.EventHandler(this.BtnDaftar_Click);
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLogin_LinkClicked);
        }

        private void BtnDaftar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Akun berhasil didaftarkan!", "Bromo Airlines",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lanjut ke dashboard, lalu tutup form register saat dashboard ditutup.
            this.Hide();
            using (Form3Dashboard dash = new Form3Dashboard())
            {
                dash.ShowDialog(this);
            }
            this.Close();
        }

        private void LnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Kembali ke login (form login otomatis tampil lagi).
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2Register_Load(object sender, EventArgs e)
        {

        }
    }
}
