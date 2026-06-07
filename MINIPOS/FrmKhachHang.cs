using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangBUS _bus = new KhachHangBUS();
        private int _maKHDangChon = 0;
        private bool _trangThaiKHDangChon = true;

        // Biến lưu trữ Form cha (Form gọi mở màn hình Khách hàng)
        private Form _parentForm = null;

        // Hàm khởi tạo mặc định (Bắt buộc giữ lại để Visual Studio kéo thả giao diện Designer)
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        // Hàm khởi tạo nâng cao: Nhận Form cha và tự động đăng ký sự kiện đóng Form
        public FrmKhachHang(Form parent) : this()
        {
            this._parentForm = parent;
            this.FormClosed += FrmKhachHang_FormClosed;
        }

        // Sự kiện kích hoạt khi Form Khách hàng đóng (Bấm X hoặc gọi Close)
        private void FrmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu có Form cha đang ẩn ngầm, chủ động hiện nó lên lại
            if (_parentForm != null)
            {
                _parentForm.Show();
            }
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            LoadDanhSach(_bus.GetAll());

            btnTimKH.Click += (s, ev) => LoadDanhSach(_bus.Search(txtTimKH.Text));

            btnLamMoi.Click += (s, ev) => LamMoiForm();
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
        }

        private void LoadDanhSach(DataTable dt)
        {
            dgvKhachHang.DataSource = dt;
            EveryColumnHeader();
            if (dgvKhachHang.Columns.Contains("MaKhachHang")) dgvKhachHang.Columns["MaKhachHang"].Visible = false;
            if (dgvKhachHang.Columns.Contains("MaHang")) dgvKhachHang.Columns["MaHang"].Visible = false;
            if (dgvKhachHang.Columns.Contains("DiaChi")) dgvKhachHang.Columns["DiaChi"].Visible = false;
            if (dgvKhachHang.Columns.Contains("NgayDangKy")) dgvKhachHang.Columns["NgayDangKy"].Visible = false;
        }

        // Đặt tiêu đề cột tiếng Việt cho dễ đọc (nếu cột tồn tại)
        private void EveryColumnHeader()
        {
            SetHeader("TenKhachHang", "Tên khách hàng");
            SetHeader("SoDienThoai", "SĐT");
            SetHeader("DiemTichLuy", "Điểm");
            SetHeader("TongChiTieu", "Tổng chi tiêu");
            SetHeader("TenHang", "Hạng");
            SetHeader("TyLeGiamGia", "% giảm");
            SetHeader("TrangThai", "Hoạt động");
        }

        private void SetHeader(string col, string text)
        {
            if (dgvKhachHang.Columns.Contains(col)) dgvKhachHang.Columns[col].HeaderText = text;
        }

        private void DgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            var r = dgvKhachHang.CurrentRow;
            if (r.Cells["MaKhachHang"].Value == null || r.Cells["MaKhachHang"].Value == DBNull.Value) return;

            _maKHDangChon = Convert.ToInt32(r.Cells["MaKhachHang"].Value);
            txtTen.Text = r.Cells["TenKhachHang"].Value?.ToString();
            txtSDT.Text = r.Cells["SoDienThoai"].Value?.ToString();
            txtDiaChi.Text = r.Cells["DiaChi"].Value?.ToString();
            _trangThaiKHDangChon = r.Cells["TrangThai"].Value != DBNull.Value &&
                                   r.Cells["TrangThai"].Value != null &&
                                   Convert.ToBoolean(r.Cells["TrangThai"].Value);

            string hang = r.Cells["TenHang"].Value?.ToString() ?? "Thường";
            int diem = (r.Cells["DiemTichLuy"].Value == null || r.Cells["DiemTichLuy"].Value == DBNull.Value)
                               ? 0 : Convert.ToInt32(r.Cells["DiemTichLuy"].Value);
            decimal giam = (r.Cells["TyLeGiamGia"].Value == null || r.Cells["TyLeGiamGia"].Value == DBNull.Value)
                               ? 0 : Convert.ToDecimal(r.Cells["TyLeGiamGia"].Value);

            CapNhatThe(txtTen.Text, hang, diem, giam);
            btnKhoaMo.Text = _trangThaiKHDangChon ? "Khóa" : "Mở khóa";
        }

        private void CapNhatThe(string ten, string hang, int diem, decimal giam)
        {
            lblTheTen.Text = string.IsNullOrWhiteSpace(ten) ? "(Chưa chọn)" : ten;
            lblTheHang.Text = "Hạng: " + hang;
            lblTheDiem.Text = "Điểm: " + diem;
            lblTheGiam.Text = "Giảm: " + giam.ToString("0.##") + "%";
            switch (hang)
            {
                case "Vàng": panelThe.BackColor = Color.FromArgb(241, 196, 15); break;
                case "Bạc": panelThe.BackColor = Color.FromArgb(189, 195, 199); break;
                default: panelThe.BackColor = Color.FromArgb(149, 165, 166); break;
            }
        }

        private void LamMoiForm()
        {
            _maKHDangChon = 0;
            txtTen.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
            CapNhatThe("", "Thường", 0, 0);
            btnKhoaMo.Text = "Khóa";
            dgvKhachHang.ClearSelection();
        }

        private KhachHangDTO LayTuForm()
        {
            return new KhachHangDTO
            {
                MaKhachHang = _maKHDangChon,
                TenKhachHang = txtTen.Text.Trim(),
                SoDienThoai = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim()
            };
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            var kh = LayTuForm();
            kh.MaKhachHang = 0;
            string loi;
            if (_bus.Them(kh, out loi))
            {
                MessageBox.Show("Đã thêm khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach(_bus.GetAll());
                LamMoiForm();
            }
            else MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (_maKHDangChon <= 0)
            {
                MessageBox.Show("Chọn khách hàng để sửa, hoặc bấm Thêm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string loi;
            if (_bus.Sua(LayTuForm(), out loi))
            {
                MessageBox.Show("Đã lưu thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach(_bus.GetAll());
            }
            else MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnKhoaMo_Click(object sender, EventArgs e)
        {
            if (_maKHDangChon <= 0)
            {
                MessageBox.Show("Chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool moi = !_trangThaiKHDangChon;
            if (_bus.DatTrangThai(_maKHDangChon, moi))
            {
                _trangThaiKHDangChon = moi;
                LoadDanhSach(_bus.GetAll());
            }
        }
    }
}