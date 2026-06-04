using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tập tin: HoaDonNhapDTO.cs trong Project MINIPOS_DTO
namespace MINIPOS_DTO
{
    public class HoaDonNhapDTO
    {
        public int MaHDNhap { get; set; }
        public System.DateTime NgayLuu { get; set; }
        public int MaNhanVien { get; set; }
        public string TenGhiChu { get; set; }
        public string TenNhanVien { get; set; } // Thuộc tính bổ trợ phục vụ hiển thị lên GridView
    }
}
