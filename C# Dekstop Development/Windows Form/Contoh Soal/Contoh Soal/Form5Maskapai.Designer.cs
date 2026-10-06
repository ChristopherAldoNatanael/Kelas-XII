namespace Contoh_Soal
{
    partial class Form5Maskapai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5Maskapai));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblNavBandara = new System.Windows.Forms.Label();
            this.lblNavMaskapai = new System.Windows.Forms.Label();
            this.lblNavJadwal = new System.Windows.Forms.Label();
            this.lblNavPromo = new System.Windows.Forms.Label();
            this.lblNavStatus = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageDesc = new System.Windows.Forms.Label();
            this.dgvMaskapai = new System.Windows.Forms.DataGridView();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPerusahaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJumlahKru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeskripsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbah = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblPerusahaan = new System.Windows.Forms.Label();
            this.txtPerusahaan = new System.Windows.Forms.TextBox();
            this.lblJumlahKru = new System.Windows.Forms.Label();
            this.numKru = new System.Windows.Forms.NumericUpDown();
            this.lblDeskripsiInput = new System.Windows.Forms.Label();
            this.txtDeskripsiInput = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picNavBandara = new System.Windows.Forms.PictureBox();
            this.picNavMaskapai = new System.Windows.Forms.PictureBox();
            this.picNavJadwal = new System.Windows.Forms.PictureBox();
            this.picNavPromo = new System.Windows.Forms.PictureBox();
            this.picNavStatus = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaskapai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavBandara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavMaskapai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavPromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
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
            // lblNavMaskapai
            // 
            this.lblNavMaskapai.AutoSize = true;
            this.lblNavMaskapai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavMaskapai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavMaskapai.ForeColor = System.Drawing.Color.Black;
            this.lblNavMaskapai.Location = new System.Drawing.Point(50, 70);
            this.lblNavMaskapai.Name = "lblNavMaskapai";
            this.lblNavMaskapai.Size = new System.Drawing.Size(157, 25);
            this.lblNavMaskapai.TabIndex = 3;
            this.lblNavMaskapai.Text = "Master Maskapai";
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
            // lblNavStatus
            // 
            this.lblNavStatus.AutoSize = true;
            this.lblNavStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblNavStatus.Location = new System.Drawing.Point(50, 215);
            this.lblNavStatus.Name = "lblNavStatus";
            this.lblNavStatus.Size = new System.Drawing.Size(115, 50);
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
            this.lblPageTitle.Size = new System.Drawing.Size(276, 45);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Master Maskapai";
            // 
            // lblPageDesc
            // 
            this.lblPageDesc.AutoSize = true;
            this.lblPageDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageDesc.Location = new System.Drawing.Point(248, 118);
            this.lblPageDesc.Name = "lblPageDesc";
            this.lblPageDesc.Size = new System.Drawing.Size(419, 25);
            this.lblPageDesc.TabIndex = 3;
            this.lblPageDesc.Text = "Semua maskapai yang terdaftar akan muncul di sini";
            // 
            // dgvMaskapai
            // 
            this.dgvMaskapai.AllowUserToAddRows = false;
            this.dgvMaskapai.AllowUserToDeleteRows = false;
            this.dgvMaskapai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaskapai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNama,
            this.colPerusahaan,
            this.colJumlahKru,
            this.colDeskripsi,
            this.colUbah,
            this.colHapus});
            this.dgvMaskapai.Location = new System.Drawing.Point(250, 152);
            this.dgvMaskapai.Name = "dgvMaskapai";
            this.dgvMaskapai.ReadOnly = true;
            this.dgvMaskapai.RowHeadersVisible = false;
            this.dgvMaskapai.RowHeadersWidth = 62;
            this.dgvMaskapai.RowTemplate.Height = 32;
            this.dgvMaskapai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaskapai.Size = new System.Drawing.Size(885, 250);
            this.dgvMaskapai.TabIndex = 4;
            // 
            // colNama
            // 
            this.colNama.HeaderText = "Nama";
            this.colNama.MinimumWidth = 8;
            this.colNama.Name = "colNama";
            this.colNama.ReadOnly = true;
            this.colNama.Width = 150;
            // 
            // colPerusahaan
            // 
            this.colPerusahaan.HeaderText = "Perusahaan";
            this.colPerusahaan.MinimumWidth = 8;
            this.colPerusahaan.Name = "colPerusahaan";
            this.colPerusahaan.ReadOnly = true;
            this.colPerusahaan.Width = 150;
            // 
            // colJumlahKru
            // 
            this.colJumlahKru.HeaderText = "JumlahKru";
            this.colJumlahKru.MinimumWidth = 8;
            this.colJumlahKru.Name = "colJumlahKru";
            this.colJumlahKru.ReadOnly = true;
            this.colJumlahKru.Width = 110;
            // 
            // colDeskripsi
            // 
            this.colDeskripsi.HeaderText = "Deskripsi";
            this.colDeskripsi.MinimumWidth = 8;
            this.colDeskripsi.Name = "colDeskripsi";
            this.colDeskripsi.ReadOnly = true;
            this.colDeskripsi.Width = 200;
            // 
            // colUbah
            // 
            this.colUbah.HeaderText = "";
            this.colUbah.MinimumWidth = 8;
            this.colUbah.Name = "colUbah";
            this.colUbah.ReadOnly = true;
            this.colUbah.Text = "Ubah";
            this.colUbah.UseColumnTextForButtonValue = true;
            this.colUbah.Width = 80;
            // 
            // colHapus
            // 
            this.colHapus.HeaderText = "";
            this.colHapus.MinimumWidth = 8;
            this.colHapus.Name = "colHapus";
            this.colHapus.ReadOnly = true;
            this.colHapus.Text = "Hapus";
            this.colHapus.UseColumnTextForButtonValue = true;
            this.colHapus.Width = 80;
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(250, 425);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(59, 25);
            this.lblNama.TabIndex = 5;
            this.lblNama.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(360, 422);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(230, 31);
            this.txtNama.TabIndex = 6;
            // 
            // lblPerusahaan
            // 
            this.lblPerusahaan.AutoSize = true;
            this.lblPerusahaan.Location = new System.Drawing.Point(250, 465);
            this.lblPerusahaan.Name = "lblPerusahaan";
            this.lblPerusahaan.Size = new System.Drawing.Size(101, 25);
            this.lblPerusahaan.TabIndex = 7;
            this.lblPerusahaan.Text = "Perusahaan";
            // 
            // txtPerusahaan
            // 
            this.txtPerusahaan.Location = new System.Drawing.Point(360, 462);
            this.txtPerusahaan.Name = "txtPerusahaan";
            this.txtPerusahaan.Size = new System.Drawing.Size(230, 31);
            this.txtPerusahaan.TabIndex = 7;
            // 
            // lblJumlahKru
            // 
            this.lblJumlahKru.AutoSize = true;
            this.lblJumlahKru.Location = new System.Drawing.Point(250, 505);
            this.lblJumlahKru.Name = "lblJumlahKru";
            this.lblJumlahKru.Size = new System.Drawing.Size(98, 25);
            this.lblJumlahKru.TabIndex = 8;
            this.lblJumlahKru.Text = "Jumlah Kru";
            // 
            // numKru
            // 
            this.numKru.Location = new System.Drawing.Point(360, 502);
            this.numKru.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKru.Name = "numKru";
            this.numKru.Size = new System.Drawing.Size(230, 31);
            this.numKru.TabIndex = 8;
            this.numKru.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDeskripsiInput
            // 
            this.lblDeskripsiInput.AutoSize = true;
            this.lblDeskripsiInput.Location = new System.Drawing.Point(630, 425);
            this.lblDeskripsiInput.Name = "lblDeskripsiInput";
            this.lblDeskripsiInput.Size = new System.Drawing.Size(84, 25);
            this.lblDeskripsiInput.TabIndex = 9;
            this.lblDeskripsiInput.Text = "Deskripsi";
            // 
            // txtDeskripsiInput
            // 
            this.txtDeskripsiInput.Location = new System.Drawing.Point(780, 422);
            this.txtDeskripsiInput.Multiline = true;
            this.txtDeskripsiInput.Name = "txtDeskripsiInput";
            this.txtDeskripsiInput.Size = new System.Drawing.Size(230, 113);
            this.txtDeskripsiInput.TabIndex = 9;
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(780, 595);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(105, 35);
            this.btnBatal.TabIndex = 10;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(905, 595);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(105, 35);
            this.btnSimpan.TabIndex = 11;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
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
            // Form5Maskapai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1161, 650);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.txtDeskripsiInput);
            this.Controls.Add(this.lblDeskripsiInput);
            this.Controls.Add(this.numKru);
            this.Controls.Add(this.lblJumlahKru);
            this.Controls.Add(this.txtPerusahaan);
            this.Controls.Add(this.lblPerusahaan);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.dgvMaskapai);
            this.Controls.Add(this.lblPageDesc);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5Maskapai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Admin";
            this.Load += new System.EventHandler(this.Form5Maskapai_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaskapai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavBandara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavMaskapai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavPromo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNavStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvMaskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPerusahaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJumlahKru;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeskripsi;
        private System.Windows.Forms.DataGridViewButtonColumn colUbah;
        private System.Windows.Forms.DataGridViewButtonColumn colHapus;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblPerusahaan;
        private System.Windows.Forms.TextBox txtPerusahaan;
        private System.Windows.Forms.Label lblJumlahKru;
        private System.Windows.Forms.NumericUpDown numKru;
        private System.Windows.Forms.Label lblDeskripsiInput;
        private System.Windows.Forms.TextBox txtDeskripsiInput;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
    }
}
