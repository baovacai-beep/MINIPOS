using System;
using System.Collections.Generic;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAO _dao = new HoaDonDAO();

        /// <summary>
        /// Validate và thực hiện thanh toán. Trả về MaHoaDon mới.
        /// </summary>
        public int ThanhToan(HoaDonDTO hd)
        {
            if (hd == null)
                throw new ArgumentNullException("hd");

            if (hd.ChiTiet == null || hd.ChiTiet.Count == 0)
                throw new Exception("Giỏ hàng trống. Vui lòng thêm sản phẩm.");

            if (hd.MaNhanVien <= 0)
                throw new Exception("Thiếu thông tin nhân viên.");

            if (hd.TongTien <= 0)
                throw new Exception("Tổng tiền không hợp lệ.");

            if (hd.TienKhachDua < hd.ThanhTien)
                throw new Exception("Tiền khách đưa không đủ.");

            // Tính lại để đảm bảo nhất quán
            hd.SoTienGiam = Math.Round(hd.TongTien * hd.TyLeGiamGia / 100, 0);
            hd.ThanhTien  = hd.TongTien - hd.SoTienGiam;
            hd.TienThoi   = hd.TienKhachDua - hd.ThanhTien;

            return _dao.ThanhToan(hd);
        }
    }
}
