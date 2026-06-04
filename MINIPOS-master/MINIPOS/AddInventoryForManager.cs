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
            try
            {
                using (SqlConnection conn = SQLConnection.GetConnection())
                {
                    conn.Open();

                    // ĐÃ SỬA: Thay MaLoaiSanPham thành LoaiSanPham cho khớp với Database
                    string sql = @"SELECT MaLoai, TenLoai FROM LoaiSanPham WHERE TrangThai = 1";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboCategory.DataSource = dt;
                    cboCategory.DisplayMember = "TenLoai";
                    cboCategory.ValueMember = "MaLoai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Kiểm tra ràng buộc dữ liệu đầu vào cơ bản trước khi lưu
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = SQLConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO SanPham
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

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenSP", txtProductName.Text.Trim());

                        // TỐI ƯU: Nếu Barcode trống thì lưu NULL vào DB để tránh lỗi UNIQUE khi có nhiều sản phẩm trống mã vạch
                        if (string.IsNullOrWhiteSpace(txtBarcode.Text))
                            cmd.Parameters.AddWithValue("@Barcode", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());

                        cmd.Parameters.AddWithValue("@MaLoai", cboCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@GiaBan", nudSellPrice.Value);
                        cmd.Parameters.AddWithValue("@SoLuong", nudQuantity.Value);
                        cmd.Parameters.AddWithValue("@DonVi", string.IsNullOrWhiteSpace(txtUnit.Text) ? "cái" : txtUnit.Text.Trim());
                        cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(rtxtDescription.Text) ? DBNull.Value : (object)rtxtDescription.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InventoryForManager frm = new InventoryForManager();
            frm.Show();
            this.Hide();
        }
    }
}