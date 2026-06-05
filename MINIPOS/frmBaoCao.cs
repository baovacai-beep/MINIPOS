using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms; // Đảm bảo đã cài Nuget Microsoft.ReportingServices.ReportViewerControl.Winforms
using MINIPOS_DAO;

namespace MINIPOS
{
    public partial class frmBaoCao : Form
    {
        // Namespace chứa các file RDLC trong project của bạn
        private const string REPORT_NS = "MINIPOS";

        public frmBaoCao()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách lựa chọn đúng thứ tự index
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Báo cáo Doanh thu");
            cboLoaiBaoCao.Items.Add("Báo cáo Top sản phẩm");
            cboLoaiBaoCao.Items.Add("Báo cáo Tồn kho");
            cboLoaiBaoCao.Items.Add("Báo cáo Danh sách hóa đơn");
            cboLoaiBaoCao.Items.Add("Báo cáo Khách hàng");
            cboLoaiBaoCao.SelectedIndex = 0;

            // Đặt thời gian mặc định: Đầu tháng đến ngày hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
        }

        // SỰ KIỆN NÚT BẤM XEM BÁO CÁO
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            int loaiBaoCaoIdx = cboLoaiBaoCao.SelectedIndex;
            if (loaiBaoCaoIdx < 0)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Làm sạch nguồn dữ liệu cũ bám trên ReportViewer để nạp mới hoàn toàn
                reportViewerCommon.LocalReport.DataSources.Clear();

                DataTable dtData = new DataTable();
                string rdlcFileName = "";
                string dataSetNameInRDLC = "";

                // Lấy giá trị ngày lọc từ giao diện (Thêm giờ phút để quét trọn vẹn dữ liệu trong ngày)
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

                // 2. Phân loại truy vấn dựa theo ComboBox được chọn
                switch (loaiBaoCaoIdx)
                {
                    case 0: // Báo cáo Doanh thu
                        rdlcFileName = "rptDoanhThu.rdlc";
                        dataSetNameInRDLC = "dsDoanhThu";
                        dtData = LayDuLieuDoanhThu(tuNgay, denNgay);
                        break;

                    case 1: // Báo cáo Top sản phẩm (Sẽ hiển thị dạng Bar Chart)
                        rdlcFileName = "rptTopSanPham.rdlc";
                        dataSetNameInRDLC = "dsTopSanPham";
                        dtData = LayDuLieuTopSanPham(tuNgay, denNgay);
                        break;

                    case 2: // Báo cáo Tồn kho
                        rdlcFileName = "rptTonKho.rdlc";
                        dataSetNameInRDLC = "dsTonKho";
                        dtData = LayDuLieuTonKho();
                        break;

                    case 3: // Báo cáo Danh sách hóa đơn
                        rdlcFileName = "rptDSHoaDon.rdlc";
                        dataSetNameInRDLC = "dsDSHoaDon";
                        dtData = LayDuLieuDSHoaDon(tuNgay, denNgay);
                        break;

                    case 4: // Báo cáo Khách hàng
                        rdlcFileName = "rptKhachHang.rdlc";
                        dataSetNameInRDLC = "dsKhachHang";
                        dtData = LayDuLieuKhachHang(tuNgay, denNgay);
                        break;
                }

                // 3. Liên kết file phôi rdlc vào ReportViewer
                // Sử dụng ReportPath nếu bạn để file rdlc ở ngoài thư mục ứng dụng, 
                // Hoặc dùng ReportEmbeddedResource nếu bạn nhúng file rdlc thẳng vào Project Assembly
                string fullResourcePath = $"{REPORT_NS}.{rdlcFileName}";
                reportViewerCommon.LocalReport.ReportEmbeddedResource = fullResourcePath;

                // Dự phòng trường hợp bạn không Build Embedded Resource thì dùng đường dẫn File vật lý:
                if (!TraCuuResourceTonTai(fullResourcePath))
                {
                    reportViewerCommon.LocalReport.ReportEmbeddedResource = null;
                    reportViewerCommon.LocalReport.ReportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rdlcFileName);
                }

                // 4. Bơm dữ liệu chuẩn từ Database vào Phôi báo cáo
                ReportDataSource rds = new ReportDataSource(dataSetNameInRDLC, dtData);
                reportViewerCommon.LocalReport.DataSources.Add(rds);

                // 5. Làm mới và hiển thị
                reportViewerCommon.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xảy ra lỗi khi kết xuất báo cáo:\n{ex.Message}", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CÁC HÀM TRUY VẤN DỮ LIỆU CHUẨN ĐỒNG BỘ SQL SERVER

        private DataTable LayDuLieuDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                // Sử dụng SqlParameter để truyền ngày tháng an toàn, không lo lỗi định dạng hệ thống
                string sql = @"SELECT CAST(NgayLap AS DATE) AS Ngay, 
                              COUNT(MaHoaDon) AS SoHoaDon, 
                              SUM(ThanhTien) AS DoanhThu 
                       FROM HoaDon 
                       WHERE NgayLap >= @TuNgay AND NgayLap <= @DenNgay
                       GROUP BY CAST(NgayLap AS DATE)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDuLieuTopSanPham(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string sql = @"SELECT TOP 10 sp.TenSanPham, 
                              SUM(ct.SoLuong) AS SoLuongDaBan, 
                              SUM(ct.ThanhTien) AS DoanhThuThuVe
                       FROM ChiTietHoaDon ct
                       JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                       JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                       WHERE hd.NgayLap >= @TuNgay AND hd.NgayLap <= @DenNgay
                       GROUP BY sp.TenSanPham
                       ORDER BY SoLuongDaBan DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDuLieuTonKho()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string sql = "SELECT MaSanPham, TenSanPham, SoLuongTon, DonGiaBan, DonViTinh FROM SanPham WHERE TrangThai = 1";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        private DataTable LayDuLieuDSHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string sql = "SELECT MaHoaDon, NgayLap, TongTien, GhiChu FROM HoaDon WHERE NgayLap BETWEEN @TuNgay AND @DenNgay";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private DataTable LayDuLieuKhachHang(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                // Lấy danh sách khách hàng và tổng chi tiêu thực tế từ bảng KhachHang trong DB của bạn
                string sql = "SELECT MaKhachHang, TenKhachHang, TongChiTieu FROM KhachHang ORDER BY TongChiTieu DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        private bool TraCuuResourceTonTai(string resourceName)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceInfo(resourceName) != null;
        }
        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainFormForManager frmManager = (MainFormForManager)Application.OpenForms["MainFormForManager"] ?? new MainFormForManager();
            frmManager.Show();
            this.Close();
        }
        // NÚT BẤM XEM LỊCH SỬ HOÁ ĐƠN
        private void btnLichSuHoaDon_Click(object sender, EventArgs e)
        {
            FrmLichSuBaoCao frm = new FrmLichSuBaoCao();
            frm.ShowDialog();
        }

        private void frmBaoCao_Load_1(object sender, EventArgs e)
        {

        }
    }
}