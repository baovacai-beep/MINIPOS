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

            // Đăng ký các sự kiện của form
            this.Load += AddInventoryForManager_Load;
            this.FormClosed += AddInventoryForManager_FormClosed;
        }

        private void AddInventoryForManager_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho trạng thái khi thêm mới (Ví dụ: 1 nghĩa là đang hoạt động)
            txtTrangThai.Text = "1";
        }

        private void AddInventoryForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA RÀNG BUỘC DỮ LIỆU ĐẦU VÀO (VALIDATION)
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập mã loại sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }

            // Ép kiểu dữ liệu và kiểm tra tính hợp lệ của Đơn giá bán
            if (!decimal.TryParse(txtDonGiaBan.Text.Trim(), out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("Đơn giá bán không hợp lệ (Phải là số và không được nhỏ hơn 0)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }

            // Ép kiểu dữ liệu và kiểm tra tính hợp lệ của Số lượng tồn
            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ (Phải là số nguyên và không được nhỏ hơn 0)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return;
            }

            // Ép kiểu số lượng tồn tối thiểu (nếu có nhập)
            int? soLuongTonToiThieu = null;
            if (!string.IsNullOrWhiteSpace(txtSoLuongTonToiThieu.Text))
            {
                if (int.TryParse(txtSoLuongTonToiThieu.Text.Trim(), out int slToiThieu))
                {
                    soLuongTonToiThieu = slToiThieu;
                }
                else
                {
                    MessageBox.Show("Số lượng tồn tối thiểu phải là ký tự số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongTonToiThieu.Focus();
                    return;
                }
            }

            // Ép kiểu trạng thái sản phẩm
            if (!int.TryParse(txtTrangThai.Text.Trim(), out int trangThai))
            {
                trangThai = 1; // Mặc định hoạt động nếu nhập lỗi
            }


            // 2. THỰC THI CHÈN DỮ LIỆU VÀO CƠ SỞ DỮ LIỆU
            string sql = @"INSERT INTO SanPham
                          (
                              MaSanPham,
                              TenSanPham,
                              MaLoai,
                              DonGiaBan,
                              SoLuongTon,
                              SoLuongTonToiThieu,
                              Barcode,
                              HinhAnh,
                              DonViTinh,
                              MoTa,
                              TrangThai
                          )
                          VALUES
                          (
                              @MaSP,
                              @TenSP,
                              @MaLoai,
                              @GiaBan,
                              @SoLuong,
                              @SoLuongToiThieu,
                              @Barcode,
                              @HinhAnh,
                              @DonVi,
                              @MoTa,
                              @TrangThai
                          )";

            try
            {
                using (SqlConnection conn = SQLConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Khai báo Parameter tường minh tránh lỗi ép cấu trúc dữ liệu ngầm định
                        cmd.Parameters.Add("@MaSP", SqlDbType.VarChar, 50).Value = txtMaSP.Text.Trim();
                        cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = txtTenSP.Text.Trim();
                        cmd.Parameters.Add("@MaLoai", SqlDbType.VarChar, 50).Value = txtMaLoai.Text.Trim();
                        cmd.Parameters.Add("@GiaBan", SqlDbType.Decimal).Value = giaBan;
                        cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuongTon;
                        cmd.Parameters.Add("@SoLuongToiThieu", SqlDbType.Int).Value = (object)soLuongTonToiThieu ?? DBNull.Value;

                        // TỐI ƯU: Xử lý lưu dữ liệu rỗng (Null) cho các trường không bắt buộc nhập để tránh lỗi DB
                        cmd.Parameters.Add("@Barcode", SqlDbType.VarChar, 50).Value =
                            string.IsNullOrWhiteSpace(txtBarcode.Text) ? (object)DBNull.Value : txtBarcode.Text.Trim();

                        cmd.Parameters.Add("@HinhAnh", SqlDbType.NVarChar, 250).Value =
                            string.IsNullOrWhiteSpace(txtHinhAnh.Text) ? (object)DBNull.Value : txtHinhAnh.Text.Trim();

                        cmd.Parameters.Add("@DonVi", SqlDbType.NVarChar, 50).Value =
                            string.IsNullOrWhiteSpace(txtDonViTinh.Text) ? "cái" : txtDonViTinh.Text.Trim();

                        cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar, 500).Value =
                            string.IsNullOrWhiteSpace(rtxtMoTa.Text) ? (object)DBNull.Value : rtxtMoTa.Text.Trim();

                        cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = trangThai;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 2627) // Lỗi trùng khóa chính (Primary Key) hoặc trùng Unique Barcode
            {
                MessageBox.Show("Mã sản phẩm hoặc mã Barcode này đã tồn tại trong hệ thống!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            // Đóng và giải phóng tài nguyên Form hiện tại thay vì dùng .Hide() gây tốn RAM chạy ngầm
            MainFormForManager frm = new MainFormForManager();
            frm.Show();

            this.FormClosed -= AddInventoryForManager_FormClosed;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            InventoryForManager frm = new InventoryForManager();
            frm.Show();

            this.FormClosed -= AddInventoryForManager_FormClosed;
            this.Close();
        }
    }
}