using System;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class Login : Form
    {
        private readonly TaiKhoanBUS _bus = new TaiKhoanBUS();

        // Lưu thông tin tài khoản đăng nhập thành công để form khác có thể dùng
        public static TaiKhoanDTO TaiKhoanDangNhap { get; private set; }

        public Login()
        {
            InitializeComponent();

            // Cho phép nhấn Enter để đăng nhập
            this.AcceptButton = btnLogin;

            // Sự kiện click nút đăng nhập
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

                // Lưu vào biến tĩnh để dùng toàn app
                TaiKhoanDangNhap = tk;

                MessageBox.Show(
                    $"Xin chào, {tk.HoTen}!\nVai trò: {tk.TenVaiTro}",
                    "Đăng nhập thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Mở MainForm và đóng Login
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
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
