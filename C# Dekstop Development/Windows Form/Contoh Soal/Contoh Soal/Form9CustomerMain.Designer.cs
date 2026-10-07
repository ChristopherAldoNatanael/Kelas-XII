namespace Contoh_Soal
{
    partial class Form9CustomerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9CustomerMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picTiket = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.lblHalo = new System.Windows.Forms.Label();
            this.lblSapaan = new System.Windows.Forms.Label();
            this.lblDari = new System.Windows.Forms.Label();
            this.txtDari = new System.Windows.Forms.TextBox();
            this.lblTujuan = new System.Windows.Forms.Label();
            this.txtTujuan = new System.Windows.Forms.TextBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblPenumpang = new System.Windows.Forms.Label();
            this.numPenumpang = new System.Windows.Forms.NumericUpDown();
            this.btnCari = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPenumpang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(94)))), ((int)(((byte)(164)))));
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Controls.Add(this.picTiket);
            this.pnlTop.Controls.Add(this.picLogout);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 100);
            this.pnlTop.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::Contoh_Soal.Properties.Resources.Logo_Alt___Without_Padding1;
            this.picLogo.Location = new System.Drawing.Point(20, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(300, 76);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // picTiket
            // 
            this.picTiket.BackColor = System.Drawing.Color.Transparent;
            this.picTiket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTiket.Image = global::Contoh_Soal.Properties.Resources.airplane_ticket_nav;
            this.picTiket.Location = new System.Drawing.Point(870, 28);
            this.picTiket.Name = "picTiket";
            this.picTiket.Size = new System.Drawing.Size(45, 45);
            this.picTiket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTiket.TabIndex = 1;
            this.picTiket.TabStop = false;
            // 
            // picLogout
            // 
            this.picLogout.BackColor = System.Drawing.Color.Transparent;
            this.picLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogout.Image = global::Contoh_Soal.Properties.Resources.log_out_alt_72;
            this.picLogout.Location = new System.Drawing.Point(930, 28);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(45, 45);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogout.TabIndex = 2;
            this.picLogout.TabStop = false;
            // 
            // lblHalo
            // 
            this.lblHalo.AutoSize = true;
            this.lblHalo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalo.Location = new System.Drawing.Point(28, 115);
            this.lblHalo.Name = "lblHalo";
            this.lblHalo.Size = new System.Drawing.Size(124, 54);
            this.lblHalo.TabIndex = 1;
            this.lblHalo.Text = "Halo!";
            // 
            // lblSapaan
            // 
            this.lblSapaan.AutoSize = true;
            this.lblSapaan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSapaan.Location = new System.Drawing.Point(34, 170);
            this.lblSapaan.Name = "lblSapaan";
            this.lblSapaan.Size = new System.Drawing.Size(399, 28);
            this.lblSapaan.TabIndex = 2;
            this.lblSapaan.Text = "Mau terbang ke mana hari ini, [Nama Akun]?";
            // 
            // lblDari
            // 
            this.lblDari.AutoSize = true;
            this.lblDari.Location = new System.Drawing.Point(34, 220);
            this.lblDari.Name = "lblDari";
            this.lblDari.Size = new System.Drawing.Size(128, 25);
            this.lblDari.TabIndex = 3;
            this.lblDari.Text = "Berangkat Dari";
            // 
            // txtDari
            // 
            this.txtDari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDari.Location = new System.Drawing.Point(38, 250);
            this.txtDari.Name = "txtDari";
            this.txtDari.Size = new System.Drawing.Size(380, 31);
            this.txtDari.TabIndex = 4;
            // 
            // lblTujuan
            // 
            this.lblTujuan.AutoSize = true;
            this.lblTujuan.Location = new System.Drawing.Point(520, 220);
            this.lblTujuan.Name = "lblTujuan";
            this.lblTujuan.Size = new System.Drawing.Size(64, 25);
            this.lblTujuan.TabIndex = 5;
            this.lblTujuan.Text = "Tujuan";
            // 
            // txtTujuan
            // 
            this.txtTujuan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTujuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTujuan.Location = new System.Drawing.Point(524, 250);
            this.txtTujuan.Name = "txtTujuan";
            this.txtTujuan.Size = new System.Drawing.Size(380, 31);
            this.txtTujuan.TabIndex = 6;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(34, 305);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(157, 25);
            this.lblTanggal.TabIndex = 7;
            this.lblTanggal.Text = "Tanggal Berangkat";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(38, 335);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(380, 31);
            this.dtpTanggal.TabIndex = 8;
            // 
            // lblPenumpang
            // 
            this.lblPenumpang.AutoSize = true;
            this.lblPenumpang.Location = new System.Drawing.Point(520, 305);
            this.lblPenumpang.Name = "lblPenumpang";
            this.lblPenumpang.Size = new System.Drawing.Size(167, 25);
            this.lblPenumpang.TabIndex = 9;
            this.lblPenumpang.Text = "Jumlah Penumpang";
            // 
            // numPenumpang
            // 
            this.numPenumpang.Location = new System.Drawing.Point(524, 335);
            this.numPenumpang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPenumpang.Name = "numPenumpang";
            this.numPenumpang.Size = new System.Drawing.Size(380, 31);
            this.numPenumpang.TabIndex = 10;
            this.numPenumpang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCari
            // 
            this.btnCari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCari.Location = new System.Drawing.Point(38, 400);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(200, 45);
            this.btnCari.TabIndex = 11;
            this.btnCari.Text = "Cari Penerbangan";
            this.btnCari.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Contoh_Soal.Properties.Resources.mountain;
            this.pictureBox1.Location = new System.Drawing.Point(742, 372);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 228);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form9CustomerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.numPenumpang);
            this.Controls.Add(this.lblPenumpang);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.txtTujuan);
            this.Controls.Add(this.lblTujuan);
            this.Controls.Add(this.txtDari);
            this.Controls.Add(this.lblDari);
            this.Controls.Add(this.lblSapaan);
            this.Controls.Add(this.lblHalo);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form9CustomerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Customer";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPenumpang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picTiket;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Label lblHalo;
        private System.Windows.Forms.Label lblSapaan;
        private System.Windows.Forms.Label lblDari;
        private System.Windows.Forms.TextBox txtDari;
        private System.Windows.Forms.Label lblTujuan;
        private System.Windows.Forms.TextBox txtTujuan;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label lblPenumpang;
        private System.Windows.Forms.NumericUpDown numPenumpang;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
