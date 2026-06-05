using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MINIPOS_DAO; // Thư viện chứa lớp SQLConnection của hệ thống

namespace MINIPOS
{
    public partial class frmBaoCao : Form
    {
        // Khai báo đường dẫn Namespace chứa các file Resource RDLC của bạn
        // Lưu ý: Đảm bảo các file .rdlc đã được chỉnh thuộc tính Build Action = Embedded Resource
        private const string REPORT_NS = "MINIPOS.Reports";

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            // Nạp danh sách 5 loại báo cáo vào ComboBox khi mở Form
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Báo cáo Doanh thu");
            cboLoaiBaoCao.Items.Add("Báo cáo Top sản phẩm");
            cboLoaiBaoCao.Items.Add("Báo cáo Tồn kho");
            cboLoaiBaoCao.Items.Add("Báo cáo Danh sách hóa đơn");
            cboLoaiBaoCao.Items.Add("Báo cáo Khách hàng");
            cboLoaiBaoCao.SelectedIndex = 0; // Chọn mặc định loại đầu tiên

            // Đặt mặc định khoảng thời gian xem từ đầu tháng đến ngày hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            this.reportViewerCommon.RefreshReport();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Lấy đến cuối ngày được chọn

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                int loaiBaoCaoIdx = cboLoaiBaoCao.SelectedIndex;
                switch (loaiBaoCaoIdx)
                {
                    case 0: // Doanh thu
                        HienThiReport(REPORT_NS + ".rptDoanhThu.rdlc", "dsDoanhThu", LayDuLieuDoanhThu(tuNgay, denNgay));
                        break;
                    case 1: // Top sản phẩm
                        HienThiReport(REPORT_NS + ".rptTopSanPham.rdlc", "dsTopSanPham", LayDuLieuTopSanPham(tuNgay, denNgay));
                        break;
                    case 2: // Tồn kho
                        HienThiReport(REPORT_NS + ".rptTonKho.rdlc", "dsTonKho", LayDuLieuTonKho());
                        break;
                    case 3: // Danh sách hóa đơn
                        HienThiReport(REPORT_NS + ".rptDSHoaDon.rdlc", "dsDSHoaDon", LayDuLieuDSHoaDon(tuNgay, denNgay));
                        break;
                    case 4: // Khách hàng
                        HienThiReport(REPORT_NS + ".rptKhachHang.rdlc", "dsKhachHang", LayDuLieuKhachHang());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu báo cáo:\n" + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Hàm dùng chung để đẩy DataTable lên ReportViewer
        /// </summary>
        private void HienThiReport(string resourceName, string dataSetName, DataTable dt)
        {
            reportViewerCommon.Reset();
            reportViewerCommon.ProcessingMode = ProcessingMode.Local;
            reportViewerCommon.LocalReport.ReportEmbeddedResource = resourceName;
            reportViewerCommon.LocalReport.DataSources.Clear();
            reportViewerCommon.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, dt));
            reportViewerCommon.RefreshReport();
        }

        #region CÁC HÀM LẤY DỮ LIỆU TỪ DATABASE MINI POS

        private DataTable LayDuLieuDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT CAST(NgayLap AS DATE) AS Ngay, COUNT(MaHoaDon) AS SoHoaDon, SUM(ThanhTien) AS DoanhThu " +
                         "FROM HoaDon WHERE NgayLap BETWEEN @TuNgay AND @DenNgay AND TrangThai = N'Hoàn thành' " +
                         "GROUP BY CAST(NgayLap AS DATE) ORDER BY Ngay";
            return ExecQuery(sql, new SqlParameter("@TuNgay", tuNgay), new SqlParameter("@DenNgay", denNgay));
        }

        private DataTable LayDuLieuTopSanPham(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT TOP 10 sp.TenSanPham, SUM(ct.SoLuong) AS SoLuongDaBan, SUM(ct.ThanhTien) AS DoanhThuThuVe " +
                         "FROM ChiTietHoaDon ct INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham " +
                         "INNER JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon " +
                         "WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay AND hd.TrangThai = N'Hoàn thành' " +
                         "GROUP BY sp.TenSanPham ORDER BY SoLuongDaBan DESC";
            return ExecQuery(sql, new SqlParameter("@TuNgay", tuNgay), new SqlParameter("@DenNgay", denNgay));
        }

        private DataTable LayDuLieuTonKho()
        {
            // Lấy danh sách sản phẩm và số lượng tồn kho hiện hành
            string sql = "SELECT MaSanPham, TenSanPham, SoLuongTon, DonGiaBan, DonViTinh FROM SanPham WHERE TrangThai = 1";
            return ExecQuery(sql);
        }

        private DataTable LayDuLieuDSHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "SELECT MaHoaDon, NgayLap, TongTien, GhiChu, TrangThai FROM HoaDon " +
                         "WHERE NgayLap BETWEEN @TuNgay AND @DenNgay ORDER BY NgayLap DESC";
            return ExecQuery(sql, new SqlParameter("@TuNgay", tuNgay), new SqlParameter("@DenNgay", denNgay));
        }

        private DataTable LayDuLieuKhachHang()
        {
            string sql = "SELECT MaKhachHang, TenKhachHang, DienThoai, TongChiTieu FROM KhachHang";
            return ExecQuery(sql);
        }

        private DataTable ExecQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        #endregion

        // NÚT BẤM BACK VỀ FORM QUẢN LÝ
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Khởi tạo hoặc tìm lại MainForm của quản lý đang mở
            MainFormForManager frmManager = (MainFormForManager)Application.OpenForms["MainFormForManager"];
            if (frmManager != null)
            {
                frmManager.Show(); // Hiện lại form chính
            }
            else
            {
                frmManager = new MainFormForManager();
                frmManager.Show();
            }
            this.Close(); // Đóng hẳn form báo cáo hiện tại để giải phóng bộ nhớ
        }

        // Sự kiện phòng hờ trường hợp người dùng nhấn nút X đỏ góc Windows của Form Báo Cáo
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            MainFormForManager frmManager = (MainFormForManager)Application.OpenForms["MainFormForManager"];
            if (frmManager != null && !frmManager.Visible)
            {
                frmManager.Show();
            }
        }

        // NÚT BẤM XEM LỊCH SỬ HOÁ ĐƠN
        private void btnLichSuHoaDon_Click(object sender, EventArgs e)
        {
            FrmLichSuBaoCao frm = new FrmLichSuBaoCao();
            frm.ShowDialog();
        }
    }
}