using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class HoaDonDAO
    {
        /// <summary>
        /// Gọi stored procedure sp_ThanhToan để tạo hóa đơn, lưu chi tiết,
        /// trừ tồn kho và cập nhật điểm khách hàng trong 1 transaction.
        /// Trả về MaHoaDon mới tạo. Ném exception nếu thất bại.
        /// </summary>
        public int ThanhToan(HoaDonDTO hd)
        {
            // Xây dựng JSON chi tiết hóa đơn theo đúng format sp_ThanhToan yêu cầu
            // [{"MaSanPham":1,"SoLuong":2,"DonGia":8000}, ...]
            var sb = new StringBuilder("[");
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                var ct = hd.ChiTiet[i];
                sb.Append($"{{\"MaSanPham\":{ct.MaSanPham},\"SoLuong\":{ct.SoLuong},\"DonGia\":{ct.DonGia}}}");
                if (i < hd.ChiTiet.Count - 1) sb.Append(",");
            }
            sb.Append("]");
            string chiTietJson = sb.ToString();

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_ThanhToan", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaNhanVien",          hd.MaNhanVien);
                cmd.Parameters.AddWithValue("@MaKhachHang",
                    hd.MaKhachHang.HasValue ? (object)hd.MaKhachHang.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@TongTien",            hd.TongTien);
                cmd.Parameters.AddWithValue("@TyLeGiamGia",         hd.TyLeGiamGia);
                cmd.Parameters.AddWithValue("@SoTienGiam",          hd.SoTienGiam);
                cmd.Parameters.AddWithValue("@ThanhTien",           hd.ThanhTien);
                cmd.Parameters.AddWithValue("@TienKhachDua",        hd.TienKhachDua);
                cmd.Parameters.AddWithValue("@TienThoi",            hd.TienThoi);
                cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hd.PhuongThucThanhToan);
                cmd.Parameters.AddWithValue("@GhiChu",
                    string.IsNullOrEmpty(hd.GhiChu) ? (object)DBNull.Value : hd.GhiChu);
                cmd.Parameters.AddWithValue("@ChiTietJSON",         chiTietJson);

                SqlParameter outParam = new SqlParameter("@MaHoaDonMoi", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int maHoaDonMoi = (int)outParam.Value;
                if (maHoaDonMoi <= 0)
                    throw new Exception("Thanh toán thất bại. Vui lòng thử lại.");

                return maHoaDonMoi;
            }
        }
    }
}
