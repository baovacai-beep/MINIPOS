using MINIPOS_DAO;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MINIPOS
{
    public partial class StaffManagementForManager : Form
    {
        public StaffManagementForManager()
        {
            InitializeComponent();
        }

        private void StaffManagementForManager_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;
           
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            string sql = @"
                SELECT
                    nv.MaNhanVien,
                    nv.HoTen,
                    nv.SoDienThoai,
                    nv.DiaChi,
                    nv.GioiTinh,
                    nv.NgaySinh,
                    nv.NgayBatDauLam,
                    tk.MaTaiKhoan,
                    tk.TenDangNhap,
                    tk.LanDangNhapCuoi,
                    tk.TrangThai
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
                INNER JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                WHERE vt.TenVaiTro = N'NhanVien'
                  AND tk.TrangThai = 1
                ORDER BY nv.MaNhanVien DESC";

            dgvNhanVien.DataSource = SQLConnection.ExecuteQuery(sql);

            lblGioVao.Text = "Gio vao: ";
            lblGioRa.Text = "Gio ra: ";
            lblTongGio.Text = "Thoi gian lam: ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên nhân viên.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.");
                return;
            }
            if (KiemTraTenDangNhapTonTai(txtTenDangNhap.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại (có thể thuộc về một nhân viên đã nghỉ làm). Vui lòng chọn tên khác!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    int maVaiTroNhanVien = LayMaVaiTroNhanVien(conn, tran);
                    int maTaiKhoan = ThemTaiKhoan(conn, tran, maVaiTroNhanVien);
                    ThemNhanVien(conn, tran, maTaiKhoan);

                    tran.Commit();

                    MessageBox.Show("Them nhan vien thanh cong.");
                    ClearForm();
                    LoadNhanVien();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Khong them duoc nhan vien: " + ex.Message);
                }
            }
        }

        private int LayMaVaiTroNhanVien(SqlConnection conn, SqlTransaction tran)
        {
            string sql = "SELECT MaVaiTro FROM VaiTro WHERE TenVaiTro = N'NhanVien'";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                object result = cmd.ExecuteScalar();
                if (result == null)
                    throw new Exception("Chua co vai tro NhanVien trong bang VaiTro.");

                return Convert.ToInt32(result);
            }
        }

        private int ThemTaiKhoan(SqlConnection conn, SqlTransaction tran, int maVaiTro)
        {
            string sql = @"
                INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaVaiTro, TrangThai)
                OUTPUT INSERTED.MaTaiKhoan
                VALUES (@TenDangNhap, @MatKhau, @MaVaiTro, 1)";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                cmd.Parameters.AddWithValue("@MatKhau", MaHoaMD5(txtMatKhau.Text.Trim()));
                cmd.Parameters.AddWithValue("@MaVaiTro", maVaiTro);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void ThemNhanVien(SqlConnection conn, SqlTransaction tran, int maTaiKhoan)
        {
            string sql = @"
                INSERT INTO NhanVien
                    (HoTen, SoDienThoai, DiaChi, GioiTinh, NgaySinh, MaTaiKhoan)
                VALUES
                    (@HoTen, @SoDienThoai, @DiaChi, @GioiTinh, @NgaySinh, @MaTaiKhoan)";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@SoDienThoai", NullIfEmpty(txtSDT.Text));
                cmd.Parameters.AddWithValue("@DiaChi", NullIfEmpty(txtDiaChi.Text));
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);

                if (dtpNgaySinh.Checked)
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value.Date);
                else
                    cmd.Parameters.AddWithValue("@NgaySinh", DBNull.Value);

                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null || !dgvNhanVien.Columns.Contains("MaTaiKhoan"))
                return;

            int maTaiKhoan = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["MaTaiKhoan"].Value);

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            string sql = "UPDATE TaiKhoan SET TrangThai = 0 WHERE MaTaiKhoan = @MaTaiKhoan";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã xóa nhân viên.");
            LoadNhanVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Bước 1: Load lại dữ liệu bảng (lúc này WinForms sẽ tự động chọn dòng 1 và điền vào form)
            LoadNhanVien();

            // Bước 2: Bỏ chọn dòng bị auto-select trên DataGridView
            dgvNhanVien.ClearSelection();

            // Bước 3: Dọn dẹp các TextBox (phải nằm cuối cùng để đè lên kết quả của bước 1)
            ClearForm();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null || dgvNhanVien.Columns.Count == 0)
                return;

            if (!dgvNhanVien.Columns.Contains("HoTen") || !dgvNhanVien.Columns.Contains("TenDangNhap"))
                return;

            DataGridViewRow row = dgvNhanVien.CurrentRow;

            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
            txtMatKhau.Clear();
            txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            object ngaySinh = row.Cells["NgaySinh"].Value;
            dtpNgaySinh.Checked = ngaySinh != DBNull.Value && ngaySinh != null;
            if (dtpNgaySinh.Checked)
                dtpNgaySinh.Value = Convert.ToDateTime(ngaySinh);

            HienThiThoiGianLam(row);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
                return;

            HienThiThoiGianLam(dgvNhanVien.CurrentRow, true);
        }

        private void HienThiThoiGianLam(DataGridViewRow row, bool checkout = false)
        {
            object value = row.Cells["LanDangNhapCuoi"].Value;

            if (value == DBNull.Value || value == null)
            {
                lblGioVao.Text = "Gio vao: Chua dang nhap";
                lblGioRa.Text = "Gio ra: ";
                lblTongGio.Text = "Thoi gian lam: ";
                return;
            }

            DateTime gioVao = Convert.ToDateTime(value);
            DateTime gioRa = DateTime.Now;
            TimeSpan tong = gioRa - gioVao;

            lblGioVao.Text = "Gio vao: " + gioVao.ToString("dd/MM/yyyy HH:mm:ss");
            lblGioRa.Text = checkout
                ? "Gio ra: " + gioRa.ToString("dd/MM/yyyy HH:mm:ss")
                : "Gio ra: Chua check out";
            lblTongGio.Text = $"Thoi gian lam: {(int)tong.TotalHours:D2}:{tong.Minutes:D2}:{tong.Seconds:D2}";
        }

        private void ClearForm()
        {
            txtHoTen.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            // Đặt thành -1 để ComboBox trống hoàn toàn (không tự chọn Nam/Nữ)
            cboGioiTinh.SelectedIndex = -1;

            // Bỏ dấu tick ở ô Ngày sinh và trả ngày về mặc định (hôm nay)
            dtpNgaySinh.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private object NullIfEmpty(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DBNull.Value;

            return value.Trim();
        }

        private string MaHoaMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
        private bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}