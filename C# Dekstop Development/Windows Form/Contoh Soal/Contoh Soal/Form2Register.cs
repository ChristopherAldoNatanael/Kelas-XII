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
            this.txtNomorTelepon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomorTelepon_KeyPress);
        }

        private void BtnDaftar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string nama = txtNama.Text.Trim();
            string telepon = txtNomorTelepon.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || nama == "" || telepon == "" || password == "")
            {
                MessageBox.Show("Semua field wajib diisi.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long nomor;
            if (!long.TryParse(telepon, out nomor))
            {
                MessageBox.Show("Nomor telepon hanya boleh berisi angka.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (telepon.Length < 10 || telepon.Length > 15)
            {
                MessageBox.Show("Nomor telepon harus berjumlah 10-15 digit.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal harus berjumlah 8 karakter.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Akun akunBaru;
            try
            {
                using (BandaraEntities db = new BandaraEntities())
                {
                    bool dipakai = db.Akun.Any(a => a.Username == username);
                    if (dipakai)
                    {
                        MessageBox.Show("Username sudah dipakai. Gunakan username lain.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    akunBaru = new Akun
                    {
                        Username = username,
                        Password = password,
                        Nama = nama,
                        TanggalLahir = dtpTanggalLahir.Value.Date,
                        NomorTelepon = telepon,
                        MerupakanAdmin = false
                    };
                    db.Akun.Add(akunBaru);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan ke database.\n" + ex.Message, "Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Akun berhasil didaftarkan! Selamat datang, " + akunBaru.Nama + ".", "Bromo Airlines",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Sesuai spek: langsung masuk ke Customer Main Form (tanpa login ulang).
            this.Hide();
            using (Form9CustomerMain cust = new Form9CustomerMain())
            {
                cust.SetLoggedInUser(akunBaru.ID, akunBaru.Nama);
                cust.ShowDialog(this);
            }
            this.Close();
        }

        private void LnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Kembali ke login (form login otomatis tampil lagi).
            this.Close();
        }

        private void TxtNomorTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya angka dan tombol kontrol (backspace, delete, dll.) yang boleh diketik.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2Register_Load(object sender, EventArgs e)
        {

        }
    }
}
