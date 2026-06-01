using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINIPOS_DTO
{
    public class SanPhamDTO
    {
        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int Loai { get; set; }

        public decimal DonGiaBan { get; set; }

        public int SoLuongTon { get; set; }

        public string Barcode { get; set; }

        public string DonViTinh { get; set; }

        public string MoTa { get; set; }

        public string HinhAnh { get; set; }
    }
}
