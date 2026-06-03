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
using MINIPOS_DAO;

namespace MINIPOS
{
    public partial class AddInventoryForManager : Form
    {
        public AddInventoryForManager()
        {
            InitializeComponent();

            this.FormClosed += AddInventoryForManager_FormClosed;
        }

        private void AddInventoryForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadMaLoai()
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT MaLoai, TenLoai FROM MaLoaiSanPham WHERE TrangThai = 1";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "TenLoai";
                cboCategory.ValueMember = "MaLoai";
            }
        }

        private void AddInventoryForManager_Load(object sender, EventArgs e)
        {
            LoadMaLoai();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            MainFormForManager frm = new MainFormForManager();

            frm.Show();

            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                string sql =
                @"INSERT INTO SanPham
                (
                    TenSanPham,
                    Barcode,
                    MaLoai,
                    DonGiaBan,
                    SoLuongTon,
                    DonViTinh,
                    MoTa
                )
                VALUES
                (
                    @TenSP,
                    @Barcode,
                    @MaLoai,
                    @GiaBan,
                    @SoLuong,
                    @DonVi,
                    @MoTa
                )";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TenSP", txtProductName.Text);

                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text);

                cmd.Parameters.AddWithValue("@MaLoai", cboCategory.SelectedValue);

                cmd.Parameters.AddWithValue("@GiaBan", nudSellPrice.Value);

                cmd.Parameters.AddWithValue("@SoLuong", nudQuantity.Value);

                cmd.Parameters.AddWithValue("@DonVi", txtUnit.Text);

                cmd.Parameters.AddWithValue("@MoTa", rtxtDescription.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã thêm sản phẩm");

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InventoryForManager frm = new InventoryForManager();

            frm.Show();

            this.Hide();
        }
    }
}
