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

        // lay tat ca khach hang
        public DataTable GetAll()
        {
            return _dao.GetAll();
        }

        // tim khach hang theo tu khoa
        public DataTable Search(string tuKhoa)
        {
            return _dao.Search(tuKhoa);
        }

        // them khach hang, kiem tra du lieu truoc khi them
        public bool Them(KhachHangDTO kh, out string loi)
        {
            loi = "";
            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
            {
                loi = "Tên khách hàng không được để trống.";
                return false;
            }
            if (!HopLeSDT(kh.SoDienThoai))
            {
                loi = "Số điện thoại phải gồm 9–11 chữ số.";
                return false;
            }
            try
            {
                return _dao.Insert(kh);
            }
            catch (Exception ex)
            {
                loi = ThongBaoLoi(ex);
                return false;
            }
        }

        // sua khach hang
        public bool Sua(KhachHangDTO kh, out string loi)
        {
            loi = "";
            if (kh.MaKhachHang <= 0)
            {
                loi = "Chưa chọn khách hàng.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.TenKhachHang))
            {
                loi = "Tên khách hàng không được để trống.";
                return false;
            }
            if (!HopLeSDT(kh.SoDienThoai))
            {
                loi = "Số điện thoại phải gồm 9–11 chữ số.";
                return false;
            }
            try
            {
                return _dao.Update(kh);
            }
            catch (Exception ex)
            {
                loi = ThongBaoLoi(ex);
                return false;
            }
        }

        // khoa hoac mo khoa khach hang
        public bool DatTrangThai(int maKH, bool active)
        {
            return _dao.SetTrangThai(maKH, active);
        }

        // kiem tra so dien thoai hop le (co the bo trong)
        private bool HopLeSDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                return true;
            return Regex.IsMatch(sdt.Trim(), @"^\d{9,11}$");
        }

        // tao thong bao loi cho de hieu
        private string ThongBaoLoi(Exception ex)
        {
            if (ex.Message.IndexOf("UNIQUE", StringComparison.OrdinalIgnoreCase) >= 0 ||
                ex.Message.IndexOf("duplicate", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Số điện thoại đã tồn tại cho khách hàng khác.";
            return "Lỗi: " + ex.Message;
        }
    }
}
