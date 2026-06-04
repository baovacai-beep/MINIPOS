using FontAwesome.Sharp;
using MINIPOS_DAO;
using MINIPOS_BUS;
using MINIPOS_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;

namespace MINIPOS
{
    public partial class MainFormForManager : Form
    {
        // ── BUS layer ──────────────────────────────────────────────
        private readonly HoaDonBUS    _hoaDonBUS    = new HoaDonBUS();
        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();

        // ── Trạng thái khách hàng đang chọn ───────────────────────
        private KhachHangDTO _khachHang = null;   // null = khách vãng lai

        // ── Cột ẩn lưu MaSanPham trong dgvGioHang ─────────────────
        private const int COL_MASP      = 0;  // ẩn
        private const int COL_STT       = 1;
        private const int COL_TENSP     = 2;
        private const int COL_DONGIA    = 3;
        private const int COL_SOLUONG   = 4;  // editable
        private const int COL_THANHTIEN = 5;

        public MainFormForManager()
        {
            InitializeComponent();

            this.FormClosed += MainFormForManager_FormClosed;
        }

        private void MainFormForManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            InventoryForManager frm = new InventoryForManager();

            frm.Show();
            this.Hide();
        }

        // hiển thị tất cả SP
        private void LoadSanPham(string where = "")
        {
            string sql = @"
                SELECT MaSanPham AS [Mã SP],
                       TenSanPham AS [Tên SP],
                       TenLoai AS [Loại SP],
                       DonGiaBan AS [Đơn giá],
                       DonViTinh AS [Đơn vị],
                       SoLuongTon AS [Tồn kho]
                FROM v_SanPham
                WHERE TrangThai = 1 "
                + (string.IsNullOrEmpty(where) ? "" : "AND " + where);
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(sql);
        }

        private void MainFormForManager_Load(object sender, EventArgs e)
        {
            KhoiTaoGioHang();
            WireUpButtons();
            LoadSanPham();
        }

        private void KhoiTaoGioHang()
        {
            dgvGioHang.Columns.Clear();

            // Cột ẩn: MaSanPham
            var colMaSP = new DataGridViewTextBoxColumn
            {
                Name    = "MaSanPham",
                Visible = false
            };

            var colSTT = new DataGridViewTextBoxColumn
            {
                Name         = "STT",
                HeaderText   = "STT",
                ReadOnly     = true,
                Width        = 35
            };
            var colTen = new DataGridViewTextBoxColumn
            {
                Name         = "TenSP",
                HeaderText   = "Tên sản phẩm",
                ReadOnly     = true
            };
            var colGia = new DataGridViewTextBoxColumn
            {
                Name         = "DonGia",
                HeaderText   = "Đơn giá",
                ReadOnly     = true,
                Width        = 65,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            };
            var colSL = new DataGridViewTextBoxColumn
            {
                Name         = "SoLuong",
                HeaderText   = "SL",
                ReadOnly     = false,
                Width        = 40
            };
            var colTT = new DataGridViewTextBoxColumn
            {
                Name         = "ThanhTien",
                HeaderText   = "Thành tiền",
                ReadOnly     = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            };

            dgvGioHang.Columns.AddRange(colMaSP, colSTT, colTen, colGia, colSL, colTT);
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.Columns["STT"].AutoSizeMode     = DataGridViewAutoSizeColumnMode.None;
            dgvGioHang.Columns["STT"].Width            = 35;
            dgvGioHang.Columns["SoLuong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvGioHang.Columns["SoLuong"].Width        = 45;
        }

        private void WireUpButtons()
        {
            btnThanhToan.Click += BtnThanhToan_Click;
            btnVoucher.Click   += BtnTraCuuKhachHang_Click;
            btnXoaHang.Click   += btnXoaHang_Click;
        }

        //tim kiem SP theo ten
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTimKiem.Text.Trim().Replace("'", "''");
            LoadSanPham($"TenSanPham LIKE N'%{ten}%'");
        }

