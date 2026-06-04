using System;
using System.Data;
using System.Windows.Forms;
using MINIPOS_BUS;

namespace MINIPOS
{
    public partial class FrmHoaDonNhap : Form
    {
        private readonly HoaDonNhapBUS _bus = new HoaDonNhapBUS();
        public DataTable DataRestore { get; private set; }

        public FrmHoaDonNhap()
        {
            InitializeComponent();
            LoadMasterData();
        }

        private void LoadMasterData()
        {
            dgvMaster.DataSource = _bus.GetDanhSachHDNhap();
        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maHD = Convert.ToInt32(dgvMaster.Rows[e.RowIndex].Cells["MaHDNhap"].Value);
                dgvDetail.DataSource = _bus.GetChiTietHDNhap(maHD);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMaster.CurrentRow == null) return;
            int maHD = Convert.ToInt32(dgvMaster.CurrentRow.Cells["MaHDNhap"].Value);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa vĩnh viễn hóa đơn nháp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_bus.XoaHDNhap(maHD))
                {
                    LoadMasterData();
                    dgvDetail.DataSource = null;
                }
            }
        }

        private void btnSuDung_Click(object sender, EventArgs e)
        {
            if (dgvMaster.CurrentRow == null) return;
            int maHD = Convert.ToInt32(dgvMaster.CurrentRow.Cells["MaHDNhap"].Value);

            // Gán dữ liệu chi tiết hàng hóa trả về cho form chính xử lý
            DataRestore = _bus.GetChiTietHDNhap(maHD);

            // Hệ thống tự động xóa bỏ bản ghi tạm trong database để giải phóng phiên làm việc
            _bus.XoaHDNhap(maHD);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}