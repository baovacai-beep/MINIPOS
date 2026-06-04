using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MINIPOS_DAO;
using MINIPOS_BUS;
using MINIPOS_DTO;

namespace MINIPOS
{
    public partial class InventoryForStaff : Form
    {
        public InventoryForStaff()
        {
            InitializeComponent();
        }

        private void LoadSanPham(string where = "")
        {
            string sql = @"
                SELECT MaSanPham AS [Mã SP],
                       TenSanPham AS [Tên SP],
                       TenLoai AS [Loại SP],
                       DonGiaBan AS [Đơn giá],
                       DonViTinh AS [Đơn vị],
                       SoLuongTon AS [Tồn kho]
                FROM v_SanPham
                WHERE TrangThai = 1 "
                + (string.IsNullOrEmpty(where) ? "" : "AND " + where);
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(sql);
        }

        private void InventoryForStaff_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }
    }
}
