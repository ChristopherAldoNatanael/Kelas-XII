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
    public partial class Form12TiketSaya : Form
    {
        public Form12TiketSaya()
        {
            InitializeComponent();

            this.btnKembali.Click += new System.EventHandler(this.Kembali_Click);
        }

        private void Kembali_Click(object sender, EventArgs e)
        {
            this.Close(); // kembali ke Customer Main Form
        }
    }
}
