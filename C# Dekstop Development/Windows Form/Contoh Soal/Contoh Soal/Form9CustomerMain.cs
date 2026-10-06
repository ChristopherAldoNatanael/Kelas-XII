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
    public partial class Form9CustomerMain : Form
    {
        // True jika user klik Logout (minta kembali ke Login Form),
        // False jika form ditutup via X (tutup aplikasi).
        public bool LogoutRequested { get; private set; } = false;

        public Form9CustomerMain()
        {
            InitializeComponent();

            this.picTiket.Click += new System.EventHandler(this.Tiket_Click);
            this.picLogout.Click += new System.EventHandler(this.Logout_Click);
            this.btnCari.Click += new System.EventHandler(this.Cari_Click);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form9CustomerMain_FormClosed);
        }

        private void Cari_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form10ListPenerbangan list = new Form10ListPenerbangan())
            {
                list.ShowDialog(this);
            }
            this.Show();
        }

        private void Tiket_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form12TiketSaya tiket = new Form12TiketSaya())
            {
                tiket.ShowDialog(this);
            }
            this.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogoutRequested = true;
            this.Close(); // kembali ke Login Form
        }

        private void Form9CustomerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Jika ditutup via X (bukan logout), tutup aplikasi.
            if (!LogoutRequested)
            {
                Application.Exit();
            }
        }
    }
}
