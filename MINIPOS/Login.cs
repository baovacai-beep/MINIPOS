using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class Login : Form
    {
        private readonly TaiKhoanBUS _bus = new TaiKhoanBUS();

        // tài khoản đang đăng nhập, các form khác lấy ra dùng
        public static TaiKhoanDTO TaiKhoanDangNhap { get; private set; }

        // màu dùng chung cho giao diện
        private static readonly Color Accent     = Color.FromArgb(79, 70, 229);
        private static readonly Color AccentDark = Color.FromArgb(67, 56, 202);
        private static readonly Color GradFrom   = Color.FromArgb(79, 70, 229);
        private static readonly Color GradTo     = Color.FromArgb(124, 58, 237);
        private static readonly Color InputBg    = Color.FromArgb(248, 250, 252);
        private static readonly Color BorderCol  = Color.FromArgb(203, 213, 225);
        private static readonly Color Muted      = Color.FromArgb(100, 116, 139);

        private bool _btnHover = false;
        private bool _showPass = false;

        public Login()
        {
            InitializeComponent();

            this.AcceptButton = btnLogin;   // nhấn Enter là đăng nhập
            btnLogin.Click += btnLogin_Click;
        }

        // bật đổ bóng cho cửa sổ không viền
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // chữ gợi ý mờ trong ô (không tính vào Text nên không ảnh hưởng đăng nhập)
            SetCueBanner(txtUsername, "Nhập tên đăng nhập");
            SetCueBanner(txtPassword, "Nhập mật khẩu");

            // điền sẵn tài khoản cho đỡ phải gõ lúc test
            txtUsername.Text = "quanly";
            txtPassword.Text = "123456";

            txtUsername.Focus();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text    = "Đang xử lý...";
                btnLogin.Invalidate();

                TaiKhoanDTO tk = _bus.DangNhap(txtUsername.Text, txtPassword.Text);
                TaiKhoanDangNhap = tk;

                // mở form theo vai trò
                Form mainForm;
                if (tk.TenVaiTro == "QuanLy")
                    mainForm = new MainFormForManager();
                else if (tk.TenVaiTro == "NhanVien")
                    mainForm = new MainFormForStaff();
                else
                    throw new Exception("Vai trò không được hỗ trợ. Vui lòng liên hệ quản trị viên.");

                mainForm.Show();
                this.Hide();
                mainForm.FormClosed += MainForm_FormClosed;
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
                btnLogin.Invalidate();
            }
        }

        // form chính đóng: nếu là đăng xuất thì hiện lại Login, ngược lại thoát app
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool dangXuat = (sender as MainFormForManager)?.DangXuat
                         ?? (sender as MainFormForStaff)?.DangXuat ?? false;

            if (dangXuat)
            {
                TaiKhoanDangNhap = null;
                txtUsername.Clear();
                txtPassword.Clear();
                txtPassword.UseSystemPasswordChar = true;
                _showPass = false;
                btnShowPass.Text = "HIỆN";
                this.Show();
                txtUsername.Focus();
            }
            else
            {
                this.Close();
            }
        }

        // ----- phần vẽ giao diện bằng GDI+ -----

        // panel trái: gradient + logo + chữ
        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Rectangle rect = pnlLeft.ClientRectangle;

            using (var grad = new LinearGradientBrush(rect, GradFrom, GradTo, 135f))
                g.FillRectangle(grad, rect);

            // vòng tròn trang trí mờ
            using (var c1 = new SolidBrush(Color.FromArgb(28, 255, 255, 255)))
            {
                g.FillEllipse(c1, -70, rect.Height - 170, 230, 230);
                g.FillEllipse(c1, rect.Width - 110, -90, 210, 210);
            }
            using (var c2 = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
                g.FillEllipse(c2, rect.Width - 190, rect.Height - 120, 170, 170);

            // bo góc cho pnlBadge
            Rectangle badge = new Rectangle(48, 72, 60, 60);
            using (var bp = RoundedRect(badge, 16))
            using (var bb = new SolidBrush(Color.White))
                g.FillPath(bb, bp);
        }

        // ô nhập bo góc, viền đậm hơn khi đang gõ
        private void PnlInput_Paint(object sender, PaintEventArgs e)
        {
            var pnl  = (Panel)sender;
            var tb   = pnl == pnlUser ? (Control)txtUsername : txtPassword;
            var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            bool focus = tb.Focused;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = RoundedRect(rect, 10))
            using (var fill = new SolidBrush(InputBg))
            using (var pen  = new Pen(focus ? Accent : BorderCol, focus ? 1.8f : 1.3f))
            {
                e.Graphics.FillPath(fill, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void Input_FocusChanged(object sender, EventArgs e)
        {
            pnlUser.Invalidate();
            pnlPass.Invalidate();
        }

        // nút đăng nhập bo góc, đổi màu khi rê chuột / bị khóa
        private void BtnLogin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            var rect = new Rectangle(0, 0, btnLogin.Width - 1, btnLogin.Height - 1);
            Color c = !btnLogin.Enabled ? Color.FromArgb(165, 180, 252)
                                        : (_btnHover ? AccentDark : Accent);

            using (var path = RoundedRect(rect, 12))
            using (var b = new SolidBrush(c))
                g.FillPath(b, path);

            TextRenderer.DrawText(g, btnLogin.Text, btnLogin.Font, rect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e) { _btnHover = true;  btnLogin.Invalidate(); }
        private void BtnLogin_MouseLeave(object sender, EventArgs e) { _btnHover = false; btnLogin.Invalidate(); }

        private void BtnShowPass_Click(object sender, EventArgs e)
        {
            _showPass = !_showPass;
            txtPassword.UseSystemPasswordChar = !_showPass;
            btnShowPass.Text = _showPass ? "ẨN" : "HIỆN";
            txtPassword.Focus();
        }

        private void Close_Click(object sender, EventArgs e) => this.Close();
        private void Min_Click(object sender, EventArgs e)   => this.WindowState = FormWindowState.Minimized;

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(239, 68, 68);
            lblClose.ForeColor = Color.White;
        }
        private void Min_MouseEnter(object sender, EventArgs e)
        {
            lblMin.BackColor = Color.FromArgb(226, 232, 240);
        }
        private void HeaderBtn_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = Muted;
        }

        // ----- mấy hàm tiện ích -----

        // vẽ hình chữ nhật bo góc
        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            if (radius <= 0) { path.AddRectangle(r); return path; }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION       = 0x2;
        private const int EM_SETCUEBANNER  = 0x1501;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        // cho phép kéo cửa sổ không viền
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private static void SetCueBanner(TextBox tb, string text)
        {
            SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }
    }
}
