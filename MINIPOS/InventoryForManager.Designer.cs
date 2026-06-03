namespace MINIPOS
{
    partial class InventoryForManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaiDat = new FontAwesome.Sharp.IconButton();
            this.btnBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnHoaDonNhap = new FontAwesome.Sharp.IconButton();
            this.btnKhuyenMai = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnKho = new FontAwesome.Sharp.IconButton();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMiniPOSInventory = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimSP = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblImportPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lvlProductName = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.nudSellPrice = new System.Windows.Forms.NumericUpDown();
            this.nudImportPrice = new System.Windows.Forms.NumericUpDown();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImportPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnCaiDat);
            this.panel1.Controls.Add(this.btnBaoCao);
            this.panel1.Controls.Add(this.btnHoaDonNhap);
            this.panel1.Controls.Add(this.btnKhuyenMai);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.btnKho);
            this.panel1.Controls.Add(this.btnBanHang);
            this.panel1.Location = new System.Drawing.Point(15, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 501);
            this.panel1.TabIndex = 35;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnCaiDat.IconColor = System.Drawing.Color.IndianRed;
            this.btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaiDat.IconSize = 33;
            this.btnCaiDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaiDat.Location = new System.Drawing.Point(-1, 400);
            this.btnCaiDat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(140, 48);
            this.btnCaiDat.TabIndex = 19;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaiDat.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnBaoCao.IconColor = System.Drawing.Color.IndianRed;
            this.btnBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaoCao.IconSize = 33;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.Location = new System.Drawing.Point(-1, 345);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(140, 48);
            this.btnBaoCao.TabIndex = 18;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            // 
            // btnHoaDonNhap
            // 
            this.btnHoaDonNhap.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnHoaDonNhap.IconColor = System.Drawing.Color.IndianRed;
            this.btnHoaDonNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHoaDonNhap.IconSize = 33;
            this.btnHoaDonNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoaDonNhap.Location = new System.Drawing.Point(-1, 289);
            this.btnHoaDonNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoaDonNhap.Name = "btnHoaDonNhap";
            this.btnHoaDonNhap.Size = new System.Drawing.Size(140, 48);
            this.btnHoaDonNhap.TabIndex = 17;
            this.btnHoaDonNhap.Text = "Hóa đơn nháp";
            this.btnHoaDonNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoaDonNhap.UseVisualStyleBackColor = true;
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.IconChar = FontAwesome.Sharp.IconChar.TicketSimple;
            this.btnKhuyenMai.IconColor = System.Drawing.Color.IndianRed;
            this.btnKhuyenMai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhuyenMai.IconSize = 33;
            this.btnKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 234);
            this.btnKhuyenMai.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(140, 48);
            this.btnKhuyenMai.TabIndex = 16;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhuyenMai.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconButton1.IconColor = System.Drawing.Color.IndianRed;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 33;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(-1, 178);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(140, 48);
            this.iconButton1.TabIndex = 15;
            this.iconButton1.Text = "Nhân viên";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnKhachHang.IconColor = System.Drawing.Color.IndianRed;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.IconSize = 33;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhachHang.Location = new System.Drawing.Point(-1, 123);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(140, 48);
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
            this.btnKho.Location = new System.Drawing.Point(-1, 68);
            this.btnKho.Margin = new System.Windows.Forms.Padding(4);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(140, 48);
            this.btnKho.TabIndex = 13;
            this.btnKho.Text = "Kho";
            this.btnKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKho.UseVisualStyleBackColor = true;
            // 
            // btnBanHang
            // 
            this.btnBanHang.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnBanHang.IconColor = System.Drawing.Color.IndianRed;
            this.btnBanHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBanHang.IconSize = 33;
            this.btnBanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.Location = new System.Drawing.Point(-1, 12);
            this.btnBanHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(140, 48);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.lblMiniPOSInventory);
            this.panel2.Location = new System.Drawing.Point(15, 14);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 63);
            this.panel2.TabIndex = 34;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Controls.Add(this.btnCapNhat);
            this.panel4.Controls.Add(this.btnThemSP);
            this.panel4.Location = new System.Drawing.Point(160, 257);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(901, 338);
            this.panel4.TabIndex = 46;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(740, 278);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(143, 43);
            this.btnXoa.TabIndex = 63;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(0, 9);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(880, 263);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(589, 278);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCapNhat.Size = new System.Drawing.Size(143, 43);
            this.btnCapNhat.TabIndex = 62;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.Location = new System.Drawing.Point(439, 278);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnThemSP.Size = new System.Drawing.Size(143, 43);
            this.btnThemSP.TabIndex = 61;
            this.btnThemSP.Text = "Thêm SP";
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTimSP);
            this.panel3.Controls.Add(this.lblUnit);
            this.panel3.Controls.Add(this.lblQuantity);
            this.panel3.Controls.Add(this.lblSellPrice);
            this.panel3.Controls.Add(this.lblImportPrice);
            this.panel3.Controls.Add(this.lblCategory);
            this.panel3.Controls.Add(this.lblBarcode);
            this.panel3.Controls.Add(this.lvlProductName);
            this.panel3.Controls.Add(this.txtUnit);
            this.panel3.Controls.Add(this.nudQuantity);
            this.panel3.Controls.Add(this.nudSellPrice);
            this.panel3.Controls.Add(this.nudImportPrice);
            this.panel3.Controls.Add(this.cboCategory);
            this.panel3.Controls.Add(this.txtBarcode);
            this.panel3.Controls.Add(this.txtProductName);
            this.panel3.Location = new System.Drawing.Point(160, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 180);
            this.panel3.TabIndex = 45;
            // 
            // btnTimSP
            // 
            this.btnTimSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimSP.Location = new System.Drawing.Point(695, 53);
            this.btnTimSP.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimSP.Name = "btnTimSP";
            this.btnTimSP.Size = new System.Drawing.Size(143, 78);
            this.btnTimSP.TabIndex = 64;
            this.btnTimSP.Text = "Tìm SP";
            this.btnTimSP.UseVisualStyleBackColor = true;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(9, 150);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(61, 20);
            this.lblUnit.TabIndex = 60;
            this.lblUnit.Text = "Đơn vị:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(9, 121);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(79, 20);
            this.lblQuantity.TabIndex = 59;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellPrice.Location = new System.Drawing.Point(9, 94);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(72, 20);
            this.lblSellPrice.TabIndex = 58;
            this.lblSellPrice.Text = "Giá bán:";
            // 
            // lblImportPrice
            // 
            this.lblImportPrice.AutoSize = true;
            this.lblImportPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportPrice.Location = new System.Drawing.Point(9, 65);
            this.lblImportPrice.Name = "lblImportPrice";
            this.lblImportPrice.Size = new System.Drawing.Size(81, 20);
            this.lblImportPrice.TabIndex = 57;
            this.lblImportPrice.Text = "Giá nhập:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(9, 36);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(46, 20);
            this.lblCategory.TabIndex = 56;
            this.lblCategory.Text = "Loại:";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(9, 9);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(77, 20);
            this.lblBarcode.TabIndex = 55;
            this.lblBarcode.Text = "Barcode:";
            // 
            // lvlProductName
            // 
            this.lvlProductName.AutoSize = true;
            this.lvlProductName.Location = new System.Drawing.Point(137, -27);
            this.lvlProductName.Name = "lvlProductName";
            this.lvlProductName.Size = new System.Drawing.Size(96, 16);
            this.lvlProductName.TabIndex = 54;
            this.lvlProductName.Text = "Tên sản phẩm:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(151, 148);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(508, 22);
            this.txtUnit.TabIndex = 53;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(151, 119);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(509, 22);
            this.nudQuantity.TabIndex = 52;
            // 
            // nudSellPrice
            // 
            this.nudSellPrice.Location = new System.Drawing.Point(151, 91);
            this.nudSellPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudSellPrice.Name = "nudSellPrice";
            this.nudSellPrice.Size = new System.Drawing.Size(509, 22);
            this.nudSellPrice.TabIndex = 51;
            // 
            // nudImportPrice
            // 
            this.nudImportPrice.Location = new System.Drawing.Point(151, 63);
            this.nudImportPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudImportPrice.Name = "nudImportPrice";
            this.nudImportPrice.Size = new System.Drawing.Size(509, 22);
            this.nudImportPrice.TabIndex = 50;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(151, 33);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(508, 24);
            this.cboCategory.TabIndex = 49;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(151, 5);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(508, 22);
            this.txtBarcode.TabIndex = 48;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(279, -31);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(467, 22);
            this.txtProductName.TabIndex = 47;
            // 
            // InventoryForManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 656);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InventoryForManager";
            this.Text = "Quản Lý Kho (dành cho quản lý)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InventoryForManager_FormClosed);
            this.Load += new System.EventHandler(this.InventoryForManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImportPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private FontAwesome.Sharp.IconButton btnBaoCao;
        private FontAwesome.Sharp.IconButton btnHoaDonNhap;
        private FontAwesome.Sharp.IconButton btnKhuyenMai;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnKho;
        private FontAwesome.Sharp.IconButton btnBanHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMiniPOSInventory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblImportPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lvlProductName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.NumericUpDown nudSellPrice;
        private System.Windows.Forms.NumericUpDown nudImportPrice;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnTimSP;
    }
}