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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.lnkDaftar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkDaftar_LinkClicked);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Sederhana: sembunyikan login, buka dashboard secara modal.
            // Saat dashboard ditutup (logout/X), login tampil lagi otomatis.
            this.Hide();
            using (Form3Dashboard dash = new Form3Dashboard())
            {
                dash.ShowDialog(this);
            }
            this.Show();
        }

        private void LnkDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (Form2Register reg = new Form2Register())
            {
                reg.ShowDialog(this);
            }
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
