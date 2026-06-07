using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class FrmKhuyenMaiChoQuanLy : Form
    {
        // ── BUS layer ────────────────────────────────────────────────
        private readonly KhuyenMaiBUS _bus = new KhuyenMaiBUS();

        // ── Trạng thái đang chọn dòng để sửa ────────────────────────
        private int _maKhuyenMaiDangChon = 0;   // 0 = chưa chọn

        // ── Dữ liệu cho cboDoiTuong ─────────────────────────────────
        private DataTable _dtLoaiSanPham = null;
        private DataTable _dtSanPham     = null;

        public FrmKhuyenMaiChoQuanLy()
        {
            InitializeComponent();

            this.FormClosed += CouponManagementForManager_FormClosed;
        }

        // ═══════════════════════════════════════════════════════════════
        //  LOAD FORM
        // ═══════════════════════════════════════════════════════════════
        private void CouponManagementForManager_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            LoadDoiTuong();
            LoadDanhSachKhuyenMai();
            DatTrangThaiNut(false);   // Chưa chọn dòng nào → chỉ cho Thêm
        }

        private void CouponManagementForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            FrmBanHangChoQuanLy frm = new FrmBanHangChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            FrmKhoChoQuanLy frm = new FrmKhoChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang();

            frm.Show();
            this.Hide();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVienChoQuanLy frm = new FrmNhanVienChoQuanLy();

            frm.Show();
            this.Hide();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();

            frm.Show();
            this.Hide();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            // mo menu nho: cai dat / doi mat khau / dang xuat
            var menu = new ContextMenuStrip();
            menu.Items.Add("Cài đặt", null, (s, ev) => MoCaiDat());
            menu.Items.Add("Đổi mật khẩu", null, (s, ev) => MoDoiMatKhau());
            menu.Items.Add("Đăng xuất", null, (s, ev) => DangXuatTaiKhoan());
            menu.Show(btnCaiDat, new Point(0, btnCaiDat.Height));
        }

        private void MoCaiDat()
        {
            var frm = new FrmCaiDatChoQuanLy();
            frm.Show();
            this.Hide();
        }

        private void MoDoiMatKhau()
        {
            int ma = FrmLogin.TaiKhoanDangNhap?.MaTaiKhoan ?? 0;
            if (ma == 0) return;
            using (var f = new FrmThayDoiMatKhau(ma))
                f.ShowDialog();
        }

        public bool DangXuat = false;

        private void DangXuatTaiKhoan()
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DangXuat = true;

                FrmLogin frm = new FrmLogin();

                frm.Show();
                this.Hide();
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  KHỞI TẠO COMBOBOX
        // ═══════════════════════════════════════════════════════════════
        private void KhoiTaoComboBox()
        {
            // Loại khuyến mãi
            cboLoaiKhuyenMai.Items.Clear();
            cboLoaiKhuyenMai.Items.Add(new ComboItem("Toàn bộ hóa đơn", "ToanBoHoaDon"));
            cboLoaiKhuyenMai.Items.Add(new ComboItem("Nhóm sản phẩm",   "NhomSanPham"));
            cboLoaiKhuyenMai.Items.Add(new ComboItem("Sản phẩm",        "SanPham"));
            cboLoaiKhuyenMai.DisplayMember = "Display";
            cboLoaiKhuyenMai.ValueMember   = "Value";
            cboLoaiKhuyenMai.SelectedIndex = 0;

            // Loại giảm giá
            cboLoaiGiamGia.Items.Clear();
            cboLoaiGiamGia.Items.Add(new ComboItem("Phần trăm (%)", "PhanTram"));
            cboLoaiGiamGia.Items.Add(new ComboItem("Tiền mặt (đ)",  "TienMat"));
            cboLoaiGiamGia.DisplayMember = "Display";
            cboLoaiGiamGia.ValueMember   = "Value";
            cboLoaiGiamGia.SelectedIndex = 0;

            // Cache dữ liệu LoaiSanPham & SanPham
            _dtLoaiSanPham = SQLConnection.ExecuteQuery("SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai");
            _dtSanPham     = SQLConnection.ExecuteQuery("SELECT MaSanPham, TenSanPham FROM SanPham WHERE TrangThai = 1 ORDER BY TenSanPham");
        }

        // ═══════════════════════════════════════════════════════════════
        //  CẬP NHẬT COMBOBOX ĐỐI TƯỢNG THEO LOẠI KHUYẾN MÃI
        // ═══════════════════════════════════════════════════════════════
        private void cboLoaiKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDoiTuong();
        }

        private void LoadDoiTuong()
        {
            string loai = GetLoaiKhuyenMaiValue();

            cboDoiTuong.Items.Clear();
            cboDoiTuong.DisplayMember = "Display";
            cboDoiTuong.ValueMember   = "Value";

            if (loai == "NhomSanPham" && _dtLoaiSanPham != null)
            {
                lblDoiTuong.Text     = "Nhóm sản phẩm:";
                cboDoiTuong.Enabled  = true;
                foreach (DataRow row in _dtLoaiSanPham.Rows)
                    cboDoiTuong.Items.Add(new ComboItem(row["TenLoai"].ToString(), row["MaLoai"].ToString()));
                if (cboDoiTuong.Items.Count > 0) cboDoiTuong.SelectedIndex = 0;
            }
            else if (loai == "SanPham" && _dtSanPham != null)
            {
                lblDoiTuong.Text     = "Sản phẩm:";
                cboDoiTuong.Enabled  = true;
                foreach (DataRow row in _dtSanPham.Rows)
                    cboDoiTuong.Items.Add(new ComboItem(row["TenSanPham"].ToString(), row["MaSanPham"].ToString()));
                if (cboDoiTuong.Items.Count > 0) cboDoiTuong.SelectedIndex = 0;
            }
            else
            {
                lblDoiTuong.Text    = "Sản phẩm / Nhóm:";
                cboDoiTuong.Enabled = false;   // ToanBoHoaDon – không cần đối tượng
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  TẢI DANH SÁCH KHUYẾN MÃI
        // ═══════════════════════════════════════════════════════════════
        private void LoadDanhSachKhuyenMai()
        {
            try
            {
                List<KhuyenMaiDTO> list = _bus.GetAll();
                DataTable dt = new DataTable();
                dt.Columns.Add("MaKhuyenMai",   typeof(int));
                dt.Columns.Add("Mã Code",        typeof(string));
                dt.Columns.Add("Tên KM",         typeof(string));
                dt.Columns.Add("Loại KM",        typeof(string));
                dt.Columns.Add("Đối tượng",      typeof(string));
                dt.Columns.Add("Kiểu giảm",      typeof(string));
                dt.Columns.Add("Giá trị giảm",   typeof(decimal));
                dt.Columns.Add("Đơn tối thiểu",  typeof(decimal));
                dt.Columns.Add("Giảm tối đa",    typeof(string));
                dt.Columns.Add("Ngày BĐ",        typeof(string));
                dt.Columns.Add("Ngày KT",        typeof(string));
                dt.Columns.Add("Số lượng",       typeof(string));
                dt.Columns.Add("Đã dùng",        typeof(int));
                dt.Columns.Add("Trạng thái",     typeof(string));

                foreach (var km in list)
                {
                    string doiTuong = km.LoaiKhuyenMai == "NhomSanPham" ? (km.TenLoai ?? "")
                                    : km.LoaiKhuyenMai == "SanPham"     ? (km.TenSanPham ?? "")
                                    : "Tất cả";

                    string loaiKMHienThi = km.LoaiKhuyenMai == "ToanBoHoaDon" ? "Toàn hóa đơn"
                                         : km.LoaiKhuyenMai == "NhomSanPham"  ? "Nhóm SP"
                                         : "Sản phẩm";

                    string kieuGiam = km.LoaiGiamGia == "PhanTram" ? "%" : "Tiền mặt";

                    dt.Rows.Add(
                        km.MaKhuyenMai,
                        km.Code,
                        km.TenKhuyenMai,
                        loaiKMHienThi,
                        doiTuong,
                        kieuGiam,
                        km.GiaTriGiam,
                        km.GiaTriGiaoDichToiThieu,
                        km.GiamToiDa.HasValue ? km.GiamToiDa.Value.ToString("N0") : "Không giới hạn",
                        km.NgayBatDau.ToString("dd/MM/yyyy HH:mm"),
                        km.NgayKetThuc.ToString("dd/MM/yyyy HH:mm"),
                        km.SoLuong.HasValue ? km.SoLuong.Value.ToString() : "Không giới hạn",
                        km.SoLuongDaDung,
                        km.TrangThai ? "Hoạt động" : "Ngưng"
                    );
                }

                dgvKhuyenMai.DataSource = dt;
                dgvKhuyenMai.Columns["MaKhuyenMai"].Visible = false;  // Ẩn khóa chính

                // Tô màu dòng ngưng hoạt động
                foreach (DataGridViewRow row in dgvKhuyenMai.Rows)
                {
                    if (row.Cells["Trạng thái"].Value?.ToString() == "Ngưng")
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khuyến mãi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  CLICK DÒNG TRONG LƯỚI → ĐỔ DỮ LIỆU LÊN FORM
        // ═══════════════════════════════════════════════════════════════
        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];

            _maKhuyenMaiDangChon = Convert.ToInt32(row.Cells["MaKhuyenMai"].Value);

            // Lấy DTO đầy đủ từ BUS (để lấy MaLoai, MaSanPham nullable)
            List<KhuyenMaiDTO> list = _bus.GetAll();
            KhuyenMaiDTO km = list.Find(x => x.MaKhuyenMai == _maKhuyenMaiDangChon);
            if (km == null) return;

            // Đổ dữ liệu lên các trường
            txtCode.Text         = km.Code;
            txtTenKhuyenMai.Text = km.TenKhuyenMai;

            // Loại KM
            ChonComboBoTheoValue(cboLoaiKhuyenMai, km.LoaiKhuyenMai);
            LoadDoiTuong(); // Cập nhật cboDoiTuong cho đúng loại

            // Kiểu giảm giá
            ChonComboBoTheoValue(cboLoaiGiamGia, km.LoaiGiamGia);

            nudGiaTriGiam.Value      = km.GiaTriGiam;
            nudDonToiThieu.Value     = km.GiaTriGiaoDichToiThieu;
            nudGiamToiDa.Value       = km.GiamToiDa ?? 0;
            dtpNgayBatDau.Value      = km.NgayBatDau;
            dtpNgayKetThuc.Value     = km.NgayKetThuc;
            nudSoLuong.Value         = km.SoLuong ?? 0;
            chkTrangThai.Checked     = km.TrangThai;

            // Chọn đối tượng trong cboDoiTuong
            if (km.LoaiKhuyenMai == "NhomSanPham" && km.MaLoai.HasValue)
                ChonComboBoTheoValue(cboDoiTuong, km.MaLoai.Value.ToString());
            else if (km.LoaiKhuyenMai == "SanPham" && km.MaSanPham.HasValue)
                ChonComboBoTheoValue(cboDoiTuong, km.MaSanPham.Value.ToString());

            DatTrangThaiNut(true);
        }

        // ═══════════════════════════════════════════════════════════════
        //  THÊM MỚI
        // ═══════════════════════════════════════════════════════════════
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateDuLieu()) return;

            KhuyenMaiDTO km = LayDuLieuTuForm();

            try
            {
                if (_bus.Insert(km))
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiForm();
                    LoadDanhSachKhuyenMai();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công. Kiểm tra lại dữ liệu.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  CẬP NHẬT
        // ═══════════════════════════════════════════════════════════════
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maKhuyenMaiDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi trong danh sách để cập nhật.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateDuLieu()) return;

            KhuyenMaiDTO km = LayDuLieuTuForm();
            km.MaKhuyenMai = _maKhuyenMaiDangChon;

            try
            {
                if (_bus.Update(km))
                {
                    MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiForm();
                    LoadDanhSachKhuyenMai();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  NGƯNG / XÓA (Soft-delete)
        // ═══════════════════════════════════════════════════════════════
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maKhuyenMaiDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi trong danh sách.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn ngưng khuyến mãi này không?\n(Trạng thái sẽ chuyển sang Ngưng)",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                if (_bus.Delete(_maKhuyenMaiDangChon))
                {
                    MessageBox.Show("Đã ngưng khuyến mãi thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoiForm();
                    LoadDanhSachKhuyenMai();
                }
                else
                {
                    MessageBox.Show("Không thể ngưng khuyến mãi.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  LÀM MỚI FORM
        // ═══════════════════════════════════════════════════════════════
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void LamMoiForm()
        {
            _maKhuyenMaiDangChon = 0;

            txtCode.Text         = string.Empty;
            txtTenKhuyenMai.Text = string.Empty;

            cboLoaiKhuyenMai.SelectedIndex = 0;
            cboLoaiGiamGia.SelectedIndex   = 0;
            LoadDoiTuong();

            nudGiaTriGiam.Value  = 0;
            nudDonToiThieu.Value = 0;
            nudGiamToiDa.Value   = 0;
            nudSoLuong.Value     = 0;

            dtpNgayBatDau.Value  = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddDays(30);

            chkTrangThai.Checked = true;

            dgvKhuyenMai.ClearSelection();
            DatTrangThaiNut(false);
        }

        // ═══════════════════════════════════════════════════════════════
        //  VALIDATE
        // ═══════════════════════════════════════════════════════════════
        private bool ValidateDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Code khuyến mãi.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhuyenMai.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên khuyến mãi.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhuyenMai.Focus();
                return false;
            }

            if (nudGiaTriGiam.Value <= 0)
            {
                MessageBox.Show("Giá trị giảm phải lớn hơn 0.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Nếu là phần trăm, không được vượt 100
            if (GetLoaiGiamGiaValue() == "PhanTram" && nudGiaTriGiam.Value > 100)
            {
                MessageBox.Show("Giá trị giảm theo phần trăm không được vượt quá 100%.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string loai = GetLoaiKhuyenMaiValue();
            if ((loai == "NhomSanPham" || loai == "SanPham") && cboDoiTuong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng áp dụng (nhóm sản phẩm / sản phẩm).",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ═══════════════════════════════════════════════════════════════
        //  LẤY DỮ LIỆU TỪ FORM → KhuyenMaiDTO
        // ═══════════════════════════════════════════════════════════════
        private KhuyenMaiDTO LayDuLieuTuForm()
        {
            string loai = GetLoaiKhuyenMaiValue();

            int? maLoai    = null;
            int? maSanPham = null;

            if (loai == "NhomSanPham" && cboDoiTuong.SelectedItem is ComboItem ci1)
                maLoai = int.Parse(ci1.Value);
            else if (loai == "SanPham" && cboDoiTuong.SelectedItem is ComboItem ci2)
                maSanPham = int.Parse(ci2.Value);

            return new KhuyenMaiDTO
            {
                Code                        = txtCode.Text.Trim().ToUpper(),
                TenKhuyenMai                = txtTenKhuyenMai.Text.Trim(),
                LoaiKhuyenMai               = loai,
                LoaiGiamGia                 = GetLoaiGiamGiaValue(),
                GiaTriGiam                  = nudGiaTriGiam.Value,
                GiaTriGiaoDichToiThieu      = nudDonToiThieu.Value,
                GiamToiDa                   = nudGiamToiDa.Value > 0 ? (decimal?)nudGiamToiDa.Value : null,
                NgayBatDau                  = dtpNgayBatDau.Value,
                NgayKetThuc                 = dtpNgayKetThuc.Value,
                SoLuong                     = nudSoLuong.Value > 0 ? (int?)Convert.ToInt32(nudSoLuong.Value) : null,
                TrangThai                   = chkTrangThai.Checked,
                MaLoai                      = maLoai,
                MaSanPham                   = maSanPham,
                SoLuongDaDung               = 0
            };
        }

        // ═══════════════════════════════════════════════════════════════
        //  HELPER – LẤY VALUE COMBOBOX
        // ═══════════════════════════════════════════════════════════════
        private string GetLoaiKhuyenMaiValue()
        {
            return (cboLoaiKhuyenMai.SelectedItem as ComboItem)?.Value ?? "ToanBoHoaDon";
        }

        private string GetLoaiGiamGiaValue()
        {
            return (cboLoaiGiamGia.SelectedItem as ComboItem)?.Value ?? "PhanTram";
        }

        private void ChonComboBoTheoValue(ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i] is ComboItem item && item.Value == value)
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  BẬT / TẮT NÚT THEO TRẠNG THÁI
        // ═══════════════════════════════════════════════════════════════
        private void DatTrangThaiNut(bool coChonDong)
        {
            btnThem.Enabled  = true;        // Luôn cho thêm
            btnSua.Enabled   = coChonDong;
            btnXoa.Enabled   = coChonDong;
        }

    }

    // ═══════════════════════════════════════════════════════════════════
    //  HELPER CLASS – Item cho ComboBox (hiển thị / giá trị)
    // ═══════════════════════════════════════════════════════════════════
    internal class ComboItem
    {
        public string Display { get; }
        public string Value   { get; }

        public ComboItem(string display, string value)
        {
            Display = display;
            Value   = value;
        }

        public override string ToString() => Display;
    }
}
