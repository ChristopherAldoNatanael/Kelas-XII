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
    public partial class Form3Dashboard : Form
    {
        private bool logoutClicked = false;
        private bool sidebarExpanded = true;

        public Form3Dashboard()
        {
            InitializeComponent();

            // Navigasi: label + icon bisa diklik
            this.lblNavBandara.Click += new System.EventHandler(this.NavBandara_Click);
            this.picNavBandara.Click += new System.EventHandler(this.NavBandara_Click);
            this.lblNavMaskapai.Click += new System.EventHandler(this.NavMaskapai_Click);
            this.picNavMaskapai.Click += new System.EventHandler(this.NavMaskapai_Click);
            this.lblNavJadwal.Click += new System.EventHandler(this.NavJadwal_Click);
            this.picNavJadwal.Click += new System.EventHandler(this.NavJadwal_Click);
            this.lblNavPromo.Click += new System.EventHandler(this.NavPromo_Click);
            this.picNavPromo.Click += new System.EventHandler(this.NavPromo_Click);
            this.lblNavStatus.Click += new System.EventHandler(this.NavStatus_Click);
            this.picNavStatus.Click += new System.EventHandler(this.NavStatus_Click);

            // Tombol hamburger: kecilkan / lebarkan sidebar
            this.btnMenu.Click += new System.EventHandler(this.BtnMenu_Click);

            // Logout: kembali ke Login Form
            this.lblLogout.Click += new System.EventHandler(this.Logout_Click);
            this.picLogout.Click += new System.EventHandler(this.Logout_Click);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3Dashboard_FormClosed);
        }

        private void SetActiveLabel(Label active)
        {
            Label[] menus = { lblNavBandara, lblNavMaskapai, lblNavJadwal, lblNavPromo, lblNavStatus };
            foreach (Label lbl in menus)
            {
                lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                lbl.ForeColor = Color.Gray;
            }
            active.Font = new Font(active.Font, FontStyle.Bold);
            active.ForeColor = Color.Black;
        }

        private void NavBandara_Click(object sender, EventArgs e)
        {
            // Pola tutorial: tiap master form punya sidebar sendiri (full form),
            // jadi pindah form dengan Hide/Show, BUKAN di-embed ke pnlContent.
            // Kalau di-embed padahal Form4 ada sidebar+topbar sendiri -> tampil double.
            SetActiveLabel(lblNavBandara);
            this.Hide();
            using (Form4Bandara bandara = new Form4Bandara())
            {
                bandara.ShowDialog(this);
                if (bandara.LogoutRequested)
                {
                    logoutClicked = true;
                    this.Close(); // teruskan logout ke Login Form
                    return;
                }
            }
            this.Show();
        }

        private void NavMaskapai_Click(object sender, EventArgs e)
        {
            SetActiveLabel(lblNavMaskapai);
            this.Hide();
            using (Form5Maskapai maskapai = new Form5Maskapai())
            {
                maskapai.ShowDialog(this);
                if (maskapai.LogoutRequested)
                {
                    logoutClicked = true;
                    this.Close(); // teruskan logout ke Login Form
                    return;
                }
            }
            this.Show();
        }

        private void NavJadwal_Click(object sender, EventArgs e)
        {
            SetActiveLabel(lblNavJadwal);
            this.Hide();
            using (Form6JadwalPenerbangan jadwal = new Form6JadwalPenerbangan())
            {
                jadwal.ShowDialog(this);
                if (jadwal.LogoutRequested)
                {
                    logoutClicked = true;
                    this.Close(); // teruskan logout ke Login Form
                    return;
                }
            }
            this.Show();
        }

        private void NavPromo_Click(object sender, EventArgs e)
        {
            SetActiveLabel(lblNavPromo);
            this.Hide();
            using (Form7KodePromo promo = new Form7KodePromo())
            {
                promo.ShowDialog(this);
                if (promo.LogoutRequested)
                {
                    logoutClicked = true;
                    this.Close(); // teruskan logout ke Login Form
                    return;
                }
            }
            this.Show();
        }

        private void NavStatus_Click(object sender, EventArgs e)
        {
            SetActiveLabel(lblNavStatus);
            this.Hide();
            using (Form8UbahStatusPenerbangan status = new Form8UbahStatusPenerbangan())
            {
                status.ShowDialog(this);
                if (status.LogoutRequested)
                {
                    logoutClicked = true;
                    this.Close(); // teruskan logout ke Login Form
                    return;
                }
            }
            this.Show();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            sidebarExpanded = !sidebarExpanded;
            if (sidebarExpanded)
            {
                pnlSidebar.Width = 222;
                pnlContent.Location = new Point(222, 58);
                pnlContent.Width = this.ClientSize.Width - 222;
                foreach (Control c in new Control[] { lblNavBandara, lblNavMaskapai, lblNavJadwal, lblNavPromo, lblNavStatus, lblLogout })
                    c.Visible = true;
            }
            else
            {
                pnlSidebar.Width = 60;
                pnlContent.Location = new Point(60, 58);
                pnlContent.Width = this.ClientSize.Width - 60;
                foreach (Control c in new Control[] { lblNavBandara, lblNavMaskapai, lblNavJadwal, lblNavPromo, lblNavStatus, lblLogout })
                    c.Visible = false;
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            logoutClicked = true;
            this.Close(); // kembali ke Login Form (Form1.Show lagi)
        }

        private void Form3Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Jika ditutup via X (bukan logout), tutup aplikasi.
            if (!logoutClicked)
            {
                Application.Exit();
            }
        }
    }
}
