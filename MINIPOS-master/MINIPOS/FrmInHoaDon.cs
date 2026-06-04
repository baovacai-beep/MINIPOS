using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms; // Khai báo thư viện ReportViewer

namespace MINIPOS
{
    public partial class FrmInHoaDon : Form
    {
        public FrmInHoaDon(DataTable dtMaster, DataTable dtDetail)
        {
            InitializeComponent();

            try
            {
                // 1. Làm sạch các nguồn dữ liệu cũ của ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear();

                // 2. Chỉ định ĐÚNG tên file phôi thực tế của bạn là rptHoaDon.rdlc
                string reportName = "rptHoaDon.rdlc";

                // Tự động quét tìm file phôi trong thư mục Debug hoặc thư mục gốc của Project
                string pathInDebug = AppDomain.CurrentDomain.BaseDirectory + reportName;
                string pathInProject = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", reportName);

                if (System.IO.File.Exists(pathInDebug))
                {
                    this.reportViewer1.LocalReport.ReportPath = pathInDebug;
                }
                else if (System.IO.File.Exists(pathInProject))
                {
                    this.reportViewer1.LocalReport.ReportPath = pathInProject;
                }
                else
                {
                    throw new System.IO.FileNotFoundException($"Không tìm thấy file phôi {reportName}!");
                }

                // 3. Nạp dữ liệu vào các DataSet (Đã đồng bộ chính xác theo tên DataSet1 và DataSet2 trong rptHoaDon.rdlc)
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dtMaster));
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dtDetail));

                // 4. Làm mới và hiển thị báo cáo lên màn hình
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thiết lập Report:\n" + ex.Message, "Lỗi Hệ Thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}