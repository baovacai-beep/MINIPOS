using System;

namespace MINIPOS_DTO
{
    public class KhachHangDTO
    {
        public int      MaKhachHang  { get; set; }
        public string   TenKhachHang { get; set; }
        public string   SoDienThoai  { get; set; }
        public string   DiaChi       { get; set; }
        public int      DiemTichLuy  { get; set; }
        public decimal  TongChiTieu  { get; set; }
        public int      MaHang       { get; set; }    // FK → HangThanhVien
        public string   TenHang      { get; set; }    // Thường / Bạc / Vàng
        public decimal  TyLeGiamGia  { get; set; }    // % giảm giá theo hạng
        public DateTime NgayDangKy   { get; set; }
        public bool     TrangThai    { get; set; }
    }
}