        private void btnAll_Click(object sender, EventArgs e)      => LoadSanPham();
        private void btnDrink_Click(object sender, EventArgs e)    => LoadSanPham("TenLoai = N'Nước uống & Đồ uống'");
        private void btnBanhKeo_Click(object sender, EventArgs e)  => LoadSanPham("TenLoai = N'Bánh kẹo & Snack'");
        private void btnMi_Click(object sender, EventArgs e)       => LoadSanPham("TenLoai = N'Mì & Thực phẩm ăn liền'");
        private void btnSua_Click(object sender, EventArgs e)      => LoadSanPham("TenLoai = N'Sữa & Sản phẩm từ sữa'");
        private void btnVPP_Click(object sender, EventArgs e)      => LoadSanPham("TenLoai = N'Văn phòng phẩm'");
        private void btnMyPham_Click(object sender, EventArgs e)   => LoadSanPham("TenLoai = N'Mỹ phẩm & Chăm sóc cá nhân'");
        private void btnGiaVi_Click(object sender, EventArgs e)    => LoadSanPham("TenLoai = N'Gia vị & Thực phẩm khô'");

        //double click de them SP vao gio hang
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row    = dgvSanPham.Rows[e.RowIndex];
            int maSP   = Convert.ToInt32(row.Cells["Mã SP"].Value);
            string ten = row.Cells["Tên SP"].Value.ToString();
            decimal gia = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
            int tonKho  = Convert.ToInt32(row.Cells["Tồn kho"].Value);

            // Kiểm tra trùng
            foreach (DataGridViewRow r in dgvGioHang.Rows)
            {
                if (r.Cells[COL_MASP].Value != null &&
                    Convert.ToInt32(r.Cells[COL_MASP].Value) == maSP)
                {
                    int slHienTai = Convert.ToInt32(r.Cells[COL_SOLUONG].Value);
                    if (slHienTai >= tonKho)
                    {
                        MessageBox.Show($"'{ten}' chỉ còn {tonKho} trong kho.",
                            "Không đủ hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    r.Cells[COL_SOLUONG].Value   = slHienTai + 1;
                    r.Cells[COL_THANHTIEN].Value = gia * (slHienTai + 1);
                    TinhTongTien();
                    return;
                }
            }

            // Thêm dòng mới
            int stt = dgvGioHang.Rows.Count + 1;
            dgvGioHang.Rows.Add(maSP, stt, ten, gia, 1, gia);
            TinhTongTien();
        }

        //tong tien gio hang
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
                if (row.Cells[COL_THANHTIEN].Value != null)
                    tong += Convert.ToDecimal(row.Cells[COL_THANHTIEN].Value);

            txtTongTien.Text = tong.ToString("N0") + " đ";
            return tong;
        }

