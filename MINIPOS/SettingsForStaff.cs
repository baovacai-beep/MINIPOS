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
    public partial class SettingsForStaff : Form
    {
        public SettingsForStaff()
        {
            InitializeComponent();
        }

        private void SettingsForStaff_Load(object sender, EventArgs e)
        {
            var tk = Login.TaiKhoanDangNhap;

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
                var frm = new Login();
                frm.Show();
                this.Hide();
            }
        }
    }
}
