using System;
using System.Windows.Forms;
using MINIPOS_BUS;

namespace MINIPOS
{
    public partial class FrmLichSuBaoCao : Form
    {
        private readonly BaoCaoBUS _bus = new BaoCaoBUS();

        public FrmLichSuBaoCao()
        {
            InitializeComponent();
            dtpTuNgay.Value = DateTime.Now.AddDays(-30); // Mặc định hiển thị dữ liệu trong vòng 30 ngày qua
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvLichSu.DataSource = _bus.GetLichSuBaoCao(dtpTuNgay.Value, dtpDenNgay.Value, txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lọc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null) return;
            int maBC = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaBaoCao"].Value);

            string ghiChuMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập nội dung điều chỉnh ghi chú giải trình cho báo cáo này:", "Cập nhật thông tin báo cáo", "");
            if (string.IsNullOrWhiteSpace(ghiChuMoi)) return;

            if (_bus.UpdateGhiChuBaoCao(maBC, ghiChuMoi))
            {
                MessageBox.Show("Cập nhật ghi chú giải trình báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null) return;
            int maBC = Convert.ToInt32(dgvLichSu.CurrentRow.Cells["MaBaoCao"].Value);

            if (MessageBox.Show("Xác nhận xóa bỏ vĩnh viễn phiên bản ghi báo cáo này khỏi lịch sử hệ thống?", "Xác nhận hành động", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_bus.XoaBaoCao(maBC))
                {
                    LoadData();
                }
            }
        }
   


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    
    }
}
