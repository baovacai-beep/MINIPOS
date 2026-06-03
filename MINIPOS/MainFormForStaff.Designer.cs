namespace MINIPOS
{
    partial class MainFormForStaff
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
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnDrink = new System.Windows.Forms.Button();
            this.btnBanhKeo = new System.Windows.Forms.Button();
            this.btnMi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnVPP = new System.Windows.Forms.Button();
            this.btnMyPham = new System.Windows.Forms.Button();
            this.btnGiaVi = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXoaHang = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnVoucher = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaiDat = new FontAwesome.Sharp.IconButton();
            this.btnHoaDonNhap = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnKho = new FontAwesome.Sharp.IconButton();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMiniPOSInventory = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(704, 86);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(351, 44);
            this.panel7.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "Giỏ hàng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Location = new System.Drawing.Point(171, 191);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(521, 407);
            this.panel4.TabIndex = 44;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(3, 2);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(515, 329);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.btnAll);
            this.flowLayoutPanel1.Controls.Add(this.btnDrink);
            this.flowLayoutPanel1.Controls.Add(this.btnBanhKeo);
            this.flowLayoutPanel1.Controls.Add(this.btnMi);
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnVPP);
            this.flowLayoutPanel1.Controls.Add(this.btnMyPham);
            this.flowLayoutPanel1.Controls.Add(this.btnGiaVi);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(171, 135);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 48);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(3, 2);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(115, 41);
            this.btnAll.TabIndex = 38;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnDrink
            // 
            this.btnDrink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrink.Location = new System.Drawing.Point(124, 2);
            this.btnDrink.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Size = new System.Drawing.Size(115, 41);
            this.btnDrink.TabIndex = 8;
            this.btnDrink.Text = "Nước uống";
            this.btnDrink.UseVisualStyleBackColor = true;
            this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
            // 
            // btnBanhKeo
            // 
            this.btnBanhKeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanhKeo.Location = new System.Drawing.Point(245, 2);
            this.btnBanhKeo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBanhKeo.Name = "btnBanhKeo";
            this.btnBanhKeo.Size = new System.Drawing.Size(115, 41);
            this.btnBanhKeo.TabIndex = 39;
            this.btnBanhKeo.Text = "Bánh Kẹo";
            this.btnBanhKeo.UseVisualStyleBackColor = true;
            this.btnBanhKeo.Click += new System.EventHandler(this.btnBanhKeo_Click);
            // 
            // btnMi
            // 
            this.btnMi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMi.Location = new System.Drawing.Point(366, 2);
            this.btnMi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMi.Name = "btnMi";
            this.btnMi.Size = new System.Drawing.Size(115, 41);
            this.btnMi.TabIndex = 40;
            this.btnMi.Text = "Mì+TPĂL";
            this.btnMi.UseVisualStyleBackColor = true;
            this.btnMi.Click += new System.EventHandler(this.btnMi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(3, 47);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(115, 41);
            this.btnSua.TabIndex = 41;
            this.btnSua.Text = "Sữa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnVPP
            // 
            this.btnVPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVPP.Location = new System.Drawing.Point(124, 47);
            this.btnVPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVPP.Name = "btnVPP";
            this.btnVPP.Size = new System.Drawing.Size(115, 41);
            this.btnVPP.TabIndex = 42;
            this.btnVPP.Text = "VPP";
            this.btnVPP.UseVisualStyleBackColor = true;
            this.btnVPP.Click += new System.EventHandler(this.btnVPP_Click);
            // 
            // btnMyPham
            // 
            this.btnMyPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyPham.Location = new System.Drawing.Point(245, 47);
            this.btnMyPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMyPham.Name = "btnMyPham";
            this.btnMyPham.Size = new System.Drawing.Size(115, 41);
            this.btnMyPham.TabIndex = 43;
            this.btnMyPham.Text = "Mỹ phẩm";
            this.btnMyPham.UseVisualStyleBackColor = true;
            this.btnMyPham.Click += new System.EventHandler(this.btnMyPham_Click);
            // 
            // btnGiaVi
            // 
            this.btnGiaVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaVi.Location = new System.Drawing.Point(366, 47);
            this.btnGiaVi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGiaVi.Name = "btnGiaVi";
            this.btnGiaVi.Size = new System.Drawing.Size(115, 41);
            this.btnGiaVi.TabIndex = 44;
            this.btnGiaVi.Text = "Gia vị+TPK";
            this.btnGiaVi.UseVisualStyleBackColor = true;
            this.btnGiaVi.Click += new System.EventHandler(this.btnGiaVi_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnXoaHang);
            this.panel5.Controls.Add(this.dgvGioHang);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.btnThanhToan);
            this.panel5.Controls.Add(this.btnVoucher);
            this.panel5.Controls.Add(this.txtTongTien);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(701, 135);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(355, 462);
            this.panel5.TabIndex = 43;
            // 
            // btnXoaHang
            // 
            this.btnXoaHang.BackColor = System.Drawing.Color.Red;
            this.btnXoaHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHang.Location = new System.Drawing.Point(243, 288);
            this.btnXoaHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaHang.Name = "btnXoaHang";
            this.btnXoaHang.Size = new System.Drawing.Size(109, 32);
            this.btnXoaHang.TabIndex = 42;
            this.btnXoaHang.Text = "Xóa hàng";
            this.btnXoaHang.UseVisualStyleBackColor = false;
            this.btnXoaHang.Click += new System.EventHandler(this.btnXoaHang_Click);
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Location = new System.Drawing.Point(3, 5);
            this.dgvGioHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersVisible = false;
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.Size = new System.Drawing.Size(348, 278);
            this.dgvGioHang.TabIndex = 41;
            this.dgvGioHang.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellEndEdit);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(243, 331);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 55);
            this.button1.TabIndex = 40;
            this.button1.Text = "Lưu HĐ";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.LimeGreen;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(121, 331);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(109, 55);
            this.btnThanhToan.TabIndex = 39;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnVoucher
            // 
            this.btnVoucher.BackColor = System.Drawing.Color.Yellow;
            this.btnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoucher.Location = new System.Drawing.Point(3, 331);
            this.btnVoucher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVoucher.Name = "btnVoucher";
            this.btnVoucher.Size = new System.Drawing.Size(109, 55);
            this.btnVoucher.TabIndex = 38;
            this.btnVoucher.Text = "Voucher";
            this.btnVoucher.UseVisualStyleBackColor = false;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(3, 288);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(227, 31);
            this.txtTongTien.TabIndex = 37;
            this.txtTongTien.Text = "Tổng tiền";
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(419, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(215, 39);
            this.panel6.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Location = new System.Drawing.Point(171, 86);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 47);
            this.panel3.TabIndex = 42;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(419, 5);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(101, 34);
            this.btnTimKiem.TabIndex = 37;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(3, 10);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(409, 26);
            this.txtTimKiem.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCaiDat);
            this.panel1.Controls.Add(this.btnHoaDonNhap);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.btnKho);
            this.panel1.Controls.Add(this.btnBanHang);
            this.panel1.Location = new System.Drawing.Point(28, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 501);
            this.panel1.TabIndex = 41;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnCaiDat.IconColor = System.Drawing.Color.IndianRed;
            this.btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaiDat.IconSize = 33;
            this.btnCaiDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaiDat.Location = new System.Drawing.Point(-1, 271);
            this.btnCaiDat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(140, 55);
            this.btnCaiDat.TabIndex = 19;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaiDat.UseVisualStyleBackColor = true;
            // 
            // btnHoaDonNhap
            // 
            this.btnHoaDonNhap.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnHoaDonNhap.IconColor = System.Drawing.Color.IndianRed;
            this.btnHoaDonNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHoaDonNhap.IconSize = 33;
            this.btnHoaDonNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDonNhap.Location = new System.Drawing.Point(-1, 208);
            this.btnHoaDonNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHoaDonNhap.Name = "btnHoaDonNhap";
            this.btnHoaDonNhap.Size = new System.Drawing.Size(140, 55);
            this.btnHoaDonNhap.TabIndex = 17;
            this.btnHoaDonNhap.Text = "Hóa đơn nháp";
            this.btnHoaDonNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoaDonNhap.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnKhachHang.IconColor = System.Drawing.Color.IndianRed;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.IconSize = 33;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(-1, 145);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(140, 55);
            this.btnKhachHang.TabIndex = 14;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnKho
            // 
            this.btnKho.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnKho.IconColor = System.Drawing.Color.IndianRed;
            this.btnKho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKho.IconSize = 33;
            this.btnKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKho.Location = new System.Drawing.Point(0, 82);
            this.btnKho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(140, 55);
            this.btnKho.TabIndex = 13;
            this.btnKho.Text = "Kho";
            this.btnKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnBanHang.IconColor = System.Drawing.Color.IndianRed;
            this.btnBanHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBanHang.IconSize = 33;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Location = new System.Drawing.Point(-1, 20);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(140, 55);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanHang.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.lblMiniPOSInventory);
            this.panel2.Location = new System.Drawing.Point(28, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 63);
            this.panel2.TabIndex = 40;
            // 
            // lblMiniPOSInventory
            // 
            this.lblMiniPOSInventory.AutoSize = true;
            this.lblMiniPOSInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiniPOSInventory.Location = new System.Drawing.Point(3, 18);
            this.lblMiniPOSInventory.Name = "lblMiniPOSInventory";
            this.lblMiniPOSInventory.Size = new System.Drawing.Size(360, 29);
            this.lblMiniPOSInventory.TabIndex = 2;
            this.lblMiniPOSInventory.Text = "MiniPOS - Cửa hàng Tiện lợi";
            // 
            // MainFormForStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 604);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainFormForStaff";
            this.Text = "Bán Hàng (dành cho nhân viên)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormForStaff_FormClosed);
            this.Load += new System.EventHandler(this.MainFormForStaff_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnDrink;
        private System.Windows.Forms.Button btnBanhKeo;
        private System.Windows.Forms.Button btnMi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnVPP;
        private System.Windows.Forms.Button btnMyPham;
        private System.Windows.Forms.Button btnGiaVi;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXoaHang;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnVoucher;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private FontAwesome.Sharp.IconButton btnHoaDonNhap;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnKho;
        private FontAwesome.Sharp.IconButton btnBanHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMiniPOSInventory;
    }
}