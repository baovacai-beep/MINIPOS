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
    public partial class FrmCaiDatChoNhanVien : Form
    {
        public FrmCaiDatChoNhanVien()
        {
            InitializeComponent();

            this.FormClosed += FrmCaiDatChoNhanVien_FormClosed;
        }

        private void FrmCaiDatChoNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            FrmBanHangChoNhanVien frm = new FrmBanHangChoNhanVien();

            frm.Show();
            this.Hide();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            FrmKhoChoNhanVien frm = new FrmKhoChoNhanVien();

            frm.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang frm = new FrmKhachHang(this); // Truyền 'this' vào đây
            frm.Show();
            this.Hide();
        }

        private void btnXemHDNhap_Click(object sender, EventArgs e)
        {
            FrmHoaDonNhapChoNhanVien frm = new FrmHoaDonNhapChoNhanVien();
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
            var frm = new FrmCaiDatChoNhanVien();
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

        private void SettingsForStaff_Load(object sender, EventArgs e)
        {
            var tk = FrmLogin.TaiKhoanDangNhap;

            txtMaNV.Text = tk.MaNhanVien.ToString();
            txtMaTK.Text = tk.MaTaiKhoan.ToString();
            txtTenNV.Text = tk.HoTen;
            txtVaiTro.Text = "Nhân viên";
            txtGioiTinh.Text = tk.GioiTinh;
            txtSDT.Text = tk.SoDienThoai;
            txtNgaySinh.Text = tk.NgaySinh.ToString("dd/MM/yyyy");

            lblTDLogin.Text = tk.LanDangNhapCuoi.Value.ToString("HH:mm:ss dd/MM/yyyy");
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
    }
}
