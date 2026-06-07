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
    public partial class FrmKhoChoQuanLy : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private LoaiSanPhamBUS _loaiBUS = new LoaiSanPhamBUS();
        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

        public FrmKhoChoQuanLy()
        {
            InitializeComponent();

            this.FormClosed += FrmKhoChoQuanLy_FormClosed;
        }

        private void FrmKhoChoQuanLy_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            FrmThemSanPhamChoQuanLy frm = new FrmThemSanPhamChoQuanLy(this);

            frm.Show();
            this.Hide();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            int maSanPham = Convert.ToInt32(
                dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = sanPhamBUS.DeleteProduct(maSanPham);

                if (success)
                {
                    MessageBox.Show("Xóa thành công.");
                    LoadSanPham();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }
        }

        public void LoadSanPham()
        {
            dgvSanPham.DataSource = sanPhamBUS.GetAllProducts();
        }

        private void FrmKhoChoQuanLy_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            EnsureEditColumn();

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

            EnsureEditColumn();
        }

        // them cot nut "Chinh sua" neu chua co (sau moi lan doi DataSource phai goi lai)
        private void EnsureEditColumn()
        {
            if (!dgvSanPham.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();

                btnEdit.Name = "Edit";
                btnEdit.HeaderText = "Chỉnh sửa";
                btnEdit.Text = "Chỉnh sửa";
                btnEdit.UseColumnTextForButtonValue = true;

                dgvSanPham.Columns.Add(btnEdit);
            }
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

        // ap dung tim kiem nang cao theo cac dieu kien loc
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
            dgvSanPham.DataSource = spBUS.TimKiem(f);
            EnsureEditColumn();
        }

        // xoa bo loc, tai lai toan bo san pham
        private void XoaLoc()
        {
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            cboTonKho.SelectedIndex = 0;
            nudGiaMin.Value = 0;
            nudGiaMax.Value = 0;
            LoadSanPham();
            EnsureEditColumn();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //Edit
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "Edit")
            {
                try
                {
                    DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                    SanPhamDTO sp = new SanPhamDTO();

                    sp.MaSanPham = Convert.ToInt32(row.Cells["MaSanPham"].Value);

                    sp.TenSanPham = row.Cells["TenSanPham"].Value.ToString();

                    sp.MaLoai = Convert.ToInt32(row.Cells["MaLoai"].Value);

                    sp.DonGiaBan = Convert.ToDecimal(row.Cells["DonGiaBan"].Value);

                    sp.SoLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);

                    sp.Barcode = row.Cells["Barcode"].Value?.ToString();

                    sp.DonViTinh = row.Cells["DonViTinh"].Value?.ToString();

                    sp.TrangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);

                    bool result = sanPhamBUS.UpdateSanPham(sp);

                    if (result)
                    {
                        MessageBox.Show("Đã chỉnh sửa thông tin sản phẩm",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadSanPham();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Lỗi: Không thể chỉnh sửa thông tin sản phẩm",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Lỗi: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}