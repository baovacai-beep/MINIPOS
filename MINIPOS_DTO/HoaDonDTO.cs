using System;
using System.Collections.Generic;

namespace MINIPOS_DTO
{
    public class ChiTietHoaDonDTO
    {
        public int     MaSanPham  { get; set; }
        public string  TenSanPham { get; set; }
        public decimal DonGia     { get; set; }
        public int     SoLuong    { get; set; }
        public decimal ThanhTien  => DonGia * SoLuong;
    }

    public class HoaDonDTO
    {
        public int      MaHoaDon            { get; set; }
        public DateTime NgayLap             { get; set; }
        public int      MaNhanVien          { get; set; }
        public int?     MaKhachHang         { get; set; }
        public decimal  TongTien            { get; set; }
        public decimal  TyLeGiamGia         { get; set; }
        public decimal  SoTienGiam          { get; set; }
        public decimal  ThanhTien           { get; set; }
        public decimal  TienKhachDua        { get; set; }
        public decimal  TienThoi            { get; set; }
        public string   PhuongThucThanhToan { get; set; } = "Tiền mặt";
        public string   GhiChu             { get; set; }
        public string   TrangThai           { get; set; } = "Hoàn thành";

        public List<ChiTietHoaDonDTO> ChiTiet { get; set; } = new List<ChiTietHoaDonDTO>();
    }
}
