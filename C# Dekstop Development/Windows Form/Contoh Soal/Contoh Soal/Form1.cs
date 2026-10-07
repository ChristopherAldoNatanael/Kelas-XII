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
            string username = txtUsername.Text.Trim();
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan password wajib diisi.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Akun akun;
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    akun = db.Akun.FirstOrDefault(a => a.Username == username && a.Password == password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal terhubung ke database.\n" + ex.Message, "Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (akun == null)
            {
                MessageBox.Show("Username atau password salah.", "Login Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sederhana: sembunyikan login, buka form sesuai peran secara modal.
            // Saat form ditutup (logout), login tampil lagi otomatis.
            // Jika form utama ditutup via X, aplikasi ikut tertutup (ditangani masing-masing form).
            this.Hide();
            if (akun.MerupakanAdmin)
            {
                using (Form3Dashboard dash = new Form3Dashboard())
                {
                    dash.ShowDialog(this);
                }
            }
            else
            {
                using (Form9CustomerMain cust = new Form9CustomerMain())
                {
                    cust.SetLoggedInUser(akun.ID, akun.Nama);
                    cust.ShowDialog(this);
                }
            }
            txtUsername.Clear();
            textBox2.Clear();
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
