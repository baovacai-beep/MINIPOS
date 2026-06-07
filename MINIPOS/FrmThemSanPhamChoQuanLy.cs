using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class FrmThemSanPhamChoQuanLy : Form
    {
        private FrmKhoChoQuanLy parentForm;

        public FrmThemSanPhamChoQuanLy(FrmKhoChoQuanLy form)
        {
            InitializeComponent();

            parentForm = form;

            // Đăng ký các sự kiện của form
            this.Load += FrmThemSanPhamChoQuanLy_Load;
        }

        private void FrmThemSanPhamChoQuanLy_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho trạng thái khi thêm mới (Ví dụ: 1 nghĩa là đang hoạt động)
            txtTrangThai.Text = "1";
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            FrmBanHangChoQuanLy frm = new FrmBanHangChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            FrmKhoChoQuanLy frm = new FrmKhoChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();

            frm.Show();
            this.Hide();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVienChoQuanLy frm = new FrmNhanVienChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            FrmKhuyenMaiChoQuanLy frm = new FrmKhuyenMaiChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();

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

        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO
                {
                    TenSanPham = txtTenSP.Text.Trim(),
                    MaLoai = int.Parse(txtMaLoai.Text),
                    DonGiaBan = decimal.Parse(txtDonGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuongTon.Text),
                    SoLuongTonToiThieu = int.Parse(txtSoLuongTonToiThieu.Text),
                    Barcode = txtBarcode.Text.Trim(),
                    DonViTinh = txtDonViTinh.Text.Trim(),
                    MoTa = rtxtMoTa.Text.Trim(),
                    TrangThai = txtTrangThai.Text.Trim() == "1"
                };

                // Ảnh có thể có hoặc không
                if (!string.IsNullOrWhiteSpace(txtHinhAnh.Text))
                {
                    sp.HinhAnh = txtHinhAnh.Text.Trim();
                }
                else
                {
                    sp.HinhAnh = null;
                }

                bool result = sanPhamBUS.InsertProduct(sp);

                if (result)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");

                    parentForm.LoadSanPham();

                    parentForm.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Show();

            this.Close();
        }
    }
}