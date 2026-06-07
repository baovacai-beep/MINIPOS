using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // <-- Thêm thư viện này để đọc/ghi file cấu hình MoMo
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MINIPOS
{
    public partial class FrmCaiDatChoQuanLy : Form
    {
        // Đường dẫn lưu file cấu hình MoMo trong thư mục cài đặt phần mềm
        private string pathConfig = Path.Combine(Application.StartupPath, "momo_config.txt");

        public FrmCaiDatChoQuanLy()
        {
            InitializeComponent();
            this.FormClosed += FrmCaiDatChoQuanLy_FormClosed;
        }

        private void FrmCaiDatChoQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // TỰ ĐỘNG LOAD THÔNG TIN KHI MỞ CÀI ĐẶT
        private void SettingsForManager_Load(object sender, EventArgs e)
        {
            var tk = FrmLogin.TaiKhoanDangNhap;

            txtMaNV.Text = "1";
            txtMaTK.Text = "1";
            txtTenNV.Text = "Lê Nguyễn Khánh Trình";
            txtVaiTro.Text = "Quản lý";
            txtGioiTinh.Text = "Nam";
            txtSDT.Text = "0912345678";
            txtNgaySinh.Text = "20/05/2004";

            if (tk?.LanDangNhapCuoi != null)
                lblTDLogin.Text = tk.LanDangNhapCuoi.Value.ToString("HH:mm:ss dd/MM/yyyy");

            // ═════════════════════════════════════════════════════════════
            // ĐỌC FILE CẤU HÌNH MOMO (BỔ SUNG MỚI)
            // ═════════════════════════════════════════════════════════════
            if (File.Exists(pathConfig))
            {
                var lines = File.ReadAllLines(pathConfig);
                if (lines.Length >= 2)
                {
                    txtMomoSDT.Text = lines[0].Trim();
                    txtMomoTen.Text = lines[1].Trim();
                }
            }
        }

        // ═════════════════════════════════════════════════════════════
        // NÚT LƯU CẤU HÌNH MOMO (BỔ SUNG MỚI - Hãy double click vào nút Lưu trên giao diện để tạo sự kiện này)
        // ═════════════════════════════════════════════════════════════
        private void btnLuuMomo_Click(object sender, EventArgs e)
        {
            try
            {
                string sdt = txtMomoSDT.Text.Trim();
                string ten = txtMomoTen.Text.Trim().ToUpper(); // Tự động viết hoa tên tài khoản

                if (string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Số điện thoại và Tên tài khoản MoMo!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ghi đè thông tin mới vào file txt để các form khác đọc lại
                File.WriteAllLines(pathConfig, new string[] { sdt, ten });

                MessageBox.Show("Đã cập nhật tài khoản nhận tiền MoMo của quản lý thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Các hàm chuyển Form giữ nguyên của bạn ---
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
            FrmKhachHang frm = new FrmKhachHang(this);
            frm.Show();
            this.Hide();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVienChoQuanLy frm = new FrmNhanVienChoQuanLy();
            frm.Show();
            this.Hide();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            FrmKhuyenMaiChoQuanLy frm = new FrmKhuyenMaiChoQuanLy();
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

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var frm = new FrmLogin();
                frm.Show();
                this.Hide();
            }
        }

        private void btnXemHDNhap_Click(object sender, EventArgs e)
        {
            FrmHoaDonNhapChoQuanLy frm = new FrmHoaDonNhapChoQuanLy();
            frm.Show();
            this.Hide();
        }

    }
}