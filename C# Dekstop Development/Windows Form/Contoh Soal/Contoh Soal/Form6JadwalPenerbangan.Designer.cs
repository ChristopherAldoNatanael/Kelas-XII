namespace Contoh_Soal
{
    partial class Form6JadwalPenerbangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6JadwalPenerbangan));
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
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.colKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaskapai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUbah = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblKode = new System.Windows.Forms.Label();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.lblDari = new System.Windows.Forms.Label();
            this.cmbDari = new System.Windows.Forms.ComboBox();
            this.lblKe = new System.Windows.Forms.Label();
            this.cmbKe = new System.Windows.Forms.ComboBox();
            this.lblMaskapaiInput = new System.Windows.Forms.Label();
            this.cmbMaskapaiInput = new System.Windows.Forms.ComboBox();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblWaktu = new System.Windows.Forms.Label();
            this.txtWaktu = new System.Windows.Forms.TextBox();
            this.lblDurasi = new System.Windows.Forms.Label();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.lblHarga = new System.Windows.Forms.Label();
            this.numHarga = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga)).BeginInit();
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
            this.lblNavMaskapai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavMaskapai.ForeColor = System.Drawing.Color.Gray;
            this.lblNavMaskapai.Location = new System.Drawing.Point(50, 70);
            this.lblNavMaskapai.Name = "lblNavMaskapai";
            this.lblNavMaskapai.Size = new System.Drawing.Size(146, 25);
            this.lblNavMaskapai.TabIndex = 3;
            this.lblNavMaskapai.Text = "Master Maskapai";
            // 
            // lblNavJadwal
            // 
            this.lblNavJadwal.AutoSize = true;
            this.lblNavJadwal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavJadwal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavJadwal.ForeColor = System.Drawing.Color.Black;
            this.lblNavJadwal.Location = new System.Drawing.Point(50, 110);
            this.lblNavJadwal.Name = "lblNavJadwal";
            this.lblNavJadwal.Size = new System.Drawing.Size(134, 50);
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
            this.lblPageTitle.Size = new System.Drawing.Size(442, 45);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Master Jadwal Penerbangan";
            // 
            // lblPageDesc
            // 
            this.lblPageDesc.AutoSize = true;
            this.lblPageDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageDesc.Location = new System.Drawing.Point(248, 118);
            this.lblPageDesc.Name = "lblPageDesc";
            this.lblPageDesc.Size = new System.Drawing.Size(387, 25);
            this.lblPageDesc.TabIndex = 3;
            this.lblPageDesc.Text = "Semua jadwal penerbangan akan muncul di sini";
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.AllowUserToAddRows = false;
            this.dgvJadwal.AllowUserToDeleteRows = false;
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKode,
            this.colDari,
            this.colKe,
            this.colMaskapai,
            this.colTanggal,
            this.colWaktu,
            this.colDurasi,
            this.colHarga,
            this.colUbah,
            this.colHapus});
            this.dgvJadwal.Location = new System.Drawing.Point(250, 152);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.RowHeadersVisible = false;
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 32;
            this.dgvJadwal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwal.Size = new System.Drawing.Size(885, 250);
            this.dgvJadwal.TabIndex = 4;
            // 
            // colKode
            // 
            this.colKode.HeaderText = "KodePenerbangan";
            this.colKode.MinimumWidth = 8;
            this.colKode.Name = "colKode";
            this.colKode.ReadOnly = true;
            this.colKode.Width = 90;
            // 
            // colDari
            // 
            this.colDari.HeaderText = "Dari";
            this.colDari.MinimumWidth = 8;
            this.colDari.Name = "colDari";
            this.colDari.ReadOnly = true;
            this.colDari.Width = 90;
            // 
            // colKe
            // 
            this.colKe.HeaderText = "Ke";
            this.colKe.MinimumWidth = 8;
            this.colKe.Name = "colKe";
            this.colKe.ReadOnly = true;
            this.colKe.Width = 90;
            // 
            // colMaskapai
            // 
            this.colMaskapai.HeaderText = "Maskapai";
            this.colMaskapai.MinimumWidth = 8;
            this.colMaskapai.Name = "colMaskapai";
            this.colMaskapai.ReadOnly = true;
            this.colMaskapai.Width = 90;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal";
            this.colTanggal.MinimumWidth = 8;
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            this.colTanggal.Width = 90;
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
            this.colDurasi.Width = 90;
            // 
            // colHarga
            // 
            this.colHarga.HeaderText = "Harga";
            this.colHarga.MinimumWidth = 8;
            this.colHarga.Name = "colHarga";
            this.colHarga.ReadOnly = true;
            this.colHarga.Width = 90;
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
            // colHapus
            // 
            this.colHapus.HeaderText = "";
            this.colHapus.MinimumWidth = 8;
            this.colHapus.Name = "colHapus";
            this.colHapus.ReadOnly = true;
            this.colHapus.Text = "Hapus";
            this.colHapus.UseColumnTextForButtonValue = true;
            this.colHapus.Width = 70;
            // 
            // lblKode
            // 
            this.lblKode.AutoSize = true;
            this.lblKode.Location = new System.Drawing.Point(250, 425);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(161, 25);
            this.lblKode.TabIndex = 5;
            this.lblKode.Text = "Kode Penerbangan";
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(430, 422);
            this.txtKode.MaxLength = 8;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(180, 31);
            this.txtKode.TabIndex = 6;
            // 
            // lblDari
            // 
            this.lblDari.AutoSize = true;
            this.lblDari.Location = new System.Drawing.Point(250, 465);
            this.lblDari.Name = "lblDari";
            this.lblDari.Size = new System.Drawing.Size(44, 25);
            this.lblDari.TabIndex = 7;
            this.lblDari.Text = "Dari";
            // 
            // cmbDari
            // 
            this.cmbDari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDari.FormattingEnabled = true;
            this.cmbDari.Location = new System.Drawing.Point(430, 462);
            this.cmbDari.Name = "cmbDari";
            this.cmbDari.Size = new System.Drawing.Size(180, 33);
            this.cmbDari.TabIndex = 7;
            // 
            // lblKe
            // 
            this.lblKe.AutoSize = true;
            this.lblKe.Location = new System.Drawing.Point(250, 505);
            this.lblKe.Name = "lblKe";
            this.lblKe.Size = new System.Drawing.Size(31, 25);
            this.lblKe.TabIndex = 8;
            this.lblKe.Text = "Ke";
            // 
            // cmbKe
            // 
            this.cmbKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKe.FormattingEnabled = true;
            this.cmbKe.Location = new System.Drawing.Point(430, 502);
            this.cmbKe.Name = "cmbKe";
            this.cmbKe.Size = new System.Drawing.Size(180, 33);
            this.cmbKe.TabIndex = 8;
            // 
            // lblMaskapaiInput
            // 
            this.lblMaskapaiInput.AutoSize = true;
            this.lblMaskapaiInput.Location = new System.Drawing.Point(250, 545);
            this.lblMaskapaiInput.Name = "lblMaskapaiInput";
            this.lblMaskapaiInput.Size = new System.Drawing.Size(87, 25);
            this.lblMaskapaiInput.TabIndex = 9;
            this.lblMaskapaiInput.Text = "Maskapai";
            // 
            // cmbMaskapaiInput
            // 
            this.cmbMaskapaiInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaskapaiInput.FormattingEnabled = true;
            this.cmbMaskapaiInput.Location = new System.Drawing.Point(430, 542);
            this.cmbMaskapaiInput.Name = "cmbMaskapaiInput";
            this.cmbMaskapaiInput.Size = new System.Drawing.Size(180, 33);
            this.cmbMaskapaiInput.TabIndex = 9;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Location = new System.Drawing.Point(640, 425);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(73, 25);
            this.lblTanggal.TabIndex = 10;
            this.lblTanggal.Text = "Tanggal";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(820, 422);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(230, 31);
            this.dtpTanggal.TabIndex = 10;
            // 
            // lblWaktu
            // 
            this.lblWaktu.AutoSize = true;
            this.lblWaktu.Location = new System.Drawing.Point(640, 465);
            this.lblWaktu.Name = "lblWaktu";
            this.lblWaktu.Size = new System.Drawing.Size(185, 25);
            this.lblWaktu.TabIndex = 11;
            this.lblWaktu.Text = "Waktu Keberangkatan";
            // 
            // txtWaktu
            // 
            this.txtWaktu.Location = new System.Drawing.Point(820, 462);
            this.txtWaktu.Name = "txtWaktu";
            this.txtWaktu.Size = new System.Drawing.Size(230, 31);
            this.txtWaktu.TabIndex = 11;
            this.txtWaktu.Text = "00:00";
            // 
            // lblDurasi
            // 
            this.lblDurasi.AutoSize = true;
            this.lblDurasi.Location = new System.Drawing.Point(640, 505);
            this.lblDurasi.Name = "lblDurasi";
            this.lblDurasi.Size = new System.Drawing.Size(170, 25);
            this.lblDurasi.TabIndex = 12;
            this.lblDurasi.Text = "Durasi Penerbangan";
            // 
            // txtDurasi
            // 
            this.txtDurasi.Location = new System.Drawing.Point(820, 502);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.Size = new System.Drawing.Size(230, 31);
            this.txtDurasi.TabIndex = 12;
            // 
            // lblHarga
            // 
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(640, 545);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(133, 25);
            this.lblHarga.TabIndex = 13;
            this.lblHarga.Text = "Harga per Tiket";
            // 
            // numHarga
            // 
            this.numHarga.Location = new System.Drawing.Point(820, 542);
            this.numHarga.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numHarga.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHarga.Name = "numHarga";
            this.numHarga.Size = new System.Drawing.Size(230, 31);
            this.numHarga.TabIndex = 13;
            this.numHarga.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(820, 595);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(105, 35);
            this.btnBatal.TabIndex = 14;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(945, 595);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(105, 35);
            this.btnSimpan.TabIndex = 15;
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
            // Form6JadwalPenerbangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1161, 650);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.numHarga);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.lblDurasi);
            this.Controls.Add(this.txtWaktu);
            this.Controls.Add(this.lblWaktu);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.cmbMaskapaiInput);
            this.Controls.Add(this.lblMaskapaiInput);
            this.Controls.Add(this.cmbKe);
            this.Controls.Add(this.lblKe);
            this.Controls.Add(this.cmbDari);
            this.Controls.Add(this.lblDari);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.dgvJadwal);
            this.Controls.Add(this.lblPageDesc);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6JadwalPenerbangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bromo Airlines - Admin";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHarga)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaskapai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWaktu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHarga;
        private System.Windows.Forms.DataGridViewButtonColumn colUbah;
        private System.Windows.Forms.DataGridViewButtonColumn colHapus;
        private System.Windows.Forms.Label lblKode;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.Label lblDari;
        private System.Windows.Forms.ComboBox cmbDari;
        private System.Windows.Forms.Label lblKe;
        private System.Windows.Forms.ComboBox cmbKe;
        private System.Windows.Forms.Label lblMaskapaiInput;
        private System.Windows.Forms.ComboBox cmbMaskapaiInput;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label lblWaktu;
        private System.Windows.Forms.TextBox txtWaktu;
        private System.Windows.Forms.Label lblDurasi;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.NumericUpDown numHarga;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
    }
}
