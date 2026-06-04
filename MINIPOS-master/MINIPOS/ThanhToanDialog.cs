using System;
using System.Drawing;
using System.Windows.Forms;
using MINIPOS_DTO;

namespace MINIPOS
{
    /// <summary>
    /// Dialog nhập tiền khách đưa + chọn phương thức thanh toán.
    /// Kết quả: DialogResult.OK → đọc TienKhachDua, TienThoi, PhuongThuc.
    /// </summary>
    public class ThanhToanDialog : Form
    {
        // ── Outputs ───────────────────────────────────────────────
        public decimal TienKhachDua { get; private set; }
        public decimal TienThoi     { get; private set; }
        public string  PhuongThuc   { get; private set; }

        // ── Inputs ────────────────────────────────────────────────
        private readonly decimal _tongTien;
        private readonly decimal _tyLeGiam;
        private readonly decimal _soTienGiam;
        private readonly decimal _thanhTien;
        private readonly KhachHangDTO _khachHang;

        // ── Controls ──────────────────────────────────────────────
        private Label       lblInfo;
        private Label       lblKH;
        private Label       lblThanhToan;
        private Label       lblNhapTien;
        private TextBox     txtTienKhachDua;
        private Label       lblTienThoi;
        private ComboBox    cboPhuongThuc;
        private Button      btnOK;
        private Button      btnHuy;

        public ThanhToanDialog(decimal tongTien, decimal tyLeGiam, decimal soTienGiam,
                               decimal thanhTien, KhachHangDTO khachHang)
        {
            _tongTien   = tongTien;
            _tyLeGiam   = tyLeGiam;
            _soTienGiam = soTienGiam;
            _thanhTien  = thanhTien;
            _khachHang  = khachHang;
            InitUI();
        }

        private void InitUI()
        {
            this.Text            = "Thanh Toán";
            this.Size            = new Size(380, 320);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Font            = new Font("Segoe UI", 10F);

            int y = 12;

            // ── Thông tin hóa đơn ─────────────────────────────────
            lblInfo = new Label
            {
                Text      = $"Tổng tiền hàng :  {_tongTien:N0} đ",
                Location  = new Point(14, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 10F)
            };
            y += 26;

            if (_tyLeGiam > 0)
            {
                var lblGiam = new Label
                {
                    Text     = $"Giảm giá ({_tyLeGiam:0}%)   :  -{_soTienGiam:N0} đ",
                    Location = new Point(14, y),
                    AutoSize = true,
                    ForeColor = Color.ForestGreen
                };
                this.Controls.Add(lblGiam);
                y += 26;
            }

            lblThanhToan = new Label
            {
                Text      = $"Cần thanh toán :  {_thanhTien:N0} đ",
                Location  = new Point(14, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            y += 30;

            // ── Khách hàng ────────────────────────────────────────
            string khInfo = _khachHang != null
                ? $"KH: {_khachHang.TenKhachHang}  [{_khachHang.TenHang}]  Điểm: {_khachHang.DiemTichLuy}"
                : "Khách: Vãng lai";
            lblKH = new Label
            {
                Text      = khInfo,
                Location  = new Point(14, y),
                AutoSize  = true,
                ForeColor = _khachHang != null ? Color.DarkBlue : Color.Gray
            };
            y += 28;

            // ── Phương thức thanh toán ────────────────────────────
            var lblPhuong = new Label { Text = "Hình thức thanh toán:", Location = new Point(14, y), AutoSize = true };
            y += 24;
            cboPhuongThuc = new ComboBox
            {
                Location      = new Point(14, y),
                Size          = new Size(200, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboPhuongThuc.Items.AddRange(new[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "QR Code" });
            cboPhuongThuc.SelectedIndex = 0;
            y += 34;

            // ── Tiền khách đưa ────────────────────────────────────
            lblNhapTien = new Label { Text = "Tiền khách đưa (đ):", Location = new Point(14, y), AutoSize = true };
            y += 24;
            txtTienKhachDua = new TextBox
            {
                Location = new Point(14, y),
                Size     = new Size(200, 26),
                Text     = _thanhTien.ToString("0")
            };
            txtTienKhachDua.TextChanged += OnTienKhachDuaChanged;
            y += 32;

            // ── Tiền thối ─────────────────────────────────────────
            lblTienThoi = new Label
            {
                Text      = $"Tiền thối: 0 đ",
                Location  = new Point(14, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            y += 30;

            // ── Buttons ───────────────────────────────────────────
            btnOK = new Button
            {
                Text      = "✔  Xác nhận",
                Location  = new Point(14, y),
                Size      = new Size(120, 34),
                BackColor = Color.LimeGreen,
                FlatStyle = FlatStyle.Popup,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnHuy = new Button
            {
                Text      = "✖  Hủy",
                Location  = new Point(146, y),
                Size      = new Size(100, 34),
                BackColor = Color.IndianRed,
                FlatStyle = FlatStyle.Popup,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White
            };

            btnOK.Click  += BtnOK_Click;
            btnHuy.Click += (s, ev) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Khi chọn "Chuyển khoản", "Thẻ", "QR" → không cần tiền mặt
            cboPhuongThuc.SelectedIndexChanged += (s, ev) =>
            {
                bool laTienMat = (cboPhuongThuc.SelectedItem?.ToString() ?? "") == "Tiền mặt";
                txtTienKhachDua.Enabled = laTienMat;
                if (!laTienMat)
                {
                    txtTienKhachDua.Text = _thanhTien.ToString("0");
                    lblTienThoi.Text     = "Tiền thối: 0 đ";
                }
            };

            this.Controls.AddRange(new Control[]
            {
                lblInfo, lblThanhToan, lblKH,
                lblPhuong, cboPhuongThuc,
                lblNhapTien, txtTienKhachDua,
                lblTienThoi,
                btnOK, btnHuy
            });

            this.AcceptButton = btnOK;
            this.ClientSize   = new Size(380, y + 50);
            OnTienKhachDuaChanged(null, null);
        }

        private void OnTienKhachDuaChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text, out decimal kd))
            {
                decimal thoi = kd - _thanhTien;
                lblTienThoi.Text      = thoi >= 0
                    ? $"Tiền thối: {thoi:N0} đ"
                    : "⚠ Tiền đưa chưa đủ!";
                lblTienThoi.ForeColor = thoi >= 0 ? Color.DarkGreen : Color.Red;
            }
            else
            {
                lblTienThoi.Text      = "⚠ Nhập số không hợp lệ";
                lblTienThoi.ForeColor = Color.Red;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTienKhachDua.Text, out decimal kd) || kd < 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienKhachDua.Focus();
                return;
            }

            bool laTienMat = (cboPhuongThuc.SelectedItem?.ToString() ?? "") == "Tiền mặt";
            if (laTienMat && kd < _thanhTien)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ để thanh toán!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienKhachDua.Focus();
                return;
            }

            TienKhachDua = kd;
            TienThoi     = laTienMat ? kd - _thanhTien : 0;
            PhuongThuc   = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
