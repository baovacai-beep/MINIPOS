using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class KhachHangDAO
    {
        /// <summary>
        /// Tìm khách hàng theo số điện thoại, kèm thông tin hạng thành viên.
        /// Trả về null nếu không tìm thấy hoặc tài khoản bị khóa.
        /// </summary>
        public KhachHangDTO TimKiemTheoSDT(string soDienThoai)
        {
            string sql = @"
                SELECT kh.MaKhachHang, kh.TenKhachHang, kh.SoDienThoai,
                       kh.DiaChi, kh.DiemTichLuy, kh.TongChiTieu,
                       kh.MaHang, htv.TenHang, htv.TyLeGiamGia,
                       kh.NgayDangKy, kh.TrangThai
                FROM KhachHang kh
                JOIN HangThanhVien htv ON kh.MaHang = htv.MaHang
                WHERE kh.SoDienThoai = @SDT
                  AND kh.TrangThai   = 1";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new KhachHangDTO
                        {
                            MaKhachHang  = (int)dr["MaKhachHang"],
                            TenKhachHang = dr["TenKhachHang"].ToString(),
                            SoDienThoai  = dr["SoDienThoai"].ToString(),
                            DiaChi       = dr["DiaChi"]?.ToString(),
                            DiemTichLuy  = (int)dr["DiemTichLuy"],
                            TongChiTieu  = (decimal)dr["TongChiTieu"],
                            MaHang       = (int)dr["MaHang"],
                            TenHang      = dr["TenHang"].ToString(),
                            TyLeGiamGia  = (decimal)dr["TyLeGiamGia"],
                            NgayDangKy   = (System.DateTime)dr["NgayDangKy"],
                            TrangThai    = (bool)dr["TrangThai"]
                        };
                    }
                    return null;
                }
            }
        }
    }
}
