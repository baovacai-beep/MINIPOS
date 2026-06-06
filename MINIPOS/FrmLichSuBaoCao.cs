using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MINIPOS_DAO; // Thư viện chứa lớp kết nối SQLConnection của hệ thống

namespace MINIPOS
{
    public partial class FrmLichSuBaoCao : Form
    {
        public FrmLichSuBaoCao()
        {
            InitializeComponent();

            // Tự động gán sự kiện Click an toàn bằng code (Không lo bị lỗi Designer)
            this.Load += new EventHandler(FrmLichSuBaoCao_Load);
            if (btnLoc != null) btnLoc.Click += new EventHandler(btnLoc_Click);
            if (btnSua != null) btnSua.Click += new EventHandler(btnXemChiTietHoaDon_Click);
            if (btnXoa != null) btnXoa.Click += new EventHandler(btnXoa_Click);
        }

        private void FrmLichSuBaoCao_Load(object sender, EventArgs e)
        {
            // Thay đổi text nút sửa cũ thành "Xem Hóa Đơn" cho đúng tính năng thực tế của bạn
            if (btnSua != null) btnSua.Text = "Xem Hóa Đơn";

            // Cấu hình giao diện DataGridView theo chuẩn hiện đại
            DinhDangDataGridView();

            // Mặc định khoảng thời gian lọc hóa đơn trong 30 ngày gần đây
            dtpTuNgay.Value = DateTime.Now.AddDays(-30).Date;
            dtpDenNgay.Value = DateTime.Now.Date;

            LoadDanhSachHoaDon();
        }

        private void DinhDangDataGridView()
        {
            dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSu.MultiSelect = false;
            dgvLichSu.RowHeadersVisible = false;
            dgvLichSu.AllowUserToAddRows = false;
            dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            dgvLichSu.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(242, 244, 244);
            dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSu.RowTemplate.Height = 28;
        }

        /// <summary>
        /// Nạp danh sách hóa đơn tính tiền từ cơ sở dữ liệu lên Grid (Đã bỏ cột GiamGia)
        /// </summary>
        private void LoadDanhSachHoaDon()
        {
            try
            {
                // Lấy trọn vẹn từ 00:00:00 ngày bắt đầu đến 23:59:59 ngày kết thúc
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                string tuKhoa = txtSearch.Text.Trim();

                DataTable dtValid = new DataTable();
                using (SqlConnection conn = SQLConnection.GetConnection())
                {
                    // ĐÃ LOẠI BỎ cột hd.GiamGia để tránh lỗi Database
                    string sql = @"SELECT hd.MaHoaDon, 
                                          hd.NgayLap, 
                                          ISNULL(kh.TenKhachHang, N'Khách vãng lai') AS TenKhachHang, 
                                          hd.TongTien, 
                                          hd.ThanhTien
                                   FROM HoaDon hd
                                   LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                                   WHERE hd.NgayLap >= @TuNgay AND hd.NgayLap <= @DenNgay
                                     AND (CAST(hd.MaHoaDon AS NVARCHAR) LIKE @Search OR kh.TenKhachHang LIKE @Search)
                                   ORDER BY hd.NgayLap DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                        cmd.Parameters.AddWithValue("@Search", "%" + tuKhoa + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtValid);
                    }
                }

                dgvLichSu.DataSource = dtValid;

                // Định dạng hiển thị tiêu đề và ngày giờ, tiền tệ cụ thể
                if (dgvLichSu.Columns.Count > 0)
                {
                    if (dgvLichSu.Columns["MaHoaDon"] != null) dgvLichSu.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                    if (dgvLichSu.Columns["TenKhachHang"] != null) dgvLichSu.Columns["TenKhachHang"].HeaderText = "Khách Hàng";

                    // Hiển thị đầy đủ Ngày/Tháng/Năm Giờ:Phút:Giây tinh tế
                    if (dgvLichSu.Columns["NgayLap"] != null)
                    {
                        dgvLichSu.Columns["NgayLap"].HeaderText = "Thời Gian Lập";
                        dgvLichSu.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    }

                    if (dgvLichSu.Columns["TongTien"] != null)
                    {
                        dgvLichSu.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        dgvLichSu.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvLichSu.Columns["ThanhTien"] != null)
                    {
                        dgvLichSu.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                        dgvLichSu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử hóa đơn bán hàng:\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀNH ĐỘNG CỦA NÚT LỌC
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }

        // HÀNH ĐỘNG CỦA NÚT XEM CHI TIẾT HÓA ĐƠN TÍNH TIỀN (GỌI SANG FORM IN)
        private void btnXemChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null || dgvLichSu.CurrentRow.Cells["MaHoaDon"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách để xem phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maHoaDon = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaHoaDon"].Value);

            try
            {
                DataTable dtMaster = new DataTable();
                DataTable dtDetail = new DataTable();

                using (SqlConnection conn = SQLConnection.GetConnection())
                {
                    // 1. Tải thông tin chung hóa đơn tính tiền (ĐÃ BỎ HOÀN TOÀN kh.DienThoai)
                    string sqlMaster = @"SELECT hd.MaHoaDon, hd.NgayLap, hd.TongTien, hd.ThanhTien,
                                                ISNULL(kh.TenKhachHang, N'Khách vãng lai') AS TenKhachHang
                                         FROM HoaDon hd
                                         LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                                         WHERE hd.MaHoaDon = @MaHoaDon";
                    using (SqlCommand cmd = new SqlCommand(sqlMaster, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtMaster);
                    }

                    // 2. Tải chi tiết các mặt hàng có trong hóa đơn tính tiền đó
                    string sqlDetail = @"SELECT sp.TenSanPham, cthd.SoLuong, cthd.DonGia, cthd.ThanhTien, cthd.MaHoaDon
                                         FROM ChiTietHoaDon cthd
                                         JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
                                         WHERE cthd.MaHoaDon = @MaHoaDon";
                    using (SqlCommand cmd = new SqlCommand(sqlDetail, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtDetail);
                    }
                }

                if (dtMaster.Rows.Count > 0)
                {
                    // Khởi tạo Form xem hóa đơn và truyền 2 bảng dữ liệu vào
                    FrmInHoaDon frmIn = new FrmInHoaDon(dtMaster, dtDetail);
                    frmIn.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu nguồn của hóa đơn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải biểu mẫu hiển thị hóa đơn:\n" + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀNH ĐỘNG CỦA NÚT XÓA HỦY HÓA ĐƠN CỦA BẠN
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null || dgvLichSu.CurrentRow.Cells["MaHoaDon"].Value == null)
            {
                MessageBox.Show("Vui lòng click chọn hóa đơn cần xóa hủy khỏi danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maHoaDon = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaHoaDon"].Value);

            if (MessageBox.Show($"Bạn có chắc chắn muốn XÓA HỦY hoàn toàn hóa đơn số {maHoaDon} này không?", "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = SQLConnection.GetConnection())
                    {
                        string sqlDelete = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã thực hiện xóa hủy hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon(); // Làm tươi lại danh sách lưới dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiện xóa dữ liệu:\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}