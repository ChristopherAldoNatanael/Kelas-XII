namespace Contoh_Soal
{
    partial class Form10ListPenerbangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10ListPenerbangan));
            this.btnKembali = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblParam = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.lblWaktu = new System.Windows.Forms.Label();
            this.chkWaktu1 = new System.Windows.Forms.CheckBox();
            this.chkWaktu2 = new System.Windows.Forms.CheckBox();
            this.chkWaktu3 = new System.Windows.Forms.CheckBox();
            this.chkWaktu4 = new System.Windows.Forms.CheckBox();
            this.lblUrut = new System.Windows.Forms.Label();
            this.cmbUrut = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.colKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeli = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKembali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKembali.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(20, 15);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(45, 45);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "<";
            this.btnKembali.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(70, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "List Penerbangan";
            // 
            // lblParam
            // 
            this.lblParam.AutoSize = true;
            this.lblParam.Location = new System.Drawing.Point(76, 60);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new System.Drawing.Size(656, 25);
            this.lblParam.TabIndex = 2;
            this.lblParam.Text = "Juanda (SUB)  →  Soekarno-Hatta (CGK)   •   Wed, 24 May 2023   •   1 Penumpang";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblWaktu);
            this.grpFilter.Controls.Add(this.chkWaktu1);
            this.grpFilter.Controls.Add(this.chkWaktu2);
            this.grpFilter.Controls.Add(this.chkWaktu3);
            this.grpFilter.Controls.Add(this.chkWaktu4);
            this.grpFilter.Controls.Add(this.lblUrut);
            this.grpFilter.Controls.Add(this.cmbUrut);
            this.grpFilter.Controls.Add(this.btnFilter);
            this.grpFilter.Location = new System.Drawing.Point(20, 95);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(960, 150);
            this.grpFilter.TabIndex = 3;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // lblWaktu
            // 
            this.lblWaktu.AutoSize = true;
            this.lblWaktu.Location = new System.Drawing.Point(15, 30);
            this.lblWaktu.Name = "lblWaktu";
            this.lblWaktu.Size = new System.Drawing.Size(185, 25);
            this.lblWaktu.TabIndex = 0;
            this.lblWaktu.Text = "Waktu Keberangkatan";
            // 
            // chkWaktu1
            // 
            this.chkWaktu1.AutoSize = true;
            this.chkWaktu1.Location = new System.Drawing.Point(20, 60);
            this.chkWaktu1.Name = "chkWaktu1";
            this.chkWaktu1.Size = new System.Drawing.Size(143, 29);
            this.chkWaktu1.TabIndex = 1;
            this.chkWaktu1.Text = "00:00 - 06:00";
            this.chkWaktu1.UseVisualStyleBackColor = true;
            // 
            // chkWaktu2
            // 
            this.chkWaktu2.AutoSize = true;
            this.chkWaktu2.Location = new System.Drawing.Point(180, 60);
            this.chkWaktu2.Name = "chkWaktu2";
            this.chkWaktu2.Size = new System.Drawing.Size(143, 29);
            this.chkWaktu2.TabIndex = 2;
            this.chkWaktu2.Text = "06:00 - 12:00";
            this.chkWaktu2.UseVisualStyleBackColor = true;
            // 
            // chkWaktu3
            // 
            this.chkWaktu3.AutoSize = true;
            this.chkWaktu3.Location = new System.Drawing.Point(340, 60);
            this.chkWaktu3.Name = "chkWaktu3";
            this.chkWaktu3.Size = new System.Drawing.Size(143, 29);
            this.chkWaktu3.TabIndex = 3;
            this.chkWaktu3.Text = "12:00 - 18:00";
            this.chkWaktu3.UseVisualStyleBackColor = true;
            // 
            // chkWaktu4
            // 
            this.chkWaktu4.AutoSize = true;
            this.chkWaktu4.Location = new System.Drawing.Point(500, 60);
            this.chkWaktu4.Name = "chkWaktu4";
            this.chkWaktu4.Size = new System.Drawing.Size(143, 29);
            this.chkWaktu4.TabIndex = 4;
            this.chkWaktu4.Text = "18:00 - 24:00";
            this.chkWaktu4.UseVisualStyleBackColor = true;
            // 
            // lblUrut
            // 
            this.lblUrut.AutoSize = true;
            this.lblUrut.Location = new System.Drawing.Point(15, 100);
            this.lblUrut.Name = "lblUrut";
            this.lblUrut.Size = new System.Drawing.Size(175, 25);
            this.lblUrut.TabIndex = 5;
            this.lblUrut.Text = "Urutkan Berdasarkan";
            // 
            // cmbUrut
            // 
            this.cmbUrut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrut.FormattingEnabled = true;
            this.cmbUrut.Items.AddRange(new object[] {
            "Harga Terendah",
            "Keberangkatan Paling Awal",
            "Keberangkatan Paling Akhir",
            "Kedatangan Paling Awal",
            "Kedatangan Paling Akhir",
            "Durasi Tercepat"});
            this.cmbUrut.Location = new System.Drawing.Point(20, 125);
            this.cmbUrut.Name = "cmbUrut";
            this.cmbUrut.Size = new System.Drawing.Size(280, 33);
            this.cmbUrut.TabIndex = 6;
            // 
            // btnFilter
            // 
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Location = new System.Drawing.Point(780, 100);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(160, 40);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Terapkan Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.AllowUserToAddRows = false;
            this.dgvJadwal.AllowUserToDeleteRows = false;
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKode,
            this.colMaskapai,
            this.colDari,
            this.colKe,
            this.colHarga,
            this.colTanggal,
            this.colWaktu,
            this.colBeli});
            this.dgvJadwal.Location = new System.Drawing.Point(20, 260);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.RowHeadersVisible = false;
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 32;
            this.dgvJadwal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwal.Size = new System.Drawing.Size(960, 330);
            this.dgvJadwal.TabIndex = 4;
            // 
            // colKode
            // 
            this.colKode.HeaderText = "KodePenerbangan";
            this.colKode.MinimumWidth = 8;
            this.colKode.Name = "colKode";
            this.colKode.ReadOnly = true;
            this.colKode.Width = 120;
            // 
            // colMaskapai
            // 
            this.colMaskapai.HeaderText = "Maskapai";
            this.colMaskapai.MinimumWidth = 8;
            this.colMaskapai.Name = "colMaskapai";
            this.colMaskapai.ReadOnly = true;
            this.colMaskapai.Width = 130;
            // 
            // colDari
            // 
            this.colDari.HeaderText = "BandaraKeberangkatan";
            this.colDari.MinimumWidth = 8;
            this.colDari.Name = "colDari";
            this.colDari.ReadOnly = true;
            this.colDari.Width = 130;
            // 
            // colKe
            // 
            this.colKe.HeaderText = "BandaraTujuan";
            this.colKe.MinimumWidth = 8;
            this.colKe.Name = "colKe";
            this.colKe.ReadOnly = true;
            this.colKe.Width = 130;
            // 
            // colHarga
            // 
            this.colHarga.HeaderText = "HargaPerTiket";
            this.colHarga.MinimumWidth = 8;
            this.colHarga.Name = "colHarga";
            this.colHarga.ReadOnly = true;
            this.colHarga.Width = 110;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "TanggalKeberangkatan";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            this.colTanggal.Width = 120;
            // 
            // colWaktu
            // 
            this.colWaktu.HeaderText = "WaktuPenerbangan";
            this.colWaktu.MinimumWidth = 8;
            this.colWaktu.Name = "colWaktu";
            this.colWaktu.ReadOnly = true;
            this.colWaktu.Width = 130;
            // 
            // colBeli
            // 
            this.colBeli.HeaderText = "";
            this.colBeli.MinimumWidth = 8;
            this.colBeli.Name = "colBeli";
            this.colBeli.ReadOnly = true;
            this.colBeli.Text = "Beli Tiket";
            this.colBeli.UseColumnTextForButtonValue = true;
            this.colBeli.Width = 90;
            // 
            // Form10ListPenerbangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.dgvJadwal);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.lblParam);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnKembali);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10ListPenerbangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Cari Penerbangan";
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblParam;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblWaktu;
        private System.Windows.Forms.CheckBox chkWaktu1;
        private System.Windows.Forms.CheckBox chkWaktu2;
        private System.Windows.Forms.CheckBox chkWaktu3;
        private System.Windows.Forms.CheckBox chkWaktu4;
        private System.Windows.Forms.Label lblUrut;
        private System.Windows.Forms.ComboBox cmbUrut;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaktu;
        private System.Windows.Forms.DataGridViewButtonColumn colBeli;
    }
}
