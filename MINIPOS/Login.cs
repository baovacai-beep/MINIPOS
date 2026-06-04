using System;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class Login : Form
    {
        private readonly TaiKhoanBUS _bus = new TaiKhoanBUS();

        // Lưu thông tin tài khoản đang đăng nhập để các form khác truy cập
        public static TaiKhoanDTO TaiKhoanDangNhap { get; private set; }

        public Login()
        {
            InitializeComponent();

            // Cho phép nhấn Enter để đăng nhập
            this.AcceptButton = btnLogin;

            // Gán sự kiện click
            btnLogin.Click += btnLogin_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Vô hiệu nút tránh nhấn nhiều lần
                btnLogin.Enabled = false;
                btnLogin.Text    = "Đang xử lý...";

                TaiKhoanDTO tk = _bus.DangNhap(txtUsername.Text, txtPassword.Text);
                
                //Ghi nhận thời gian login hiện tại vào đối tượng DTO trong RAM
                tk.LanDangNhapCuoi = DateTime.Now;

                // Lưu vào biến tĩnh để dùng toàn app
                TaiKhoanDangNhap = tk;

                // ── Phân quyền: mở form đúng theo vai trò ──────────────────
                Form mainForm;

                if (tk.TenVaiTro == "QuanLy")
                {
                    mainForm = new MainFormForManager();
                }
                else if (tk.TenVaiTro == "NhanVien")
                {
                    mainForm = new MainFormForStaff();
                }
                else
                {
                    // Vai trò không xác định → từ chối truy cập
                    throw new Exception("Vai trò không được hỗ trợ. Vui lòng liên hệ quản trị viên.");
                }

                mainForm.Show();
                this.Hide();

                // Khi đóng MainForm thì đóng hẳn ứng dụng (bao gồm Login đang ẩn)
                mainForm.FormClosed += (s, args) => this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtPassword.Focus();
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text    = "Đăng nhập";
            }
        }

    }
}
