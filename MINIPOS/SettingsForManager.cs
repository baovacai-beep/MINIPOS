using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MINIPOS
{
    public partial class SettingsForManager : Form
    {
        public SettingsForManager()
        {
            InitializeComponent();
        }

        private void SettingsForManager_Load(object sender, EventArgs e)
        {
            var tk = Login.TaiKhoanDangNhap;

            txtMaNV.Text = "1";
            txtMaTK.Text = "1";
            txtTenNV.Text = "Lê Nguyễn Khánh Trình";
            txtVaiTro.Text = "Quản lý";
            txtGioiTinh.Text = "Nam";
            txtSDT.Text = "0912345678";
            txtNgaySinh.Text = "20/05/2004";

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
