using System;
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
    }
}
