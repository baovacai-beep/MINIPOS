using System;

namespace MINIPOS_DTO
{
    public class TaiKhoanDTO
    {
        public int    MaTaiKhoan      { get; set; }
        public string TenDangNhap     { get; set; }
        public string MatKhau         { get; set; }   // MD5 hash
        public int    MaVaiTro        { get; set; }
        public string TenVaiTro       { get; set; }   // 'Admin' | 'QuanLy' | 'NhanVien'
        public bool   TrangThai       { get; set; }   // true = hoạt động
        public DateTime NgayTao       { get; set; }
        public DateTime? LanDangNhapCuoi { get; set; }

        // Thông tin nhân viên tương ứng (JOIN từ bảng NhanVien)
        public int    MaNhanVien      { get; set; }
        public string HoTen           { get; set; }
    }
}
