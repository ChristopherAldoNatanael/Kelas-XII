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
    public partial class Form10ListPenerbangan : Form
    {
        public Form10ListPenerbangan()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);
            this.btnFilter.Click += new System.EventHandler(this.Filter_Click);
            this.dgvJadwal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvJadwal_CellContentClick);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke Customer Main Form
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            // Design only: penerapan filter mengikuti saat CRUD diimplementasikan.
        }

        private void DgvJadwal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgvJadwal.Columns[e.ColumnIndex].Name == "colBeli")
            {
                this.Hide();
                using (Form11BeliTiket beli = new Form11BeliTiket())
                {
                    beli.ShowDialog(this);
                    if (beli.KonfirmasiBerhasil)
                    {
                        this.Close(); // konfirmasi -> kembali ke Customer Main Form
                        return;
                    }
                }
                this.Show();
            }
        }
    }
}
