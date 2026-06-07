using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MINIPOS_BUS;

namespace MINIPOS
{
    public partial class FrmHoaDonNhapChoNhanVien : Form
    {
        private readonly HoaDonNhapBUS _bus = new HoaDonNhapBUS();
        public DataTable DataRestore { get; private set; }

        public FrmHoaDonNhapChoNhanVien()
        {
            InitializeComponent();

            this.FormClosed += FrmHoaDonNhapChoNhanVien_FormClosed;

            LoadMasterData();
        }

        private void FrmHoaDonNhapChoNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            FrmBanHangChoNhanVien frm = new FrmBanHangChoNhanVien();

            frm.Show();
            this.Hide();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            FrmKhoChoNhanVien frm = new FrmKhoChoNhanVien();

            frm.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang(this); // Truyền 'this' vào đây
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
            var frm = new FrmCaiDatChoNhanVien();
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

        private void LoadMasterData()
        {
            dgvMaster.DataSource = _bus.GetDanhSachHDNhap();
        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maHD = Convert.ToInt32(dgvMaster.Rows[e.RowIndex].Cells["MaHDNhap"].Value);
                dgvDetail.DataSource = _bus.GetChiTietHDNhap(maHD);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMaster.CurrentRow == null) return;
            int maHD = Convert.ToInt32(dgvMaster.CurrentRow.Cells["MaHDNhap"].Value);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa vĩnh viễn hóa đơn nháp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_bus.XoaHDNhap(maHD))
                {
                    LoadMasterData();
                    dgvDetail.DataSource = null;
                }
            }
        }

        // 1. SỬA LẠI NÚT SỬ DỤNG HOÁ ĐƠN NHÁP: Giải quyết triệt để lỗi văng ứng dụng
        private void btnSuDung_Click(object sender, EventArgs e)
        {
            if (dgvMaster.CurrentRow == null) return;
            int maHD = Convert.ToInt32(dgvMaster.CurrentRow.Cells["MaHDNhap"].Value);

            // Lấy chi tiết hàng hóa từ database
            DataTable dtRestore = _bus.GetChiTietHDNhap(maHD);

            if (dtRestore != null && dtRestore.Rows.Count > 0)
            {
                // Xóa hóa đơn tạm trong DB để giải phóng
                _bus.XoaHDNhap(maHD);

                // Khởi tạo Form bán hàng mới cho nhân viên
                FrmBanHangChoNhanVien frmBanHang = new FrmBanHangChoNhanVien();
                frmBanHang.Show();

                // Gọi hàm nạp ngược dữ liệu vừa viết ở Bước 1 vào giỏ hàng
                frmBanHang.NapDuLieuHoaDonNhap(dtRestore);

                // Ẩn form hóa đơn nháp hiện tại đi
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu hóa đơn nháp này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. SỬA LẠI NÚT ĐIỀU HƯỚNG SANG PHÂN HỆ BÁN HÀNG (Sửa lỗi mở nhầm Form Quản lý)
 
    }
}
