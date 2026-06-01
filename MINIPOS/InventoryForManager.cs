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

namespace MINIPOS
{
    public partial class InventoryForManager : Form
    {
        private SanPhamBUS spBUS = new SanPhamBUS();

        public InventoryForManager()
        {
            InitializeComponent();

            this.FormClosed += InventoryForManager_FormClosed;

            dgvInventory.CellContentClick += dgvInventory_CellContentClick;
        }

        private void InventoryForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadProducts()
        {
            dgvInventory.DataSource = spBUS.GetAllProducts();
        }

        private void InventoryForManager_Load(object sender, EventArgs e)
        {
            LoadProducts();

            if (!dgvInventory.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn btnEdit =
                    new DataGridViewButtonColumn();

                btnEdit.Name = "Edit";
                btnEdit.HeaderText = "Chỉnh sửa";
                btnEdit.Text = "Chỉnh sửa";
                btnEdit.UseColumnTextForButtonValue = true;

                dgvInventory.Columns.Add(btnEdit);
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

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex ==
        dgvInventory.Columns["Edit"].Index
        && e.RowIndex >= 0)
            {
                int maSP = Convert.ToInt32(
                    dgvInventory.Rows[e.RowIndex]
                    .Cells["MaSanPham"].Value);

                EditInventoryForManager frm =
                    new EditInventoryForManager(maSP);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }
    }
}