using FontAwesome.Sharp;
using MINIPOS_DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class MainFormForStaff : Form
    {
        public MainFormForStaff()
        {
            InitializeComponent();
            this.FormClosed += MainFormForStaff_FormClosed;
        }
        private void MainFormForStaff_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btnKho_Click(object sender, EventArgs e)
        {
            InventoryForStaff frm = new InventoryForStaff();

            frm.Show();

            this.Hide();
        }
        // hiển thị tất cả SP
        private void LoadSanPham()
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void MainFormForStaff_Load(object sender, EventArgs e)
        {
            dgvGioHang.Columns.Add("STT", "STT");
            dgvGioHang.Columns.Add("TenSP", "Tên sản phẩm");
            dgvGioHang.Columns.Add("DonGia", "Đơn giá");
            dgvGioHang.Columns.Add("SoLuong", "Số lượng");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");

            dgvGioHang.Columns["SoLuong"].ReadOnly = false;
            LoadSanPham();
        }
        //tim kiem SP theo ten
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenSP = txtTimKiem.Text.Trim();
            var listSP = $@"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenSanPham LIKE N'%{tenSP}%' ";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Nước uống & Đồ uống'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnBanhKeo_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Bánh kẹo & Snack'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnMi_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Mì & Thực phẩm ăn liền'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Sữa & Sản phẩm từ sữa'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnVPP_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Văn phòng phẩm'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnMyPham_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Mỹ phẩm & Chăm sóc cá nhân'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }

        private void btnGiaVi_Click(object sender, EventArgs e)
        {
            string listSP = @"
                        SELECT  
                            MaSanPham AS [Mã SP],
                            TenSanPham AS [Tên SP],
                            TenLoai AS [Loại SP],
                            DonGiaBan AS [Đơn giá],
                            DonViTinh AS [Đơn vị]
                        FROM v_SanPham
                        WHERE TenLoai = N'Gia vị & Thực phẩm khô'";
            dgvSanPham.DataSource = SQLConnection.ExecuteQuery(listSP);
        }
        //double click de them SP vao gio hang
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string tenSP = dgvSanPham.Rows[e.RowIndex].Cells["Tên SP"].Value.ToString();
            decimal dongia = Convert.ToDecimal(dgvSanPham.Rows[e.RowIndex].Cells["Đơn giá"].Value);
            //kiem tra them trung sp
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.Cells["TenSP"].Value != null && row.Cells["TenSP"].Value.ToString() == tenSP)
                {
                    MessageBox.Show($"Sản phẩm '{tenSP}' đã có trong giỏ hàng", "Thông báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            dgvGioHang.Rows.Add(dgvGioHang.Rows.Count + 1, tenSP, dongia, 1, dongia);
            TinhTongTien();
        }
        //tong tien gio hang
        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    tongTien +=
                        Convert.ToDecimal(row.Cells[4].Value);
                }
            }

            txtTongTien.Text =
                tongTien.ToString("N0");
        }
        //dieu chinh so luong hang trong gio
        private void dgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow row =
                    dgvGioHang.Rows[e.RowIndex];

                decimal donGia =
                    Convert.ToDecimal(row.Cells[2].Value);

                int soLuong =
                    Convert.ToInt32(row.Cells[3].Value);

                row.Cells[4].Value =
                    donGia * soLuong;

                TinhTongTien();
            }
        }
        //xoa hang trong gio
        private void btnXoaHang_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                dgvGioHang.Rows.Remove(dgvGioHang.CurrentRow);
                //cap nhat STT
                for (int i = 0; i < dgvGioHang.Rows.Count; i++)
                {
                    dgvGioHang.Rows[i].Cells["STT"].Value = i + 1;
                }

                TinhTongTien();
            }
        }
    }
}
