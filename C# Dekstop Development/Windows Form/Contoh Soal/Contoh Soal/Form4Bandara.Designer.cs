namespace Contoh_Soal
{
    partial class Form4Bandara
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4Bandara));
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
            this.dgvBandara = new System.Windows.Forms.DataGridView();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKodeIATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNegara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJumlahTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbah = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNama = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.lblKodeIATA = new System.Windows.Forms.Label();
            this.txtKodeIATA = new System.Windows.Forms.TextBox();
            this.lblKota = new System.Windows.Forms.Label();
            this.txtKota = new System.Windows.Forms.TextBox();
            this.lblNegara = new System.Windows.Forms.Label();
            this.cmbNegara = new System.Windows.Forms.ComboBox();
            this.lblJumlahTerminal = new System.Windows.Forms.Label();
            this.numTerminal = new System.Windows.Forms.NumericUpDown();
            this.lblAlamatInput = new System.Windows.Forms.Label();
            this.txtAlamatInput = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvBandara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTerminal)).BeginInit();
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
            this.lblNavBandara.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavBandara.ForeColor = System.Drawing.Color.Black;
            this.lblNavBandara.Location = new System.Drawing.Point(50, 20);
            this.lblNavBandara.Name = "lblNavBandara";
            this.lblNavBandara.Size = new System.Drawing.Size(147, 25);
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
            this.lblPageTitle.Size = new System.Drawing.Size(257, 45);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Master Bandara";
            // 
            // lblPageDesc
            // 
            this.lblPageDesc.AutoSize = true;
            this.lblPageDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageDesc.Location = new System.Drawing.Point(248, 118);
            this.lblPageDesc.Name = "lblPageDesc";
            this.lblPageDesc.Size = new System.Drawing.Size(409, 25);
            this.lblPageDesc.TabIndex = 3;
            this.lblPageDesc.Text = "Semua bandara yang terdaftar akan muncul di sini";
            // 
            // dgvBandara
            // 
            this.dgvBandara.AllowUserToAddRows = false;
            this.dgvBandara.AllowUserToDeleteRows = false;
            this.dgvBandara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBandara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNama,
            this.colKodeIATA,
            this.colKota,
            this.colNegara,
            this.colJumlahTerminal,
            this.colAlamat,
            this.colUbah,
            this.colHapus});
            this.dgvBandara.Location = new System.Drawing.Point(250, 152);
            this.dgvBandara.Name = "dgvBandara";
            this.dgvBandara.ReadOnly = true;
            this.dgvBandara.RowHeadersVisible = false;
            this.dgvBandara.RowHeadersWidth = 62;
            this.dgvBandara.RowTemplate.Height = 32;
            this.dgvBandara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBandara.Size = new System.Drawing.Size(885, 250);
            this.dgvBandara.TabIndex = 4;
            // 
            // colNama
            // 
            this.colNama.HeaderText = "Nama";
            this.colNama.MinimumWidth = 8;
            this.colNama.Name = "colNama";
            this.colNama.ReadOnly = true;
            this.colNama.Width = 130;
            // 
            // colKodeIATA
            // 
            this.colKodeIATA.HeaderText = "KodeIATA";
            this.colKodeIATA.MinimumWidth = 8;
            this.colKodeIATA.Name = "colKodeIATA";
            this.colKodeIATA.ReadOnly = true;
            this.colKodeIATA.Width = 80;
            // 
            // colKota
            // 
            this.colKota.HeaderText = "Kota";
            this.colKota.MinimumWidth = 8;
            this.colKota.Name = "colKota";
            this.colKota.ReadOnly = true;
            this.colKota.Width = 150;
            // 
            // colNegara
            // 
            this.colNegara.HeaderText = "Negara";
            this.colNegara.MinimumWidth = 8;
            this.colNegara.Name = "colNegara";
            this.colNegara.ReadOnly = true;
            this.colNegara.Width = 150;
            // 
            // colJumlahTerminal
            // 
            this.colJumlahTerminal.HeaderText = "JumlahTerminal";
            this.colJumlahTerminal.MinimumWidth = 8;
            this.colJumlahTerminal.Name = "colJumlahTerminal";
            this.colJumlahTerminal.ReadOnly = true;
            this.colJumlahTerminal.Width = 110;
            // 
            // colAlamat
            // 
            this.colAlamat.HeaderText = "Alamat";
            this.colAlamat.MinimumWidth = 8;
            this.colAlamat.Name = "colAlamat";
            this.colAlamat.ReadOnly = true;
            this.colAlamat.Width = 120;
            // 
            // colUbah
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUbah.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHapus.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.lblNama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.Location = new System.Drawing.Point(250, 425);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(59, 25);
            this.lblNama.TabIndex = 5;
            this.lblNama.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNama.Location = new System.Drawing.Point(360, 422);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(230, 31);
            this.txtNama.TabIndex = 6;
            // 
            // lblKodeIATA
            // 
            this.lblKodeIATA.AutoSize = true;
            this.lblKodeIATA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeIATA.Location = new System.Drawing.Point(250, 465);
            this.lblKodeIATA.Name = "lblKodeIATA";
            this.lblKodeIATA.Size = new System.Drawing.Size(94, 25);
            this.lblKodeIATA.TabIndex = 7;
            this.lblKodeIATA.Text = "Kode IATA";
            // 
            // txtKodeIATA
            // 
            this.txtKodeIATA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKodeIATA.Location = new System.Drawing.Point(360, 462);
            this.txtKodeIATA.Name = "txtKodeIATA";
            this.txtKodeIATA.Size = new System.Drawing.Size(230, 31);
            this.txtKodeIATA.TabIndex = 7;
            // 
            // lblKota
            // 
            this.lblKota.AutoSize = true;
            this.lblKota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKota.Location = new System.Drawing.Point(250, 505);
            this.lblKota.Name = "lblKota";
            this.lblKota.Size = new System.Drawing.Size(48, 25);
            this.lblKota.TabIndex = 8;
            this.lblKota.Text = "Kota";
            // 
            // txtKota
            // 
            this.txtKota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKota.Location = new System.Drawing.Point(360, 502);
            this.txtKota.Name = "txtKota";
            this.txtKota.Size = new System.Drawing.Size(230, 31);
            this.txtKota.TabIndex = 8;
            // 
            // lblNegara
            // 
            this.lblNegara.AutoSize = true;
            this.lblNegara.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNegara.Location = new System.Drawing.Point(250, 545);
            this.lblNegara.Name = "lblNegara";
            this.lblNegara.Size = new System.Drawing.Size(69, 25);
            this.lblNegara.TabIndex = 9;
            this.lblNegara.Text = "Negara";
            // 
            // cmbNegara
            // 
            this.cmbNegara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNegara.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNegara.FormattingEnabled = true;
            this.cmbNegara.Items.AddRange(new object[] {
            "Afganistan",
            "Indonesia",
            "Malaysia",
            "Singapura"});
            this.cmbNegara.Location = new System.Drawing.Point(360, 542);
            this.cmbNegara.Name = "cmbNegara";
            this.cmbNegara.Size = new System.Drawing.Size(230, 33);
            this.cmbNegara.TabIndex = 9;
            // 
            // lblJumlahTerminal
            // 
            this.lblJumlahTerminal.AutoSize = true;
            this.lblJumlahTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahTerminal.Location = new System.Drawing.Point(630, 425);
            this.lblJumlahTerminal.Name = "lblJumlahTerminal";
            this.lblJumlahTerminal.Size = new System.Drawing.Size(137, 25);
            this.lblJumlahTerminal.TabIndex = 10;
            this.lblJumlahTerminal.Text = "Jumlah Terminal";
            // 
            // numTerminal
            // 
            this.numTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTerminal.Location = new System.Drawing.Point(780, 422);
            this.numTerminal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTerminal.Name = "numTerminal";
            this.numTerminal.Size = new System.Drawing.Size(230, 31);
            this.numTerminal.TabIndex = 10;
            this.numTerminal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAlamatInput
            // 
            this.lblAlamatInput.AutoSize = true;
            this.lblAlamatInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamatInput.Location = new System.Drawing.Point(630, 465);
            this.lblAlamatInput.Name = "lblAlamatInput";
            this.lblAlamatInput.Size = new System.Drawing.Size(68, 25);
            this.lblAlamatInput.TabIndex = 11;
            this.lblAlamatInput.Text = "Alamat";
            // 
            // txtAlamatInput
            // 
            this.txtAlamatInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlamatInput.Location = new System.Drawing.Point(780, 462);
            this.txtAlamatInput.Multiline = true;
            this.txtAlamatInput.Name = "txtAlamatInput";
            this.txtAlamatInput.Size = new System.Drawing.Size(230, 113);
            this.txtAlamatInput.TabIndex = 11;
            // 
            // btnBatal
            // 
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(780, 595);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(105, 35);
            this.btnBatal.TabIndex = 12;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(905, 595);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(105, 35);
            this.btnSimpan.TabIndex = 13;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // Form4Bandara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1161, 650);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.txtAlamatInput);
            this.Controls.Add(this.lblAlamatInput);
            this.Controls.Add(this.numTerminal);
            this.Controls.Add(this.lblJumlahTerminal);
            this.Controls.Add(this.cmbNegara);
            this.Controls.Add(this.lblNegara);
            this.Controls.Add(this.txtKota);
            this.Controls.Add(this.lblKota);
            this.Controls.Add(this.txtKodeIATA);
            this.Controls.Add(this.lblKodeIATA);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.dgvBandara);
            this.Controls.Add(this.lblPageDesc);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4Bandara";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvBandara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTerminal)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvBandara;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKodeIATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNegara;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJumlahTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlamat;
        private System.Windows.Forms.DataGridViewButtonColumn colUbah;
        private System.Windows.Forms.DataGridViewButtonColumn colHapus;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label lblKodeIATA;
        private System.Windows.Forms.TextBox txtKodeIATA;
        private System.Windows.Forms.Label lblKota;
        private System.Windows.Forms.TextBox txtKota;
        private System.Windows.Forms.Label lblNegara;
        private System.Windows.Forms.ComboBox cmbNegara;
        private System.Windows.Forms.Label lblJumlahTerminal;
        private System.Windows.Forms.NumericUpDown numTerminal;
        private System.Windows.Forms.Label lblAlamatInput;
        private System.Windows.Forms.TextBox txtAlamatInput;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
    }
}
