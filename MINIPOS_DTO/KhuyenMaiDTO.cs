using System;

namespace MINIPOS_DTO
{
    public class KhuyenMaiDTO
    {
        public int MaKhuyenMai { get; set; }
        public string Code { get; set; }
        public string TenKhuyenMai { get; set; }
        public string LoaiKhuyenMai { get; set; } // 'ToanBoHoaDon', 'NhomSanPham', 'SanPham'
        public int? MaLoai { get; set; } // FK LoaiSanPham(MaLoai)
        public string TenLoai { get; set; } // Join hiển thị
        public int? MaSanPham { get; set; } // FK SanPham(MaSanPham)
        public string TenSanPham { get; set; } // Join hiển thị
        public string LoaiGiamGia { get; set; } // 'PhanTram', 'TienMat'
        public decimal GiaTriGiam { get; set; }
        public decimal GiaTriGiaoDichToiThieu { get; set; }
        public decimal? GiamToiDa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int? SoLuong { get; set; }
        public int SoLuongDaDung { get; set; }
        public bool TrangThai { get; set; }
    }
}
