namespace Contoh_Soal
{
    partial class Form8UbahStatusPenerbangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8UbahStatusPenerbangan));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picNavBandara = new System.Windows.Forms.PictureBox();
            this.lblNavBandara = new System.Windows.Forms.Label();
            this.picNavMaskapai = new System.Windows.Forms.PictureBox();
            this.lblNavMaskapai = new System.Windows.Forms.Label();
            this.picNavJadwal = new System.Windows.Forms.PictureBox();
            this.lblNavJadwal = new System.Windows.Forms.Label();
            this.picNavPromo = new System.Windows.Forms.PictureBox();
            this.lblNavPromo = new System.Windows.Forms.Label();
            this.picNavStatus = new System.Windows.Forms.PictureBox();
            this.lblNavStatus = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageDesc = new System.Windows.Forms.Label();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.colKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusTerakhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTerakhirDiubah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbah = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblPerkiraan = new System.Windows.Forms.Label();
            this.txtPerkiraan = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavBandara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavMaskapai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavPromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(94)))), ((int)(((byte)(164)))));
            this.pnlTop.Controls.Add(this.btnMenu);
            this.pnlTop.Controls.Add(this.lblTopTitle);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1161, 58);
            this.pnlTop.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = global::Contoh_Soal.Properties.Resources.menu_alt_721;
            this.btnMenu.Location = new System.Drawing.Point(12, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(42, 40);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 1;
            this.btnMenu.TabStop = false;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopTitle.ForeColor = System.Drawing.Color.White;
            this.lblTopTitle.Location = new System.Drawing.Point(60, 15);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(108, 28);
            this.lblTopTitle.TabIndex = 0;
            this.lblTopTitle.Text = "Dashboard";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidebar.Controls.Add(this.picLogout);
            this.pnlSidebar.Controls.Add(this.picNavBandara);
            this.pnlSidebar.Controls.Add(this.lblNavBandara);
            this.pnlSidebar.Controls.Add(this.picNavMaskapai);
            this.pnlSidebar.Controls.Add(this.lblNavMaskapai);
            this.pnlSidebar.Controls.Add(this.picNavJadwal);
            this.pnlSidebar.Controls.Add(this.lblNavJadwal);
            this.pnlSidebar.Controls.Add(this.picNavPromo);
            this.pnlSidebar.Controls.Add(this.lblNavPromo);
            this.pnlSidebar.Controls.Add(this.picNavStatus);
            this.pnlSidebar.Controls.Add(this.lblNavStatus);
            this.pnlSidebar.Controls.Add(this.lblLogout);
            this.pnlSidebar.Location = new System.Drawing.Point(0, 58);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(222, 592);
            this.pnlSidebar.TabIndex = 1;
            // 
            // picLogout
            // 
            this.picLogout.BackColor = System.Drawing.Color.Transparent;
            this.picLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogout.Image = global::Contoh_Soal.Properties.Resources.log_out_unselected_72;
            this.picLogout.Location = new System.Drawing.Point(11, 525);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(39, 46);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogout.TabIndex = 10;
            this.picLogout.TabStop = false;
            // 
            // picNavBandara
            // 
            this.picNavBandara.BackColor = System.Drawing.Color.Transparent;
            this.picNavBandara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNavBandara.Image = global::Contoh_Soal.Properties.Resources.map_selected_72;
            this.picNavBandara.Location = new System.Drawing.Point(18, 18);
            this.picNavBandara.Name = "picNavBandara";
            this.picNavBandara.Size = new System.Drawing.Size(24, 24);
            this.picNavBandara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNavBandara.TabIndex = 0;
            this.picNavBandara.TabStop = false;
            // 
            // lblNavBandara
            // 
            this.lblNavBandara.AutoSize = true;
            this.lblNavBandara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavBandara.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavBandara.ForeColor = System.Drawing.Color.Gray;
            this.lblNavBandara.Location = new System.Drawing.Point(50, 20);
            this.lblNavBandara.Name = "lblNavBandara";
            this.lblNavBandara.Size = new System.Drawing.Size(135, 25);
            this.lblNavBandara.TabIndex = 1;
            this.lblNavBandara.Text = "Master Bandara";
            // 
            // picNavMaskapai
            // 
            this.picNavMaskapai.BackColor = System.Drawing.Color.Transparent;
            this.picNavMaskapai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNavMaskapai.Image = global::Contoh_Soal.Properties.Resources.plane_take_off_unselected_72;
            this.picNavMaskapai.Location = new System.Drawing.Point(18, 68);
            this.picNavMaskapai.Name = "picNavMaskapai";
            this.picNavMaskapai.Size = new System.Drawing.Size(24, 24);
            this.picNavMaskapai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNavMaskapai.TabIndex = 2;
            this.picNavMaskapai.TabStop = false;
            // 
            // lblNavMaskapai
            // 
            this.lblNavMaskapai.AutoSize = true;
            this.lblNavMaskapai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavMaskapai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavMaskapai.ForeColor = System.Drawing.Color.Gray;
            this.lblNavMaskapai.Location = new System.Drawing.Point(50, 70);
            this.lblNavMaskapai.Name = "lblNavMaskapai";
            this.lblNavMaskapai.Size = new System.Drawing.Size(146, 25);
            this.lblNavMaskapai.TabIndex = 3;
            this.lblNavMaskapai.Text = "Master Maskapai";
            // 
            // picNavJadwal
            // 
            this.picNavJadwal.BackColor = System.Drawing.Color.Transparent;
            this.picNavJadwal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNavJadwal.Image = global::Contoh_Soal.Properties.Resources.calendar_unselected_72;
            this.picNavJadwal.Location = new System.Drawing.Point(18, 118);
            this.picNavJadwal.Name = "picNavJadwal";
            this.picNavJadwal.Size = new System.Drawing.Size(24, 24);
            this.picNavJadwal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNavJadwal.TabIndex = 4;
            this.picNavJadwal.TabStop = false;
            // 
            // lblNavJadwal
            // 
            this.lblNavJadwal.AutoSize = true;
            this.lblNavJadwal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavJadwal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavJadwal.ForeColor = System.Drawing.Color.Gray;
            this.lblNavJadwal.Location = new System.Drawing.Point(50, 110);
            this.lblNavJadwal.Name = "lblNavJadwal";
            this.lblNavJadwal.Size = new System.Drawing.Size(123, 50);
            this.lblNavJadwal.TabIndex = 5;
            this.lblNavJadwal.Text = "Master Jadwal\r\nPenerbangan";
            // 
            // picNavPromo
            // 
            this.picNavPromo.BackColor = System.Drawing.Color.Transparent;
            this.picNavPromo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNavPromo.Image = global::Contoh_Soal.Properties.Resources.purchase_tag_alt_unselected_72;
            this.picNavPromo.Location = new System.Drawing.Point(18, 175);
            this.picNavPromo.Name = "picNavPromo";
            this.picNavPromo.Size = new System.Drawing.Size(24, 24);
            this.picNavPromo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNavPromo.TabIndex = 6;
            this.picNavPromo.TabStop = false;
            // 
            // lblNavPromo
            // 
            this.lblNavPromo.AutoSize = true;
            this.lblNavPromo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavPromo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavPromo.ForeColor = System.Drawing.Color.Gray;
            this.lblNavPromo.Location = new System.Drawing.Point(50, 175);
            this.lblNavPromo.Name = "lblNavPromo";
            this.lblNavPromo.Size = new System.Drawing.Size(171, 25);
            this.lblNavPromo.TabIndex = 7;
            this.lblNavPromo.Text = "Master Kode Promo";
            // 
            // picNavStatus
            // 
            this.picNavStatus.BackColor = System.Drawing.Color.Transparent;
            this.picNavStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNavStatus.Image = global::Contoh_Soal.Properties.Resources.notepad_unselected_72;
            this.picNavStatus.Location = new System.Drawing.Point(18, 225);
            this.picNavStatus.Name = "picNavStatus";
            this.picNavStatus.Size = new System.Drawing.Size(24, 24);
            this.picNavStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNavStatus.TabIndex = 8;
            this.picNavStatus.TabStop = false;
            // 
            // lblNavStatus
            // 
            this.lblNavStatus.AutoSize = true;
            this.lblNavStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavStatus.ForeColor = System.Drawing.Color.Black;
            this.lblNavStatus.Location = new System.Drawing.Point(50, 215);
            this.lblNavStatus.Name = "lblNavStatus";
            this.lblNavStatus.Size = new System.Drawing.Size(124, 50);
            this.lblNavStatus.TabIndex = 9;
            this.lblNavStatus.Text = "Ubah Status\r\nPenerbangan";
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblLogout.Location = new System.Drawing.Point(50, 540);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(69, 25);
            this.lblLogout.TabIndex = 11;
            this.lblLogout.Text = "Logout";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(242, 72);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(405, 45);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Ubah Status Penerbangan";
            // 
            // lblPageDesc
            // 
            this.lblPageDesc.AutoSize = true;
            this.lblPageDesc.Location = new System.Drawing.Point(248, 118);
            this.lblPageDesc.Name = "lblPageDesc";
            this.lblPageDesc.Size = new System.Drawing.Size(450, 25);
            this.lblPageDesc.TabIndex = 3;
            this.lblPageDesc.Text = "Anda bisa mengubah status jadwal penerbangan di sini";
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKode,
            this.colMaskapai,
            this.colDari,
            this.colKe,
            this.colTanggal,
            this.colWaktu,
            this.colDurasi,
            this.colStatusTerakhir,
            this.colTerakhirDiubah,
            this.colUbah});
            this.dgvStatus.Location = new System.Drawing.Point(250, 152);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.RowHeadersWidth = 62;
            this.dgvStatus.RowTemplate.Height = 32;
            this.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatus.Size = new System.Drawing.Size(885, 320);
            this.dgvStatus.TabIndex = 4;
            // 
            // colKode
            // 
            this.colKode.HeaderText = "KodePenerbangan";
            this.colKode.MinimumWidth = 8;
            this.colKode.Name = "colKode";
            this.colKode.ReadOnly = true;
            this.colKode.Width = 90;
            // 
            // colMaskapai
            // 
            this.colMaskapai.HeaderText = "Maskapai";
            this.colMaskapai.MinimumWidth = 8;
            this.colMaskapai.Name = "colMaskapai";
            this.colMaskapai.ReadOnly = true;
            this.colMaskapai.Width = 80;
            // 
            // colDari
            // 
            this.colDari.HeaderText = "Dari";
            this.colDari.MinimumWidth = 8;
            this.colDari.Name = "colDari";
            this.colDari.ReadOnly = true;
            this.colDari.Width = 80;
            // 
            // colKe
            // 
            this.colKe.HeaderText = "Ke";
            this.colKe.MinimumWidth = 8;
            this.colKe.Name = "colKe";
            this.colKe.ReadOnly = true;
            this.colKe.Width = 80;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            this.colTanggal.Width = 80;
            // 
            // colWaktu
            // 
            this.colWaktu.HeaderText = "Waktu";
            this.colWaktu.MinimumWidth = 8;
            this.colWaktu.Name = "colWaktu";
            this.colWaktu.ReadOnly = true;
            this.colWaktu.Width = 70;
            // 
            // colDurasi
            // 
            this.colDurasi.HeaderText = "Durasi";
            this.colDurasi.MinimumWidth = 8;
            this.colDurasi.Name = "colDurasi";
            this.colDurasi.ReadOnly = true;
            this.colDurasi.Width = 80;
            // 
            // colStatusTerakhir
            // 
            this.colStatusTerakhir.HeaderText = "StatusTerakhir";
            this.colStatusTerakhir.MinimumWidth = 8;
            this.colStatusTerakhir.Name = "colStatusTerakhir";
            this.colStatusTerakhir.ReadOnly = true;
            this.colStatusTerakhir.Width = 110;
            // 
            // colTerakhirDiubah
            // 
            this.colTerakhirDiubah.HeaderText = "TerakhirDiubah";
            this.colTerakhirDiubah.MinimumWidth = 8;
            this.colTerakhirDiubah.Name = "colTerakhirDiubah";
            this.colTerakhirDiubah.ReadOnly = true;
            this.colTerakhirDiubah.Width = 110;
            // 
            // colUbah
            // 
            this.colUbah.HeaderText = "";
            this.colUbah.MinimumWidth = 8;
            this.colUbah.Name = "colUbah";
            this.colUbah.ReadOnly = true;
            this.colUbah.Text = "Ubah";
            this.colUbah.UseColumnTextForButtonValue = true;
            this.colUbah.Width = 70;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.cmbStatus);
            this.pnlStatus.Controls.Add(this.lblPerkiraan);
            this.pnlStatus.Controls.Add(this.txtPerkiraan);
            this.pnlStatus.Controls.Add(this.btnBatal);
            this.pnlStatus.Controls.Add(this.btnSimpan);
            this.pnlStatus.Location = new System.Drawing.Point(250, 485);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(885, 145);
            this.pnlStatus.TabIndex = 5;
            this.pnlStatus.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(0, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Sesuai Jadwal",
            "Delay",
            "Dibatalkan"});
            this.cmbStatus.Location = new System.Drawing.Point(150, 12);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(250, 33);
            this.cmbStatus.TabIndex = 1;
            // 
            // lblPerkiraan
            // 
            this.lblPerkiraan.AutoSize = true;
            this.lblPerkiraan.Location = new System.Drawing.Point(430, 15);
            this.lblPerkiraan.Name = "lblPerkiraan";
            this.lblPerkiraan.Size = new System.Drawing.Size(187, 25);
            this.lblPerkiraan.TabIndex = 2;
            this.lblPerkiraan.Text = "Perkiraan Durasi Delay";
            this.lblPerkiraan.Visible = false;
            // 
            // txtPerkiraan
            // 
            this.txtPerkiraan.Location = new System.Drawing.Point(620, 12);
            this.txtPerkiraan.Name = "txtPerkiraan";
            this.txtPerkiraan.Size = new System.Drawing.Size(250, 31);
            this.txtPerkiraan.TabIndex = 3;
            this.txtPerkiraan.Visible = false;
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(640, 95);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(105, 35);
            this.btnBatal.TabIndex = 4;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(765, 95);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(105, 35);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // Form8UbahStatusPenerbangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1161, 650);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.dgvStatus);
            this.Controls.Add(this.lblPageDesc);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form8UbahStatusPenerbangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Admin";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavBandara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavMaskapai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavPromo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picNavBandara;
        private System.Windows.Forms.Label lblNavBandara;
        private System.Windows.Forms.PictureBox picNavMaskapai;
        private System.Windows.Forms.Label lblNavMaskapai;
        private System.Windows.Forms.PictureBox picNavJadwal;
        private System.Windows.Forms.Label lblNavJadwal;
        private System.Windows.Forms.PictureBox picNavPromo;
        private System.Windows.Forms.Label lblNavPromo;
        private System.Windows.Forms.PictureBox picNavStatus;
        private System.Windows.Forms.Label lblNavStatus;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageDesc;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaktu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusTerakhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTerakhirDiubah;
        private System.Windows.Forms.DataGridViewButtonColumn colUbah;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPerkiraan;
        private System.Windows.Forms.TextBox txtPerkiraan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
    }
}
