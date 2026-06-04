using System;
using System.Data;
using System.Text.RegularExpressions;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAO _dao = new KhachHangDAO();

        /// <summary>
        /// Tra cứu khách hàng theo SĐT. Trả về null nếu không tìm thấy.
        /// </summary>
        public KhachHangDTO TimKiemTheoSDT(string soDienThoai)
        {
            if (string.IsNullOrWhiteSpace(soDienThoai))
                return null;
            return _dao.TimKiemTheoSDT(soDienThoai.Trim());
        }

        public DataTable GetAll() => _dao.GetAll();

        public DataTable Search(string tuKhoa) => _dao.Search(tuKhoa);

        public bool Them(KhachHangDTO kh, out string loi)
        {
            loi = "";
            if (string.IsNullOrWhiteSpace(kh.TenKhachHang)) { loi = "Tên khách hàng không được để trống."; return false; }
            if (!HopLeSDT(kh.SoDienThoai)) { loi = "Số điện thoại phải gồm 9–11 chữ số."; return false; }
            try { return _dao.Insert(kh); }
            catch (Exception ex) { loi = ThongBaoLoi(ex); return false; }
        }

        public bool Sua(KhachHangDTO kh, out string loi)
        {
            loi = "";
            if (kh.MaKhachHang <= 0) { loi = "Chưa chọn khách hàng."; return false; }
            if (string.IsNullOrWhiteSpace(kh.TenKhachHang)) { loi = "Tên khách hàng không được để trống."; return false; }
            if (!HopLeSDT(kh.SoDienThoai)) { loi = "Số điện thoại phải gồm 9–11 chữ số."; return false; }
            try { return _dao.Update(kh); }
            catch (Exception ex) { loi = ThongBaoLoi(ex); return false; }
        }

        public bool DatTrangThai(int maKH, bool active) => _dao.SetTrangThai(maKH, active);

        private static bool HopLeSDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return true; // SĐT có thể bỏ trống
            return Regex.IsMatch(sdt.Trim(), @"^\d{9,11}$");
        }

        private static string ThongBaoLoi(Exception ex)
        {
            if (ex.Message.IndexOf("UNIQUE", StringComparison.OrdinalIgnoreCase) >= 0 ||
                ex.Message.IndexOf("duplicate", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Số điện thoại đã tồn tại cho khách hàng khác.";
            return "Lỗi: " + ex.Message;
        }
    }
}
