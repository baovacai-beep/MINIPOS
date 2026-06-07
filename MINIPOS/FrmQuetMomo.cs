using System;
using System.Drawing;
using System.IO;
using System.Net;        // <-- BẮT BUỘC để cấu hình ServicePointManager
using System.Net.Http;   // <-- BẮT BUỘC để dùng HttpClient bất đồng bộ
using System.Windows.Forms;

namespace MINIPOS
{
    public partial class FrmQuetMomo : Form
    {
        private decimal _soTien;
        private string _maHD;

        public FrmQuetMomo(decimal soTien, string maHD)
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

        private async void FrmQuetMomo_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Ép hệ thống sử dụng các giao thức bảo mật cao nhất
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                                                     | SecurityProtocolType.Tls11
                                                     | SecurityProtocolType.Tls;

                // 2. Đọc thông tin cấu hình MoMo thực tế từ file cấu hình hệ thống
                string sdtMomo = "0912345678"; // Giá trị mặc định phòng hờ
                string tenChuTaiKhoan = "QUAN LY";

                string pathConfig = Path.Combine(Application.StartupPath, "momo_config.txt");
                if (File.Exists(pathConfig))
                {
                    var lines = File.ReadAllLines(pathConfig);
                    if (lines.Length >= 2)
                    {
                        sdtMomo = lines[0].Trim();
                        tenChuTaiKhoan = lines[1].Trim();
                    }
                }

                // 3. HIỂN THỊ SỐ TIỀN VÀ MÃ GIAO DỊCH LÊN GIAO DIỆN CHỮ
                lblSoTien.Text = string.Format("{0:N0} VNĐ", _soTien);
                lblNoiDung.Text = "Nội dung: Thanh toan " + _maHD;

                // Đổi con trỏ chuột sang trạng thái chờ (Loading)
                Cursor = Cursors.WaitCursor;

                // 4. GIẢI PHÁP GỐC: Tự dựng chuỗi chuẩn VietQR (EMVCo) dành cho Ví MoMo
                long soTienChuyen = Convert.ToInt64(_soTien);
                string noiDungChuyen = "Thanh toan " + _maHD;

                // Định dạng mã kết nối Ví MoMo theo chuẩn Napas/VietQR toàn quốc
                string consumerInfo = $"0010A0000007270105MOMO202{sdtMomo.Length:D2}{sdtMomo}";

                string baseVietQR = "000201" +                          // Phiên bản định dạng QR
                                    "010212" +                          // Mã khởi tạo (Mã động)
                                    $"38{consumerInfo.Length:D2}{consumerInfo}" + // Thông tin nhà cung cấp MoMo
                                    "5303704" +                         // Mã quốc gia (704 - Việt Nam)
                                    $"54{soTienChuyen.ToString().Length:D2}{soTienChuyen}" + // Số tiền cần trả
                                    "5802VN" +                          // Mã tiền tệ
                                    $"59{tenChuTaiKhoan.Length:D2}{tenChuTaiKhoan}" + // Tên chủ tài khoản
                                    "6005Hanoi" +                       // Tỉnh thành mặc định
                                    $"62{("08" + noiDungChuyen.Length.ToString("D2") + noiDungChuyen).Length:D2}08{noiDungChuyen.Length:D2}{noiDungChuyen}"; // Nội dung giao dịch

                // Tính mã CRC16 bảo mật bắt buộc của chuẩn VietQR để App nhận diện
                ushort crc = 0xFFFF;
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(baseVietQR + "6304");
                for (int i = 0; i < bytes.Length; i++)
                {
                    crc ^= (ushort)(bytes[i] << 8);
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x8000) != 0) crc = (ushort)((crc << 1) ^ 0x1021);
                        else crc <<= 1;
                    }
                }
                // Chuỗi VietQR hoàn chỉnh mà MoMo bắt buộc phải đọc
                string chuoiVietQRChuan = baseVietQR + "6304" + crc.ToString("X4");

                // Gửi chuỗi chuẩn này cho qrserver.com vẽ ảnh hộ nhằm tránh bị lỗi kết nối mạng
                string urlThayThong = $"https://api.qrserver.com/v1/create-qr-code/?size=350x350&data={Uri.EscapeDataString(chuoiVietQRChuan)}";

                // 5. Tiến hành tải ảnh QR từ API thay thế
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    client.Timeout = TimeSpan.FromSeconds(15);

                    byte[] imageBytes = await client.GetByteArrayAsync(urlThayThong);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picQrMomo.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi tạo mã QR MoMo định dạng chuẩn.\n" +
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