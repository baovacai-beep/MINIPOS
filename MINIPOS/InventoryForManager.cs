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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}