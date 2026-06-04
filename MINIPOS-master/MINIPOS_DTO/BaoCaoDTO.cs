using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tập tin: BaoCaoDTO.cs trong Project MINIPOS_DTO
namespace MINIPOS_DTO
{
    public class BaoCaoDTO
    {
        public int MaBaoCao { get; set; }
        public string TieuDe { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime TuNgay { get; set; }
        public System.DateTime DenNgay { get; set; }
        public decimal TongDoanhThu { get; set; }
        public int SoHoaDon { get; set; }
        public string GhiChu { get; set; }
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; } // Tên người thực hiện kết xuất báo cáo
    }
}
