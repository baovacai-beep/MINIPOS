using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    /// <summary>
    /// Dialog nhập tiền khách đưa + chọn phương thức thanh toán + áp mã khuyến mãi.
    /// Kết quả: DialogResult.OK → đọc TienKhachDua, TienThoi, PhuongThuc,
    ///          VoucherApDung, VoucherSoTienGiam, FinalThanhTien.
    /// </summary>
    public class ThanhToanDialog : Form
    {
        // ── Outputs ───────────────────────────────────────────────────
        public decimal      TienKhachDua      { get; private set; }
        public decimal      TienThoi          { get; private set; }
        public string       PhuongThuc        { get; private set; }
        /// <summary>Voucher đã được áp dụng (null nếu không dùng).</summary>
        public KhuyenMaiDTO VoucherApDung     { get; private set; }
        /// <summary>Số tiền giảm từ voucher.</summary>
        public decimal      VoucherSoTienGiam { get; private set; }
        /// <summary>Thành tiền cuối cùng sau tất cả giảm giá (hạng KH + voucher).</summary>
        public decimal      FinalThanhTien    { get; private set; }

        // ── Inputs ────────────────────────────────────────────────────
        private readonly decimal               _tongTien;
        private readonly decimal               _tyLeGiam;
        private readonly decimal               _soTienGiam;
        private readonly decimal               _thanhTien;     // sau giảm hạng KH
        private readonly KhachHangDTO          _khachHang;
        private readonly List<ChiTietHoaDonDTO> _gioHang;

        // ── Trạng thái nội bộ ─────────────────────────────────────────
        private decimal _currentThanhTien;   // sau cả hạng KH lẫn voucher

        // ── BUS ───────────────────────────────────────────────────────
        private readonly KhuyenMaiBUS _kmBUS = new KhuyenMaiBUS();

        // ── Controls ──────────────────────────────────────────────────
        private Label    lblInfo;
        private Label    lblGiamKH;
        private Label    lblThanhToan;
        private Label    lblKH;
        private TextBox  txtVoucherCode;
        private Button   btnApVoucher;
        private Label    lblVoucherResult;
        private Label    lblGiamVoucher;     // dòng hiển thị mức giảm voucher
        private Label    lblThanhToanSau;    // dòng thành tiền sau voucher
        private Label    lblPhuong;
        private ComboBox cboPhuongThuc;
        private Label    lblNhapTien;
        private TextBox  txtTienKhachDua;
        private Label    lblTienThoi;
        private Button   btnOK;
        private Button   btnHuy;

        // ═════════════════════════════════════════════════════════════
        //  CONSTRUCTORS
        // ═════════════════════════════════════════════════════════════

        /// <summary>
        /// Constructor tương thích ngược (không có giỏ hàng).
        /// Voucher kiểu "ToanBoHoaDon" hoạt động đầy đủ;
        /// kiểu "NhomSanPham" / "SanPham" sẽ không qua được bước kiểm tra giỏ hàng.
        /// </summary>
        public ThanhToanDialog(decimal tongTien, decimal tyLeGiam, decimal soTienGiam,
                               decimal thanhTien, KhachHangDTO khachHang)
            : this(tongTien, tyLeGiam, soTienGiam, thanhTien, khachHang, null) { }

        /// <summary>
        /// Constructor đầy đủ (có giỏ hàng → validate voucher theo nhóm / sản phẩm chính xác).
        /// </summary>
        public ThanhToanDialog(decimal tongTien, decimal tyLeGiam, decimal soTienGiam,
                               decimal thanhTien, KhachHangDTO khachHang,
                               List<ChiTietHoaDonDTO> gioHang)
        {
            _tongTien         = tongTien;
            _tyLeGiam         = tyLeGiam;
            _soTienGiam       = soTienGiam;
            _thanhTien        = thanhTien;
            _khachHang        = khachHang;
            _gioHang          = gioHang ?? new List<ChiTietHoaDonDTO>();
            _currentThanhTien = thanhTien;
            FinalThanhTien    = thanhTien;
            InitUI();
        }

        // ═════════════════════════════════════════════════════════════
        //  KHỞI TẠO UI
        // ═════════════════════════════════════════════════════════════
        private void InitUI()
        {
            this.Text            = "Thanh Toán";
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Font            = new Font("Segoe UI", 10F);

            int y = 12;
            const int LEFT = 14;
            const int W    = 340;

            // ── Tổng tiền hàng ──────────────────────────────────────
            lblInfo = new Label
            {
                Text     = $"Tổng tiền hàng :  {_tongTien:N0} đ",
                Location = new Point(LEFT, y),
                AutoSize = true,
                Font     = new Font("Segoe UI", 10F)
            };
            y += 26;

            // ── Giảm giá hạng KH ────────────────────────────────────
            if (_tyLeGiam > 0)
            {
                lblGiamKH = new Label
                {
                    Text      = $"Giảm hạng KH ({_tyLeGiam:0}%) :  -{_soTienGiam:N0} đ",
                    Location  = new Point(LEFT, y),
                    AutoSize  = true,
                    ForeColor = Color.ForestGreen
                };
                this.Controls.Add(lblGiamKH);
                y += 26;
            }

            // ── Cần thanh toán (trước voucher) ──────────────────────
            lblThanhToan = new Label
            {
                Text      = $"Cần thanh toán :  {_thanhTien:N0} đ",
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            y += 30;

            // ── Thông tin khách hàng ─────────────────────────────────
            string khInfo = _khachHang != null
                ? $"KH: {_khachHang.TenKhachHang}  [{_khachHang.TenHang}]  Điểm: {_khachHang.DiemTichLuy}"
                : "Khách: Vãng lai";
            lblKH = new Label
            {
                Text      = khInfo,
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                ForeColor = _khachHang != null ? Color.DarkBlue : Color.Gray
            };
            y += 32;

            // ────────────────────────────────────────────────────────
            //  VOUCHER / MÃ KHUYẾN MÃI
            // ────────────────────────────────────────────────────────
            var sep = new Label
            {
                Text      = "─── Mã khuyến mãi ──────────────────────",
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                ForeColor = Color.Gray,
                Font      = new Font("Segoe UI", 8.5F)
            };
            y += 20;

            txtVoucherCode = new TextBox
            {
                Location        = new Point(LEFT, y),
                Size            = new Size(200, 26),
                CharacterCasing = CharacterCasing.Upper,
                Font            = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            btnApVoucher = new Button
            {
                Text      = "Áp dụng",
                Location  = new Point(LEFT + 208, y),
                Size      = new Size(90, 26),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Font      = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnApVoucher.Click += BtnApVoucher_Click;
            y += 32;

            lblVoucherResult = new Label
            {
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Text      = ""
            };
            y += 22;

            // Dòng hiển thị mức giảm voucher (ẩn ban đầu)
            lblGiamVoucher = new Label
            {
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 10F),
                ForeColor = Color.DarkGreen,
                Text      = "",
                Visible   = false
            };
            y += 24;

            // Thành tiền sau voucher (ẩn ban đầu)
            lblThanhToanSau = new Label
            {
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Text      = "",
                Visible   = false
            };
            y += 30;

            // ────────────────────────────────────────────────────────
            //  PHƯƠNG THỨC THANH TOÁN
            // ────────────────────────────────────────────────────────
            lblPhuong = new Label { Text = "Hình thức thanh toán:", Location = new Point(LEFT, y), AutoSize = true };
            y += 24;
            cboPhuongThuc = new ComboBox
            {
                Location      = new Point(LEFT, y),
                Size          = new Size(200, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboPhuongThuc.Items.AddRange(new[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "QR Code" });
            cboPhuongThuc.SelectedIndex = 0;
            y += 34;

            // ── Tiền khách đưa ───────────────────────────────────────
            lblNhapTien = new Label { Text = "Tiền khách đưa (đ):", Location = new Point(LEFT, y), AutoSize = true };
            y += 24;
            txtTienKhachDua = new TextBox
            {
                Location = new Point(LEFT, y),
                Size     = new Size(200, 26),
                Text     = _currentThanhTien.ToString("0")
            };
            txtTienKhachDua.TextChanged += OnTienKhachDuaChanged;
            y += 32;

            // ── Tiền thối ────────────────────────────────────────────
            lblTienThoi = new Label
            {
                Text      = "Tiền thối: 0 đ",
                Location  = new Point(LEFT, y),
                AutoSize  = true,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            y += 30;

            // ── Nút OK / Hủy ─────────────────────────────────────────
            btnOK = new Button
            {
                Text      = "✔  Xác nhận",
                Location  = new Point(LEFT, y),
                Size      = new Size(130, 34),
                BackColor = Color.LimeGreen,
                FlatStyle = FlatStyle.Popup,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnHuy = new Button
            {
                Text      = "✖  Hủy",
                Location  = new Point(LEFT + 138, y),
                Size      = new Size(100, 34),
                BackColor = Color.IndianRed,
                FlatStyle = FlatStyle.Popup,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White
            };

            btnOK.Click  += BtnOK_Click;
            btnHuy.Click += (s, ev) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            cboPhuongThuc.SelectedIndexChanged += (s, ev) =>
            {
                bool laTienMat = (cboPhuongThuc.SelectedItem?.ToString() ?? "") == "Tiền mặt";
                txtTienKhachDua.Enabled = laTienMat;
                if (!laTienMat)
                {
                    txtTienKhachDua.Text = _currentThanhTien.ToString("0");
                    lblTienThoi.Text     = "Tiền thối: 0 đ";
                }
            };

            // ── Thêm tất cả controls ─────────────────────────────────
            this.Controls.AddRange(new Control[]
            {
                lblInfo, lblThanhToan, lblKH,
                sep, txtVoucherCode, btnApVoucher,
                lblVoucherResult, lblGiamVoucher, lblThanhToanSau,
                lblPhuong, cboPhuongThuc,
                lblNhapTien, txtTienKhachDua,
                lblTienThoi,
                btnOK, btnHuy
            });

            this.AcceptButton = btnOK;
            this.ClientSize   = new Size(W + 28, y + 50);
            OnTienKhachDuaChanged(null, null);
        }

        // ═════════════════════════════════════════════════════════════
        //  ÁP DỤNG MÃ KHUYẾN MÃI
        // ═════════════════════════════════════════════════════════════
        private void BtnApVoucher_Click(object sender, EventArgs e)
        {
            string code = txtVoucherCode.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                HienThiKetQuaVoucher("Vui lòng nhập mã khuyến mãi.", false);
                return;
            }

            // Validate voucher qua BUS (dùng tongTien gốc trước hạng KH để check đơn tối thiểu)
            string msg;
            KhuyenMaiDTO km = _kmBUS.ValidateVoucher(code, _tongTien, _gioHang, out msg);

            if (km == null)
            {
                // Voucher không hợp lệ – hiện thông báo lỗi, giữ nguyên giá
                HienThiKetQuaVoucher(msg, false);
                XoaVoucher();
                return;
            }

            // Tính tiền giảm từ voucher (áp lên phần sau giảm hạng KH)
            decimal soTienGiamKM = _kmBUS.TinhTienGiam(km, _thanhTien, _gioHang);

            // Lưu kết quả
            VoucherApDung     = km;
            VoucherSoTienGiam = soTienGiamKM;
            _currentThanhTien = Math.Max(0, _thanhTien - soTienGiamKM);
            FinalThanhTien    = _currentThanhTien;

            // Cập nhật UI
            HienThiKetQuaVoucher($"✔ {msg}", true);
            lblGiamVoucher.Text    = $"Giảm KM ({km.TenKhuyenMai}) :  -{soTienGiamKM:N0} đ";
            lblGiamVoucher.Visible = true;
            lblThanhToanSau.Text   = $"Thanh toán sau KM :  {_currentThanhTien:N0} đ";
            lblThanhToanSau.Visible = true;

            // Cập nhật ô tiền khách đưa theo giá mới
            txtTienKhachDua.Text = _currentThanhTien.ToString("0");
            OnTienKhachDuaChanged(null, null);

            // Khoá ô code để tránh thay đổi sau khi đã áp
            txtVoucherCode.ReadOnly = true;
            btnApVoucher.Text       = "Xóa mã";
            btnApVoucher.BackColor  = Color.DarkOrange;
            btnApVoucher.Click     -= BtnApVoucher_Click;
            btnApVoucher.Click     += BtnXoaVoucher_Click;
        }

        private void BtnXoaVoucher_Click(object sender, EventArgs e)
        {
            XoaVoucher();
        }

        private void XoaVoucher()
        {
            VoucherApDung          = null;
            VoucherSoTienGiam      = 0;
            _currentThanhTien      = _thanhTien;
            FinalThanhTien         = _thanhTien;

            txtVoucherCode.ReadOnly = false;
            txtVoucherCode.Text     = "";

            lblGiamVoucher.Visible  = false;
            lblGiamVoucher.Text     = "";
            lblThanhToanSau.Visible = false;
            lblThanhToanSau.Text    = "";

            btnApVoucher.Text       = "Áp dụng";
            btnApVoucher.BackColor  = Color.SteelBlue;
            btnApVoucher.Click     -= BtnXoaVoucher_Click;
            btnApVoucher.Click     += BtnApVoucher_Click;

            lblVoucherResult.Text      = "";
            lblVoucherResult.ForeColor = Color.Gray;

            txtTienKhachDua.Text = _currentThanhTien.ToString("0");
            OnTienKhachDuaChanged(null, null);
        }

        private void HienThiKetQuaVoucher(string text, bool thanh_cong)
        {
            lblVoucherResult.Text      = text;
            lblVoucherResult.ForeColor = thanh_cong ? Color.ForestGreen : Color.Crimson;
        }

        // ═════════════════════════════════════════════════════════════
        //  TÍNH TIỀN THỐI
        // ═════════════════════════════════════════════════════════════
        private void OnTienKhachDuaChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTienKhachDua.Text, out decimal kd))
            {
                decimal thoi = kd - _currentThanhTien;
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

        // ═════════════════════════════════════════════════════════════
        //  XÁC NHẬN THANH TOÁN
        // ═════════════════════════════════════════════════════════════
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
            if (laTienMat && kd < _currentThanhTien)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ để thanh toán!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienKhachDua.Focus();
                return;
            }

            TienKhachDua = kd;
            TienThoi     = laTienMat ? kd - _currentThanhTien : 0;
            PhuongThuc   = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
