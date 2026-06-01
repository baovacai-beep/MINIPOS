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
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class EditInventoryForManager : Form
    {
        private int maSP;

        private SanPhamBUS spBUS = new SanPhamBUS();

        public EditInventoryForManager(int maSanPham)
        {
            InitializeComponent();

            this.FormClosed += EditInventoryForManager_FormClosed;

            maSP = maSanPham;
        }

        private void EditInventoryForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            MainFormForManager frm = new MainFormForManager();

            frm.Show();

            this.Hide();
        }

        private void EditInventoryForManager_Load(object sender, EventArgs e)
        {
            SanPhamDTO sp = spBUS.GetProductById(maSP);

            if (sp == null)
                return;

            txtProductName.Text = sp.TenSanPham;

            txtBarcode.Text = sp.Barcode;

            cboCategory.SelectedValue = sp.Loai;

            nudSellPrice.Value = sp.DonGiaBan;

            nudQuantity.Value = sp.SoLuongTon;

            txtUnit.Text = sp.DonViTinh;

            rtxtDescription.Text = sp.MoTa;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = new SanPhamDTO();

            sp.MaSanPham = maSP;

            sp.TenSanPham = txtProductName.Text;

            sp.Loai = Convert.ToInt32(cboCategory.SelectedValue);

            sp.DonGiaBan = nudSellPrice.Value;

            sp.SoLuongTon = (int)nudQuantity.Value;

            sp.Barcode = txtBarcode.Text;

            sp.DonViTinh = txtUnit.Text;

            sp.MoTa = rtxtDescription.Text;

            bool result = spBUS.UpdateProduct(sp);

            if (result)
            {
                MessageBox.Show(
                    "Cập nhật sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thất bại!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