        //dieu chinh so luong hang trong gio
        private void dgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != COL_SOLUONG) return;

            var row = dgvGioHang.Rows[e.RowIndex];
            int sl;
            if (!int.TryParse(row.Cells[COL_SOLUONG].Value?.ToString(), out sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells[COL_SOLUONG].Value = 1;
                sl = 1;
            }

            decimal gia              = Convert.ToDecimal(row.Cells[COL_DONGIA].Value);
            row.Cells[COL_THANHTIEN].Value = gia * sl;
            TinhTongTien();
        }

        //xoa hang trong gio
        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null) return;
            dgvGioHang.Rows.Remove(dgvGioHang.CurrentRow);
            CapNhatSTT();
            TinhTongTien();
        }

        private void CapNhatSTT()
        {
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
                dgvGioHang.Rows[i].Cells[COL_STT].Value = i + 1;
        }


        private void BtnTraCuuKhachHang_Click(object sender, EventArgs e)
        {
            string sdt = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập số điện thoại khách hàng:", "Tra cứu khách hàng", "");

            if (string.IsNullOrWhiteSpace(sdt)) return;

            KhachHangDTO kh = _khachHangBUS.TimKiemTheoSDT(sdt);
            if (kh == null)
            {
                MessageBox.Show($"Không tìm thấy khách hàng có SĐT: {sdt}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _khachHang = kh;
            CapNhatHienThiKhachHang();
        }

        private void CapNhatHienThiKhachHang()
        {
            if (_khachHang == null)
            {
                label1.Text = "Giỏ hàng";
                label1.ForeColor = Color.Black;
            }
            else
            {
                label1.Text = $"Giỏ hàng  |  KH: {_khachHang.TenKhachHang}" +
                              $"  [{_khachHang.TenHang} -{_khachHang.TyLeGiamGia:0}%]";
                label1.ForeColor = Color.DarkBlue;
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin nhân viên từ Login
            int maNV = Login.TaiKhoanDangNhap?.MaNhanVien ?? 0;
            if (maNV == 0)
            {
                MessageBox.Show("Không xác định được nhân viên. Vui lòng đăng nhập lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tổng tiền & giảm giá
            decimal tongTien     = TinhTongTien();
            decimal tyLeGiam     = _khachHang?.TyLeGiamGia ?? 0;
            decimal soTienGiam   = Math.Round(tongTien * tyLeGiam / 100, 0);
            decimal thanhTien    = tongTien - soTienGiam;

            // Hiển thị dialog thanh toán
            using (var dlg = new ThanhToanDialog(tongTien, tyLeGiam, soTienGiam, thanhTien, _khachHang))
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                // Xây dựng HoaDonDTO
                var hd = new HoaDonDTO
                {
                    MaNhanVien          = maNV,
                    MaKhachHang         = _khachHang?.MaKhachHang,
                    TongTien            = tongTien,
                    TyLeGiamGia         = tyLeGiam,
                    SoTienGiam          = soTienGiam,
                    ThanhTien           = thanhTien,
                    TienKhachDua        = dlg.TienKhachDua,
                    TienThoi            = dlg.TienThoi,
                    PhuongThucThanhToan = dlg.PhuongThuc,
                    GhiChu              = null
                };

                // Thêm chi tiết từ giỏ hàng
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    hd.ChiTiet.Add(new ChiTietHoaDonDTO
                    {
                        MaSanPham  = Convert.ToInt32(row.Cells[COL_MASP].Value),
                        TenSanPham = row.Cells[COL_TENSP].Value.ToString(),
                        DonGia     = Convert.ToDecimal(row.Cells[COL_DONGIA].Value),
                        SoLuong    = Convert.ToInt32(row.Cells[COL_SOLUONG].Value)
                    });
                }

                try
                {
                    int maHD = _hoaDonBUS.ThanhToan(hd);
                    MessageBox.Show("Thanh toán thành công ✔", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ============================================================
                    // ĐOẠN ĐỔ DỮ LIỆU ĐỘNG VÀO DATASET ĐỂ GỌI BIỂU MẪU IN RDLC
                    // ============================================================

                    // 1. SỬA LẠI: Khởi tạo bảng Master chuẩn từ dsHoaDon
                    var dtMaster = new dsHoaDon.DataTableMasterDataTable();

                    // SỬA LẠI: Tạo dòng mới dựa trên cấu trúc chuẩn cấu hình sẵn
                    var rowMaster = dtMaster.NewRow();
                    rowMaster["MaHoaDon"] = maHD;
                    rowMaster["NgayLap"] = DateTime.Now;
                    rowMaster["TenNhanVien"] = Login.TaiKhoanDangNhap?.HoTen ?? "Nhân viên";
                    rowMaster["TenKhachHang"] = _khachHang != null ? _khachHang.HoTen : "Khách vãng lai";
                    rowMaster["HangThanhVien"] = _khachHang != null ? _khachHang.HangThanhVienID.ToString() : "Không có";
                    rowMaster["TongTien"] = hd.TongTien;
                    rowMaster["TienNhan"] = dlg.TienKhachDua; // Biến nhận từ form tiền mặt của nhóm bạn
                    rowMaster["TienThoi"] = dlg.TienThoi;

                    // Add dòng vừa tạo vào bảng Master
                    dtMaster.Rows.Add(rowMaster);


                    // 2. SỬA LẠI: Khởi tạo bảng Detail chuẩn từ dsHoaDon
                    var dtDetail = new dsHoaDon.DataTableDetailDataTable();

                    // Trích xuất danh sách sản phẩm hiện có trong GridView giỏ hàng để in chi tiết
                    foreach (DataGridViewRow row in dgvGioHang.Rows)
                    {
                        if (row.Cells[COL_MASP].Value != null)
                        {
                            // SỬA LẠI: Tạo dòng mới dựa trên cấu trúc chuẩn của bảng Detail
                            var rowDetail = dtDetail.NewRow();
                            rowDetail["TenSanPham"] = row.Cells[COL_TENSP].Value.ToString();
                            rowDetail["SoLuong"] = Convert.ToInt32(row.Cells[COL_SOLUONG].Value);
                            rowDetail["DonGia"] = Convert.ToDecimal(row.Cells[COL_DONGIA].Value);
                            rowDetail["ThanhTien"] = Convert.ToDecimal(row.Cells[COL_THANHTIEN].Value);
                            rowDetail["MaHoaDon"] = maHD; // Liên kết khóa ngoại nếu phôi cần sử dụng

                            // Add dòng chi tiết vào bảng Detail
                            dtDetail.Rows.Add(rowDetail);
                        }
                    }

                    // Khởi tạo cửa sổ xem trước hóa đơn và kích hoạt lệnh in (Truyền dtMaster và dtDetail chuẩn vào)
                    FrmInHoaDon frmPrint = new FrmInHoaDon(dtMaster, dtDetail);
                    frmPrint.ShowDialog();

                    // Reset dọn dẹp giỏ hàng bán hàng như cũ
                    dgvGioHang.Rows.Clear();
                    _khachHang = null;
                    CapNhatHienThiKhachHang();
                    TinhTongTien();
                    LoadSanPham();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán hoặc lỗi kết xuất bản in:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Khai báo lớp nghiệp vụ ở vùng biến cục bộ của Form chính
        private readonly HoaDonNhapBUS _hdNhapBUS = new HoaDonNhapBUS();

        // SỰ KIỆN 1: BẤM NÚT LƯU TẠM HÓA ĐƠN
        private void btnLuuTam_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng hiện tại đang trống, không thể tiến hành lưu nháp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại nhập tên gợi nhớ danh tính nhanh
            string ghiChu = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên khách hàng hoặc ghi chú nhận diện hóa đơn tạm:", "Hệ thống treo hóa đơn", "Khách chờ...");
            if (string.IsNullOrWhiteSpace(ghiChu)) return;

            // Khởi tạo cấu trúc DataTable để chuyển đổi dữ liệu từ DataGridView giỏ hàng hiện hành
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("MaSanPham", typeof(int));
            dtTemp.Columns.Add("SoLuong", typeof(int));

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.Cells[COL_MASP].Value != null)
                {
                    dtTemp.Rows.Add(Convert.ToInt32(row.Cells[COL_MASP].Value), Convert.ToInt32(row.Cells[COL_SOLUONG].Value));
                }
            }

            int maNVDangNhap = Login.TaiKhoanDangNhap.MaNhanVien;

            if (_hdNhapBUS.LuuTamHoaDon(maNVDangNhap, ghiChu, dtTemp))
            {
                MessageBox.Show("Hóa đơn đã được treo tạm thời vào hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvGioHang.Rows.Clear();
                TinhTongTien(); // Cập nhật lại nhãn tiền tổng về 0 trên màn hình của bạn
            }
        }

        // SỰ KIỆN 2: BẤM NÚT XEM DANH SÁCH HOÁ ĐƠN NHÁP ĐÃ LƯU
        private void btnXemHDNhap_Click(object sender, EventArgs e)
        {
            FrmHoaDonNhap frm = new FrmHoaDonNhap();
            if (frm.ShowDialog() == DialogResult.OK && frm.DataRestore != null)
            {
                dgvGioHang.Rows.Clear();
                foreach (DataRow row in frm.DataRestore.Rows)
                {
                    int maSP = Convert.ToInt32(row["MaSanPham"]);
                    string tenSP = row["TenSanPham"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    decimal donGia = Convert.ToDecimal(row["DonGiaBan"]);
                    decimal thanhTien = soLuong * donGia;

                    // Đưa ngược dữ liệu hóa đơn nháp được chọn vào lại dgvGioHang
                    int rowIndex = dgvGioHang.Rows.Add();
                    dgvGioHang.Rows[rowIndex].Cells[COL_MASP].Value = maSP;
                    dgvGioHang.Rows[rowIndex].Cells[COL_STT].Value = rowIndex + 1;
                    dgvGioHang.Rows[rowIndex].Cells[COL_TENSP].Value = tenSP;
                    dgvGioHang.Rows[rowIndex].Cells[COL_DONGIA].Value = donGia;
                    dgvGioHang.Rows[rowIndex].Cells[COL_SOLUONG].Value = soLuong;
                    dgvGioHang.Rows[rowIndex].Cells[COL_THANHTIEN].Value = thanhTien;
                }
                TinhTongTien();
            }
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {

        }
    }
}
