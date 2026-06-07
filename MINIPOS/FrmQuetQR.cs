using System;
using System.Drawing;
using System.Windows.Forms;

namespace MINIPOS
{
    public partial class FrmQuetQR : Form
    {
        private decimal _soTien;
        private string _maHD;

        public FrmQuetQR(decimal soTien, string maHD)
        {
            InitializeComponent();

            // Lưu lại thông tin truyền vào
            this._soTien = soTien;
            this._maHD = maHD;

            // Cấu hình PictureBox hiển thị co giãn vừa vặn
            picQrMomo.SizeMode = PictureBoxSizeMode.Zoom;

            // Đăng ký sự kiện Load cho Form (Để Form hiện lên xong mới tải QR ngầm)
            this.Load += FrmQuetMomo_Load;
        }

        private void FrmQuetMomo_Load(object sender, EventArgs e)
        {
            //Tk của doanh nghiệp
            string bankId = "970418";       
            string accountNo = "6169933979"; 
            string accountName = "MiniPOS";

            string qrUrl =
                $"https://img.vietqr.io/image/{bankId}-{accountNo}-compact2.png" +
                $"?amount={(long)_soTien}" +
                $"&addInfo={Uri.EscapeDataString(_maHD)}" +
                $"&accountName={Uri.EscapeDataString(accountName)}";
            try
            {
                // HIỂN THỊ SỐ TIỀN VÀ MÃ GIAO DỊCH LÊN GIAO DIỆN CHỮ
                lblSoTien.Text = string.Format("{0:N0} VNĐ", _soTien);
                lblNoiDung.Text = "Nội dung: Thanh toan " + _maHD;
                // Đổi con trỏ chuột sang trạng thái chờ (Loading)
                Cursor = Cursors.WaitCursor;
                //Tiến hành tải ảnh QR
                picQrMomo.Load(qrUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo mã QR thanh toán.\n" +
                                "Chi tiết kỹ thuật: " + ex.Message,
                                "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}