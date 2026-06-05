using System;
using System.Drawing;
using System.Windows.Forms;
using MINIPOS_BUS;

namespace MINIPOS
{
    // Hộp thoại đổi mật khẩu cho tài khoản đang đăng nhập
    public class ChangePasswordDialog : Form
    {
        private readonly TaiKhoanBUS _bus = new TaiKhoanBUS();
        private readonly int _maTaiKhoan;

        private TextBox txtCu;
        private TextBox txtMoi;
        private TextBox txtXacNhan;
        private Button  btnLuu;
        private Button  btnHuy;

        public ChangePasswordDialog(int maTaiKhoan)
        {
            _maTaiKhoan = maTaiKhoan;
            InitUI();
        }

        private void InitUI()
        {
            this.Text            = "Đổi mật khẩu";
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Font            = new Font("Segoe UI", 10F);
            this.ClientSize      = new Size(360, 250);

            int y = 20;
            this.Controls.Add(TaoNhan("Mật khẩu hiện tại:", y));
            txtCu = TaoO(y + 22);
            y += 64;

            this.Controls.Add(TaoNhan("Mật khẩu mới:", y));
            txtMoi = TaoO(y + 22);
            y += 64;

            this.Controls.Add(TaoNhan("Nhập lại mật khẩu mới:", y));
            txtXacNhan = TaoO(y + 22);
            y += 70;

            btnLuu = new Button
            {
                Text      = "Lưu",
                Location  = new Point(20, y),
                Size      = new Size(150, 36),
                BackColor = Color.FromArgb(79, 70, 229),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.Click += BtnLuu_Click;

            btnHuy = new Button
            {
                Text      = "Hủy",
                Location  = new Point(186, y),
                Size      = new Size(150, 36),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10F)
            };
            btnHuy.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.Add(btnLuu);
            this.Controls.Add(btnHuy);
            this.AcceptButton = btnLuu;
        }

        private Label TaoNhan(string text, int top)
        {
            return new Label { Text = text, Location = new Point(20, top), AutoSize = true };
        }

        private TextBox TaoO(int top)
        {
            var tb = new TextBox
            {
                Location              = new Point(20, top),
                Size                  = new Size(316, 26),
                UseSystemPasswordChar = true,
                Font                  = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(tb);
            return tb;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (txtMoi.Text != txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhan.Focus();
                return;
            }

            try
            {
                _bus.DoiMatKhau(_maTaiKhoan, txtCu.Text, txtMoi.Text);
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
