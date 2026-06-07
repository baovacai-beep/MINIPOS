using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MINIPOS_DAO;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class FrmKhoChoNhanVien : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private LoaiSanPhamBUS _loaiBUS = new LoaiSanPhamBUS();

        public FrmKhoChoNhanVien()
        {
            InitializeComponent();

            this.FormClosed += FrmKhoChoNhanVien_FormClosed;
        }

        private void FrmKhoChoNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            FrmBanHangChoQuanLy frm = new FrmBanHangChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();

            frm.Show();
            this.Hide();
        }

        private void btnXemHDNhap_Click(object sender, EventArgs e)
        {
            FrmHoaDonNhapChoNhanVien frm = new FrmHoaDonNhapChoNhanVien();

            frm.Show();
            this.Hide();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            // mo menu nho: cai dat / doi mat khau / dang xuat
            var menu = new ContextMenuStrip();
            menu.Items.Add("Cài đặt", null, (s, ev) => MoCaiDat());
            menu.Items.Add("Đổi mật khẩu", null, (s, ev) => MoDoiMatKhau());
            menu.Items.Add("Đăng xuất", null, (s, ev) => DangXuatTaiKhoan());
            menu.Show(btnCaiDat, new Point(0, btnCaiDat.Height));
        }

        private void MoCaiDat()
        {
            var frm = new FrmCaiDatChoQuanLy();
            frm.Show();
            this.Hide();
        }

        private void MoDoiMatKhau()
        {
            int ma = FrmLogin.TaiKhoanDangNhap?.MaTaiKhoan ?? 0;
            if (ma == 0) return;
            using (var f = new FrmThayDoiMatKhau(ma))
                f.ShowDialog();
        }

        public bool DangXuat = false;

        private void DangXuatTaiKhoan()
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangXuat = true;

                FrmLogin frm = new FrmLogin();

                frm.Show();
                this.Hide();
            }
        }

        private void LoadSanPham(string where = "")
        {
            string sql = @"
                SELECT MaSanPham AS [Mã SP],
                       TenSanPham AS [Tên SP],
                       TenLoai AS [Loại SP],
                       DonGiaBan AS [Đơn giá],
                       DonViTinh AS [Đơn vị],
                       SoLuongTon AS [Tồn kho]
                FROM v_SanPham
                WHERE TrangThai = 1 "
                + (string.IsNullOrEmpty(where) ? "" : "AND " + where);
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(sql);
        }

        private void InventoryForStaff_Load(object sender, EventArgs e)
        {
            LoadSanPham();

            NapComboLoai();
            WireLoc();

            // nut Khach hang mo form quan ly khach hang
            btnKhachHang.Click += (s, ev) =>
            {
                using (var frmKH = new FrmKhachHang())
                    frmKH.ShowDialog();
            };
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SanPhamFilterDTO f = new SanPhamFilterDTO
            {
                TuKhoa = txtTimKiem.Text.Trim()
            };

            dgvSanPham.DataSource = spBUS.TimKiem(f);
        }

        // nap combo loai san pham va combo tinh trang ton kho
        private void NapComboLoai()
        {
            var dt = _loaiBUS.GetAll();
            var row = dt.NewRow();
            row["MaLoai"] = DBNull.Value;
            row["TenLoai"] = "— Tất cả loại —";
            dt.Rows.InsertAt(row, 0);
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DataSource = dt;

            cboTonKho.Items.Clear();
            cboTonKho.Items.AddRange(new object[] { "Tất cả tồn kho", "Còn hàng", "Sắp hết", "Hết hàng" });
            cboTonKho.SelectedIndex = 0;
        }

        private void WireLoc()
        {
            btnLoc.Click += (s, e) => ApDungLoc();
            btnXoaLoc.Click += (s, e) => XoaLoc();
        }

        // ap dung tim kiem nang cao, grid nhan vien dung cot dat ten nhu LoadSanPham
        private void ApDungLoc()
        {
            var f = new SanPhamFilterDTO
            {
                TuKhoa = "",
                MaLoai = (cboLoai.SelectedValue != null && cboLoai.SelectedValue != DBNull.Value) ? Convert.ToInt32(cboLoai.SelectedValue) : (int?)null,
                GiaMin = nudGiaMin.Value > 0 ? nudGiaMin.Value : (decimal?)null,
                GiaMax = nudGiaMax.Value > 0 ? nudGiaMax.Value : (decimal?)null,
                TonKho = (TrangThaiKhoFilter)cboTonKho.SelectedIndex
            };
            dgvSanPham.DataSource = _sanPhamBUS.TimKiemBanHang(f);
        }

        // xoa bo loc, tai lai toan bo san pham
        private void XoaLoc()
        {
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            cboTonKho.SelectedIndex = 0;
            nudGiaMin.Value = 0;
            nudGiaMax.Value = 0;
            LoadSanPham();
        }
    }
}
