namespace MINIPOS
{
    partial class FrmHoaDonNhapChoQuanLy
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSuDung = new System.Windows.Forms.Button();
            this.dgvMaster = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMiniPOSInventory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaiDat = new FontAwesome.Sharp.IconButton();
            this.btnBaoCao = new FontAwesome.Sharp.IconButton();
            this.btnXemHDNhap = new FontAwesome.Sharp.IconButton();
            this.btnKhuyenMai = new FontAwesome.Sharp.IconButton();
            this.btnNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnKho = new FontAwesome.Sharp.IconButton();
            this.btnBanHang = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.ColumnHeadersVisible = false;
            this.dgvDetail.Location = new System.Drawing.Point(533, 56);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.Size = new System.Drawing.Size(237, 365);
            this.dgvDetail.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(398, 190);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(83, 41);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSuDung
            // 
            this.btnSuDung.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSuDung.FlatAppearance.BorderSize = 0;
            this.btnSuDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuDung.ForeColor = System.Drawing.Color.White;
            this.btnSuDung.Location = new System.Drawing.Point(398, 261);
            this.btnSuDung.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuDung.Name = "btnSuDung";
            this.btnSuDung.Size = new System.Drawing.Size(83, 41);
            this.btnSuDung.TabIndex = 2;
            this.btnSuDung.Text = "Sử dụng";
            this.btnSuDung.UseVisualStyleBackColor = false;
            this.btnSuDung.Click += new System.EventHandler(this.btnSuDung_Click);
            // 
            // dgvMaster
            // 
            this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaster.Location = new System.Drawing.Point(110, 56);
            this.dgvMaster.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaster.Name = "dgvMaster";
            this.dgvMaster.RowHeadersWidth = 51;
            this.dgvMaster.RowTemplate.Height = 24;
            this.dgvMaster.Size = new System.Drawing.Size(237, 365);
            this.dgvMaster.TabIndex = 3;
            this.dgvMaster.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.lblMiniPOSInventory);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 52);
            this.panel2.TabIndex = 34;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.btnCaiDat);
            this.panel1.Controls.Add(this.btnBaoCao);
            this.panel1.Controls.Add(this.btnXemHDNhap);
            this.panel1.Controls.Add(this.btnKhuyenMai);
            this.panel1.Controls.Add(this.btnNhanVien);
            this.panel1.Controls.Add(this.btnKhachHang);
            this.panel1.Controls.Add(this.btnKho);
            this.panel1.Controls.Add(this.btnBanHang);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 371);
            this.panel1.TabIndex = 35;
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnCaiDat.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCaiDat.FlatAppearance.BorderSize = 0;
            this.btnCaiDat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnCaiDat.IconColor = System.Drawing.Color.White;
            this.btnCaiDat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaiDat.IconSize = 22;
            this.btnCaiDat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaiDat.Location = new System.Drawing.Point(0, 323);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(105, 46);
            this.btnCaiDat.TabIndex = 19;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaiDat.UseVisualStyleBackColor = false;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.btnBaoCao.IconColor = System.Drawing.Color.White;
            this.btnBaoCao.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBaoCao.IconSize = 22;
            this.btnBaoCao.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 277);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(105, 46);
            this.btnBaoCao.TabIndex = 18;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnXemHDNhap
            // 
            this.btnXemHDNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnXemHDNhap.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnXemHDNhap.FlatAppearance.BorderSize = 0;
            this.btnXemHDNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnXemHDNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemHDNhap.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemHDNhap.ForeColor = System.Drawing.Color.White;
            this.btnXemHDNhap.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnXemHDNhap.IconColor = System.Drawing.Color.White;
            this.btnXemHDNhap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemHDNhap.IconSize = 22;
            this.btnXemHDNhap.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXemHDNhap.Location = new System.Drawing.Point(0, 231);
            this.btnXemHDNhap.Name = "btnXemHDNhap";
            this.btnXemHDNhap.Size = new System.Drawing.Size(105, 46);
            this.btnXemHDNhap.TabIndex = 17;
            this.btnXemHDNhap.Text = "Hóa đơn nháp";
            this.btnXemHDNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXemHDNhap.UseVisualStyleBackColor = false;
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnKhuyenMai.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnKhuyenMai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhuyenMai.ForeColor = System.Drawing.Color.White;
            this.btnKhuyenMai.IconChar = FontAwesome.Sharp.IconChar.TicketSimple;
            this.btnKhuyenMai.IconColor = System.Drawing.Color.White;
            this.btnKhuyenMai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhuyenMai.IconSize = 22;
            this.btnKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 186);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.Size = new System.Drawing.Size(105, 46);
            this.btnKhuyenMai.TabIndex = 16;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKhuyenMai.UseVisualStyleBackColor = false;
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnNhanVien.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnNhanVien.IconColor = System.Drawing.Color.White;
            this.btnNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNhanVien.IconSize = 22;
            this.btnNhanVien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 140);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(105, 46);
            this.btnNhanVien.TabIndex = 15;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnKhachHang.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(122)))), ((int)(((byte)(172)))));
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnKhachHang.IconColor = System.Drawing.Color.White;
            this.btnKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhachHang.IconSize = 22;
            this.btnKhachHang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 94);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(105, 46);
            this.btnKhachHang.TabIndex = 14;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnKho
            // 
            this.btnKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnKho.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
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
            this.btnKho.Location = new System.Drawing.Point(0, 48);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(105, 46);
            this.btnKho.TabIndex = 13;
            this.btnKho.Text = "Kho";
            this.btnKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKho.UseVisualStyleBackColor = false;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(107)))), ((int)(((byte)(154)))));
            this.btnBanHang.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
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
            this.btnBanHang.Location = new System.Drawing.Point(0, 3);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(105, 46);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBanHang.UseVisualStyleBackColor = false;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // FrmHoaDonNhapChoQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 424);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMaster);
            this.Controls.Add(this.btnSuDung);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvDetail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmHoaDonNhapChoQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn Nháp (dành cho quản lý)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmHoaDonNhap_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSuDung;
        private System.Windows.Forms.DataGridView dgvMaster;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMiniPOSInventory;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCaiDat;
        private FontAwesome.Sharp.IconButton btnBaoCao;
        private FontAwesome.Sharp.IconButton btnXemHDNhap;
        private FontAwesome.Sharp.IconButton btnKhuyenMai;
        private FontAwesome.Sharp.IconButton btnNhanVien;
        private FontAwesome.Sharp.IconButton btnKhachHang;
        private FontAwesome.Sharp.IconButton btnKho;
        private FontAwesome.Sharp.IconButton btnBanHang;
    }
}