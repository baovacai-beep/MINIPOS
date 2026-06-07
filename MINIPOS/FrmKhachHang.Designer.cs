namespace MINIPOS
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnKhoaMo = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGhiChuDiem = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.panelThe = new System.Windows.Forms.Panel();
            this.lblTheGiam = new System.Windows.Forms.Label();
            this.lblTheDiem = new System.Windows.Forms.Label();
            this.lblTheHang = new System.Windows.Forms.Label();
            this.lblTheTen = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.btnTimKH = new System.Windows.Forms.Button();
            this.txtTimKH = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelThe.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.panelTimKiem.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(980, 56);
            this.panelHeader.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTieuDe.Location = new System.Drawing.Point(20, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(323, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Quản lý Khách hàng / Thành viên";
            //
            // panelRight
            //
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.btnLamMoi);
            this.panelRight.Controls.Add(this.btnKhoaMo);
            this.panelRight.Controls.Add(this.btnLuu);
            this.panelRight.Controls.Add(this.btnThem);
            this.panelRight.Controls.Add(this.lblGhiChuDiem);
            this.panelRight.Controls.Add(this.txtDiaChi);
            this.panelRight.Controls.Add(this.lblDiaChi);
            this.panelRight.Controls.Add(this.txtSDT);
            this.panelRight.Controls.Add(this.lblSDT);
            this.panelRight.Controls.Add(this.txtTen);
            this.panelRight.Controls.Add(this.lblTen);
            this.panelRight.Controls.Add(this.panelThe);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(640, 56);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(340, 544);
            this.panelRight.TabIndex = 1;
            //
            // btnLamMoi
            //
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLamMoi.Location = new System.Drawing.Point(16, 424);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(308, 32);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới form";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            //
            // btnKhoaMo
            //
            this.btnKhoaMo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnKhoaMo.FlatAppearance.BorderSize = 0;
            this.btnKhoaMo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoaMo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKhoaMo.ForeColor = System.Drawing.Color.White;
            this.btnKhoaMo.Location = new System.Drawing.Point(224, 380);
            this.btnKhoaMo.Name = "btnKhoaMo";
            this.btnKhoaMo.Size = new System.Drawing.Size(100, 36);
            this.btnKhoaMo.TabIndex = 10;
            this.btnKhoaMo.Text = "Khóa";
            this.btnKhoaMo.UseVisualStyleBackColor = false;
            //
            // btnLuu
            //
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(120, 380);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 36);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            //
            // btnThem
            //
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(16, 380);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 36);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            //
            // lblGhiChuDiem
            //
            this.lblGhiChuDiem.AutoSize = true;
            this.lblGhiChuDiem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblGhiChuDiem.Location = new System.Drawing.Point(14, 350);
            this.lblGhiChuDiem.Name = "lblGhiChuDiem";
            this.lblGhiChuDiem.Size = new System.Drawing.Size(254, 13);
            this.lblGhiChuDiem.TabIndex = 7;
            this.lblGhiChuDiem.Text = "Điểm & hạng tự cập nhật khi thanh toán.";
            //
            // txtDiaChi
            //
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(16, 312);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(308, 25);
            this.txtDiaChi.TabIndex = 6;
            //
            // lblDiaChi
            //
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDiaChi.Location = new System.Drawing.Point(14, 292);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(49, 17);
            this.lblDiaChi.TabIndex = 5;
            this.lblDiaChi.Text = "Địa chỉ";
            //
            // txtSDT
            //
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(16, 252);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(308, 25);
            this.txtSDT.TabIndex = 4;
            //
            // lblSDT
            //
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSDT.Location = new System.Drawing.Point(14, 232);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(83, 17);
            this.lblSDT.TabIndex = 3;
            this.lblSDT.Text = "Số điện thoại";
            //
            // txtTen
            //
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTen.Location = new System.Drawing.Point(16, 192);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(308, 25);
            this.txtTen.TabIndex = 2;
            //
            // lblTen
            //
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTen.Location = new System.Drawing.Point(14, 172);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(102, 17);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Tên khách hàng";
            //
            // panelThe  (Thẻ thành viên)
            //
            this.panelThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.panelThe.Controls.Add(this.lblTheGiam);
            this.panelThe.Controls.Add(this.lblTheDiem);
            this.panelThe.Controls.Add(this.lblTheHang);
            this.panelThe.Controls.Add(this.lblTheTen);
            this.panelThe.Location = new System.Drawing.Point(16, 16);
            this.panelThe.Name = "panelThe";
            this.panelThe.Size = new System.Drawing.Size(308, 120);
            this.panelThe.TabIndex = 0;
            //
            // lblTheGiam
            //
            this.lblTheGiam.AutoSize = true;
            this.lblTheGiam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheGiam.ForeColor = System.Drawing.Color.White;
            this.lblTheGiam.Location = new System.Drawing.Point(16, 92);
            this.lblTheGiam.Name = "lblTheGiam";
            this.lblTheGiam.Size = new System.Drawing.Size(57, 19);
            this.lblTheGiam.TabIndex = 3;
            this.lblTheGiam.Text = "Giảm: 0%";
            //
            // lblTheDiem
            //
            this.lblTheDiem.AutoSize = true;
            this.lblTheDiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTheDiem.ForeColor = System.Drawing.Color.White;
            this.lblTheDiem.Location = new System.Drawing.Point(16, 68);
            this.lblTheDiem.Name = "lblTheDiem";
            this.lblTheDiem.Size = new System.Drawing.Size(54, 19);
            this.lblTheDiem.TabIndex = 2;
            this.lblTheDiem.Text = "Điểm: 0";
            //
            // lblTheHang
            //
            this.lblTheHang.AutoSize = true;
            this.lblTheHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTheHang.ForeColor = System.Drawing.Color.White;
            this.lblTheHang.Location = new System.Drawing.Point(16, 44);
            this.lblTheHang.Name = "lblTheHang";
            this.lblTheHang.Size = new System.Drawing.Size(95, 19);
            this.lblTheHang.TabIndex = 1;
            this.lblTheHang.Text = "Hạng: Thường";
            //
            // lblTheTen
            //
            this.lblTheTen.AutoSize = true;
            this.lblTheTen.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTheTen.ForeColor = System.Drawing.Color.White;
            this.lblTheTen.Location = new System.Drawing.Point(14, 12);
            this.lblTheTen.Name = "lblTheTen";
            this.lblTheTen.Size = new System.Drawing.Size(94, 25);
            this.lblTheTen.TabIndex = 0;
            this.lblTheTen.Text = "(Chưa chọn)";
            //
            // panelLeft
            //
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panelLeft.Controls.Add(this.dgvKhachHang);
            this.panelLeft.Controls.Add(this.panelTimKiem);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 56);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(12);
            this.panelLeft.Size = new System.Drawing.Size(640, 544);
            this.panelLeft.TabIndex = 2;
            //
            // dgvKhachHang
            //
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AllowUserToResizeRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhachHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhachHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(244)))));
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvKhachHang.ColumnHeadersHeight = 36;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKhachHang.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvKhachHang.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvKhachHang.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.dgvKhachHang.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.EnableHeadersVisualStyles = false;
            this.dgvKhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(234)))));
            this.dgvKhachHang.Location = new System.Drawing.Point(12, 56);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.RowTemplate.Height = 30;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(616, 476);
            this.dgvKhachHang.TabIndex = 1;
            //
            // panelTimKiem
            //
            this.panelTimKiem.Controls.Add(this.btnTimKH);
            this.panelTimKiem.Controls.Add(this.txtTimKH);
            this.panelTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimKiem.Location = new System.Drawing.Point(12, 12);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(616, 44);
            this.panelTimKiem.TabIndex = 0;
            //
            // btnTimKH
            //
            this.btnTimKH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKH.FlatAppearance.BorderSize = 0;
            this.btnTimKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKH.ForeColor = System.Drawing.Color.White;
            this.btnTimKH.Location = new System.Drawing.Point(518, 6);
            this.btnTimKH.Name = "btnTimKH";
            this.btnTimKH.Size = new System.Drawing.Size(90, 30);
            this.btnTimKH.TabIndex = 1;
            this.btnTimKH.Text = "Tìm";
            this.btnTimKH.UseVisualStyleBackColor = false;
            //
            // txtTimKH
            //
            this.txtTimKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKH.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKH.Location = new System.Drawing.Point(0, 7);
            this.txtTimKH.Name = "txtTimKH";
            this.txtTimKH.Size = new System.Drawing.Size(510, 27);
            this.txtTimKH.TabIndex = 0;
            //
            // CustomerManagement
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Khách hàng";
            this.Load += new System.EventHandler(this.CustomerManagement_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelThe.ResumeLayout(false);
            this.panelThe.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelThe;
        private System.Windows.Forms.Label lblTheTen;
        private System.Windows.Forms.Label lblTheHang;
        private System.Windows.Forms.Label lblTheDiem;
        private System.Windows.Forms.Label lblTheGiam;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblGhiChuDiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKhoaMo;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.TextBox txtTimKH;
        private System.Windows.Forms.Button btnTimKH;
        private System.Windows.Forms.DataGridView dgvKhachHang;
    }
}
