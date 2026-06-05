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
    public partial class InventoryForManager : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();
        private LoaiSanPhamBUS _loaiBUS = new LoaiSanPhamBUS();

        public InventoryForManager()
        {
            InitializeComponent();

            this.FormClosed += InventoryForManager_FormClosed;
        }

        private void InventoryForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadProducts()
        {
            dgvSanPham.DataSource = sanPhamBUS.GetAllProducts();
        }

        private void InventoryForManager_Load(object sender, EventArgs e)
        {
            LoadProducts();
            EnsureEditColumn();

            NapComboLoai();
            WireLoc();

            // nut Khach hang mo form quan ly khach hang
            btnKhachHang.Click += (s, ev) =>
            {
                using (var frmKH = new CustomerManagement())
                    frmKH.ShowDialog();
            };
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
            LoadProducts();
            EnsureEditColumn();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            MainFormForManager frm = new MainFormForManager();

            frm.Show();

            this.Hide();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddInventoryForManager frm = new AddInventoryForManager();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private SanPhamBUS sanPhamBUS = new SanPhamBUS();

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            MainFormForManager frm = new MainFormForManager();

            frm.Show();
            this.Hide();
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

                        LoadProducts();
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

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            AddInventoryForManager frm = new AddInventoryForManager();

            frm.Show();
            this.Hide();
        }
    }
}