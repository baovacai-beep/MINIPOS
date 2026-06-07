namespace MINIPOS
{
    partial class FrmKhoChoNhanVien
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMiniPOSInventory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaiDat = new FontAwesome.Sharp.IconButton();
            this.btnXemHDNhap = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnKho = new FontAwesome.Sharp.IconButton();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMax)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvSanPham);
            this.panel4.Location = new System.Drawing.Point(109, 166);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(661, 255);
            this.panel4.TabIndex = 85;
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
            this.dgvSanPham.Size = new System.Drawing.Size(659, 253);
            this.dgvSanPham.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
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
            this.panel3.Size = new System.Drawing.Size(661, 106);
            this.panel3.TabIndex = 84;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(72)))), ((int)(((byte)(112)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(438, 5);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(216, 28);
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
            this.txtTimKiem.Size = new System.Drawing.Size(432, 26);
            this.txtTimKiem.TabIndex = 38;
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(2, 41);
            this.cboLoai.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(148, 27);
            this.cboLoai.TabIndex = 39;
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(186, 44);
            this.lblGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(32, 19);
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
            this.nudGiaMin.Location = new System.Drawing.Point(213, 41);
            this.nudGiaMin.Margin = new System.Windows.Forms.Padding(2);
            this.nudGiaMin.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaMin.Name = "nudGiaMin";
            this.nudGiaMin.Size = new System.Drawing.Size(93, 26);
            this.nudGiaMin.TabIndex = 41;
            this.nudGiaMin.ThousandsSeparator = true;
            // 
            // lblGach
            // 
            this.lblGach.AutoSize = true;
            this.lblGach.Location = new System.Drawing.Point(218, 44);
            this.lblGach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGach.Name = "lblGach";
            this.lblGach.Size = new System.Drawing.Size(15, 19);
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
            this.nudGiaMax.Location = new System.Drawing.Point(337, 41);
            this.nudGiaMax.Margin = new System.Windows.Forms.Padding(2);
            this.nudGiaMax.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGiaMax.Name = "nudGiaMax";
            this.nudGiaMax.Size = new System.Drawing.Size(97, 26);
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
            this.cboTonKho.Size = new System.Drawing.Size(432, 27);
            this.cboTonKho.TabIndex = 44;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(438, 70);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(106, 23);
            this.btnLoc.TabIndex = 45;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnXoaLoc
            // 
            this.btnXoaLoc.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXoaLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaLoc.Location = new System.Drawing.Point(548, 71);
            this.btnXoaLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(106, 23);
            this.btnXoaLoc.TabIndex = 46;
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.lblMiniPOSInventory);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 52);
            this.panel2.TabIndex = 87;
            // 
            // lblMiniPOSInventory
            // 
            this.lblMiniPOSInventory.AutoSize = true;
            this.lblMiniPOSInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiniPOSInventory.ForeColor = System.Drawing.Color.White;
            this.lblMiniPOSInventory.Location = new System.Drawing.Point(2, 15);
            this.lblMiniPOSInventory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMiniPOSInventory.Name = "lblMiniPOSInventory";
            this.lblMiniPOSInventory.Size = new System.Drawing.Size(360, 29);
            this.lblMiniPOSInventory.TabIndex = 2;
            this.lblMiniPOSInventory.Text = "MiniPOS - Cửa hàng Tiện lợi";
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 371);
            this.panel1.TabIndex = 86;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.FlatAppearance.BorderSize = 0;
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnXemHDNhap.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnKho.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // 
            // btnBanHang
            // 
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // FrmKhoChoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(771, 424);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmKhoChoNhanVien";
            this.Text = "Xem Kho (dành cho nhân viên)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmKhoChoNhanVien_FormClosed);
            this.Load += new System.EventHandler(this.InventoryForStaff_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaMax)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSanPham;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMiniPOSInventory;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private FontAwesome.Sharp.IconButton btnXemHDNhap;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnKho;
        private FontAwesome.Sharp.IconButton btnBanHang;
    }
}