namespace MINIPOS
{
    partial class FrmBanHangChoNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaiDat = new FontAwesome.Sharp.IconButton();
            this.btnXemHDNhap = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnKho = new FontAwesome.Sharp.IconButton();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMiniPOSInventory = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblGia = new System.Windows.Forms.Label();
            this.nudGiaMin = new System.Windows.Forms.NumericUpDown();
            this.lblGach = new System.Windows.Forms.Label();
            this.nudGiaMax = new System.Windows.Forms.NumericUpDown();
            this.cboTonKho = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnXoaLoc = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXoaHang = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSLTonToiThieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuTam = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnVoucher = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMax)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.panel1.Controls.Add(this.btnCaiDat);
            this.panel1.Controls.Add(this.btnXemHDNhap);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.btnKho);
            this.panel1.Controls.Add(this.btnBanHang);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 371);
            this.panel1.TabIndex = 41;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.FlatAppearance.BorderSize = 0;
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnCaiDat.IconColor = System.Drawing.Color.White;
            this.btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaiDat.IconSize = 22;
            this.btnCaiDat.Location = new System.Drawing.Point(0, 258);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(105, 46);
            this.btnCaiDat.TabIndex = 19;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaiDat.UseVisualStyleBackColor = true;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // btnXemHDNhap
            // 
            this.btnXemHDNhap.FlatAppearance.BorderSize = 0;
            this.btnXemHDNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnXemHDNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemHDNhap.ForeColor = System.Drawing.Color.White;
            this.btnXemHDNhap.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnXemHDNhap.IconColor = System.Drawing.Color.White;
            this.btnXemHDNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemHDNhap.IconSize = 22;
            this.btnXemHDNhap.Location = new System.Drawing.Point(0, 207);
            this.btnXemHDNhap.Name = "btnXemHDNhap";
            this.btnXemHDNhap.Size = new System.Drawing.Size(105, 46);
            this.btnXemHDNhap.TabIndex = 17;
            this.btnXemHDNhap.Text = "Hóa đơn nháp";
            this.btnXemHDNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXemHDNhap.UseVisualStyleBackColor = true;
            this.btnXemHDNhap.Click += new System.EventHandler(this.btnXemHDNhap_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnKhachHang.IconColor = System.Drawing.Color.White;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.IconSize = 22;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 156);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(105, 46);
            this.btnKhachHang.TabIndex = 14;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnKho
            // 
            this.btnKho.FlatAppearance.BorderSize = 0;
            this.btnKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.ForeColor = System.Drawing.Color.White;
            this.btnKho.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnKho.IconColor = System.Drawing.Color.White;
            this.btnKho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKho.IconSize = 22;
            this.btnKho.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKho.Location = new System.Drawing.Point(0, 105);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(105, 46);
            this.btnKho.TabIndex = 13;
            this.btnKho.Text = "Kho";
            this.btnKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnBanHang.IconColor = System.Drawing.Color.White;
            this.btnBanHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBanHang.IconSize = 22;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBanHang.Location = new System.Drawing.Point(0, 54);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(105, 46);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBanHang.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.lblMiniPOSInventory);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 52);
            this.panel2.TabIndex = 46;
            // 
            // lblMiniPOSInventory
            // 
            this.lblMiniPOSInventory.AutoSize = true;
            this.lblMiniPOSInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiniPOSInventory.ForeColor = System.Drawing.Color.White;
            this.lblMiniPOSInventory.Location = new System.Drawing.Point(2, 15);
            this.lblMiniPOSInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMiniPOSInventory.Name = "lblMiniPOSInventory";
            this.lblMiniPOSInventory.Size = new System.Drawing.Size(289, 25);
            this.lblMiniPOSInventory.TabIndex = 2;
            this.lblMiniPOSInventory.Text = "MiniPOS - Cửa hàng Tiện lợi";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Controls.Add(this.cboLoai);
            this.panel3.Controls.Add(this.lblGia);
            this.panel3.Controls.Add(this.nudGiaMin);
            this.panel3.Controls.Add(this.lblGach);
            this.panel3.Controls.Add(this.nudGiaMax);
            this.panel3.Controls.Add(this.cboTonKho);
            this.panel3.Controls.Add(this.btnLoc);
            this.panel3.Controls.Add(this.btnXoaLoc);
            this.panel3.Location = new System.Drawing.Point(109, 56);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 106);
            this.panel3.TabIndex = 47;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(72)))), ((int)(((byte)(112)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(314, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(76, 28);
            this.btnTimKiem.TabIndex = 37;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(2, 8);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(308, 22);
            this.txtTimKiem.TabIndex = 38;
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(2, 41);
            this.cboLoai.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(114, 21);
            this.cboLoai.TabIndex = 39;
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(120, 44);
            this.lblGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(27, 13);
            this.lblGia.TabIndex = 40;
            this.lblGia.Text = "Giá:";
            // 
            // nudGiaMin
            // 
            this.nudGiaMin.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaMin.Location = new System.Drawing.Point(147, 41);
            this.nudGiaMin.Margin = new System.Windows.Forms.Padding(2);
            this.nudGiaMin.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaMin.Name = "nudGiaMin";
            this.nudGiaMin.Size = new System.Drawing.Size(68, 22);
            this.nudGiaMin.TabIndex = 41;
            this.nudGiaMin.ThousandsSeparator = true;
            // 
            // lblGach
            // 
            this.lblGach.AutoSize = true;
            this.lblGach.Location = new System.Drawing.Point(218, 44);
            this.lblGach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGach.Name = "lblGach";
            this.lblGach.Size = new System.Drawing.Size(11, 13);
            this.lblGach.TabIndex = 42;
            this.lblGach.Text = "-";
            // 
            // nudGiaMax
            // 
            this.nudGiaMax.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGiaMax.Location = new System.Drawing.Point(233, 41);
            this.nudGiaMax.Margin = new System.Windows.Forms.Padding(2);
            this.nudGiaMax.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaMax.Name = "nudGiaMax";
            this.nudGiaMax.Size = new System.Drawing.Size(68, 22);
            this.nudGiaMax.TabIndex = 43;
            this.nudGiaMax.ThousandsSeparator = true;
            // 
            // cboTonKho
            // 
            this.cboTonKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTonKho.FormattingEnabled = true;
            this.cboTonKho.Location = new System.Drawing.Point(2, 73);
            this.cboTonKho.Margin = new System.Windows.Forms.Padding(2);
            this.cboTonKho.Name = "cboTonKho";
            this.cboTonKho.Size = new System.Drawing.Size(114, 21);
            this.cboTonKho.TabIndex = 44;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(131, 70);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(68, 28);
            this.btnLoc.TabIndex = 45;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnXoaLoc
            // 
            this.btnXoaLoc.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoaLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoc.Location = new System.Drawing.Point(203, 70);
            this.btnXoaLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(75, 28);
            this.btnXoaLoc.TabIndex = 46;
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Location = new System.Drawing.Point(108, 166);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(394, 255);
            this.panel4.TabIndex = 48;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(2, 2);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(389, 251);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(76)))), ((int)(((byte)(116)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(506, 56);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(264, 36);
            this.panel7.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Giỏ hàng";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnXoaHang);
            this.panel5.Controls.Add(this.dgvGioHang);
            this.panel5.Controls.Add(this.btnLuuTam);
            this.panel5.Controls.Add(this.btnThanhToan);
            this.panel5.Controls.Add(this.btnVoucher);
            this.panel5.Controls.Add(this.txtTongTien);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(504, 96);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(266, 325);
            this.panel5.TabIndex = 49;
            // 
            // btnXoaHang
            // 
            this.btnXoaHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(50)))), ((int)(((byte)(66)))));
            this.btnXoaHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnXoaHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHang.ForeColor = System.Drawing.Color.White;
            this.btnXoaHang.Location = new System.Drawing.Point(182, 243);
            this.btnXoaHang.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaHang.Name = "btnXoaHang";
            this.btnXoaHang.Size = new System.Drawing.Size(82, 26);
            this.btnXoaHang.TabIndex = 42;
            this.btnXoaHang.Text = "Xóa hàng";
            this.btnXoaHang.UseVisualStyleBackColor = false;
            this.btnXoaHang.Click += new System.EventHandler(this.btnXoaHang_Click);
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colSTT,
            this.colTen,
            this.colGia,
            this.colSL,
            this.colTT,
            this.colSLTonToiThieu});
            this.dgvGioHang.Location = new System.Drawing.Point(2, 4);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.Size = new System.Drawing.Size(261, 227);
            this.dgvGioHang.TabIndex = 41;
            this.dgvGioHang.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellEndEdit);
            // 
            // colMaSP
            // 
            this.colMaSP.HeaderText = "MaSP";
            this.colMaSP.MinimumWidth = 6;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Visible = false;
            this.colMaSP.Width = 6;
            // 
            // colSTT
            // 
            this.colSTT.FillWeight = 13.84564F;
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 40;
            // 
            // colTen
            // 
            this.colTen.FillWeight = 80.31593F;
            this.colTen.HeaderText = "Tên sản phẩm";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            this.colTen.Width = 110;
            // 
            // colGia
            // 
            this.colGia.FillWeight = 93.36166F;
            this.colGia.HeaderText = "Đơn giá";
            this.colGia.MinimumWidth = 6;
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            this.colGia.Width = 70;
            // 
            // colSL
            // 
            this.colSL.FillWeight = 45.09702F;
            this.colSL.HeaderText = "SL";
            this.colSL.MinimumWidth = 6;
            this.colSL.Name = "colSL";
            this.colSL.Width = 40;
            // 
            // colTT
            // 
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.colTT.DefaultCellStyle = dataGridViewCellStyle12;
            this.colTT.FillWeight = 267.3796F;
            this.colTT.HeaderText = "Thành tiền";
            this.colTT.MinimumWidth = 6;
            this.colTT.Name = "colTT";
            this.colTT.ReadOnly = true;
            this.colTT.Width = 83;
            // 
            // colSLTonToiThieu
            // 
            this.colSLTonToiThieu.HeaderText = "SLTonToiThieu";
            this.colSLTonToiThieu.MinimumWidth = 6;
            this.colSLTonToiThieu.Name = "colSLTonToiThieu";
            this.colSLTonToiThieu.ReadOnly = true;
            this.colSLTonToiThieu.Visible = false;
            this.colSLTonToiThieu.Width = 6;
            // 
            // btnLuuTam
            // 
            this.btnLuuTam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(214)))), ((int)(((byte)(227)))));
            this.btnLuuTam.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLuuTam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuTam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuTam.Location = new System.Drawing.Point(182, 280);
            this.btnLuuTam.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuuTam.Name = "btnLuuTam";
            this.btnLuuTam.Size = new System.Drawing.Size(82, 45);
            this.btnLuuTam.TabIndex = 40;
            this.btnLuuTam.Text = "Lưu HĐ";
            this.btnLuuTam.UseVisualStyleBackColor = false;
            this.btnLuuTam.Click += new System.EventHandler(this.btnLuuTam_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThanhToan.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(91, 280);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(82, 45);
            this.btnThanhToan.TabIndex = 39;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.BtnThanhToan_Click);
            // 
            // btnVoucher
            // 
            this.btnVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(211)))), ((int)(((byte)(189)))));
            this.btnVoucher.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucher.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher.ForeColor = System.Drawing.Color.Black;
            this.btnVoucher.Location = new System.Drawing.Point(2, 280);
            this.btnVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(82, 45);
            this.btnVoucher.TabIndex = 38;
            this.btnVoucher.Text = "Voucher";
            this.btnVoucher.UseVisualStyleBackColor = false;
            this.btnVoucher.Click += new System.EventHandler(this.BtnTraCuuKhachHang_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(2, 243);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(171, 26);
            this.txtTongTien.TabIndex = 37;
            this.txtTongTien.Text = "Tổng tiền";
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(314, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(161, 32);
            this.panel6.TabIndex = 35;
            // 
            // FrmBanHangChoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(771, 424);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBanHangChoNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán Hàng (dành cho nhân viên)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormForStaff_FormClosed);
            this.Load += new System.EventHandler(this.MainFormForStaff_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMax)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private FontAwesome.Sharp.IconButton btnXemHDNhap;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnKho;
        private FontAwesome.Sharp.IconButton btnBanHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMiniPOSInventory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.NumericUpDown nudGiaMin;
        private System.Windows.Forms.Label lblGach;
        private System.Windows.Forms.NumericUpDown nudGiaMax;
        private System.Windows.Forms.ComboBox cboTonKho;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnXoaLoc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXoaHang;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSLTonToiThieu;
        private System.Windows.Forms.Button btnLuuTam;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnVoucher;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Panel panel6;
    }
}