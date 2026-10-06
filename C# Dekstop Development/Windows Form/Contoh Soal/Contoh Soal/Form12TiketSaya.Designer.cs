namespace Contoh_Soal
{
    partial class Form12TiketSaya
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
            this.btnKembali = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.dgvTiket = new System.Windows.Forms.DataGridView();
            this.colKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(170, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tiket Saya";
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Location = new System.Drawing.Point(76, 60);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(355, 25);
            this.lblSub.TabIndex = 2;
            this.lblSub.Text = "Semua tiket Anda yang aktif akan muncul di sini";
            //
            // dgvTiket
            //
            this.dgvTiket.AllowUserToAddRows = false;
            this.dgvTiket.AllowUserToDeleteRows = false;
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKode,
            this.colMaskapai,
            this.colDari,
            this.colKe,
            this.colTanggal,
            this.colWaktu,
            this.colStatus});
            this.dgvTiket.Location = new System.Drawing.Point(20, 95);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.ReadOnly = true;
            this.dgvTiket.RowHeadersVisible = false;
            this.dgvTiket.RowHeadersWidth = 62;
            this.dgvTiket.RowTemplate.Height = 32;
            this.dgvTiket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiket.Size = new System.Drawing.Size(960, 470);
            this.dgvTiket.TabIndex = 3;
            //
            // colKode
            //
            this.colKode.HeaderText = "KodePenerbangan";
            this.colKode.MinimumWidth = 8;
            this.colKode.Name = "colKode";
            this.colKode.ReadOnly = true;
            this.colKode.Width = 130;
            //
            // colMaskapai
            //
            this.colMaskapai.HeaderText = "Maskapai";
            this.colMaskapai.MinimumWidth = 8;
            this.colMaskapai.Name = "colMaskapai";
            this.colMaskapai.ReadOnly = true;
            this.colMaskapai.Width = 140;
            //
            // colDari
            //
            this.colDari.HeaderText = "BandaraKeberangkatan";
            this.colDari.MinimumWidth = 8;
            this.colDari.Name = "colDari";
            this.colDari.ReadOnly = true;
            this.colDari.Width = 150;
            //
            // colKe
            //
            this.colKe.HeaderText = "BandaraTujuan";
            this.colKe.MinimumWidth = 8;
            this.colKe.Name = "colKe";
            this.colKe.ReadOnly = true;
            this.colKe.Width = 140;
            //
            // colTanggal
            //
            this.colTanggal.HeaderText = "TanggalKeberangkatan";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            this.colTanggal.Width = 130;
            //
            // colWaktu
            //
            this.colWaktu.HeaderText = "WaktuPenerbangan";
            this.colWaktu.MinimumWidth = 8;
            this.colWaktu.Name = "colWaktu";
            this.colWaktu.ReadOnly = true;
            this.colWaktu.Width = 130;
            //
            // colStatus
            //
            this.colStatus.HeaderText = "StatusTerakhir";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 140;
            //
            // Form12TiketSaya
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1000, 585);
            this.Controls.Add(this.dgvTiket);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnKembali);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form12TiketSaya";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Tiket Saya";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.DataGridView dgvTiket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaktu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
