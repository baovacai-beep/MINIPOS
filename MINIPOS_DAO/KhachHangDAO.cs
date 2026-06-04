using System;
using System.Data;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class KhachHangDAO
    {
        // Danh sách toàn bộ khách hàng (kèm hạng) từ view
        public DataTable GetAll()
        {
            return SQLConnection.ExecuteQuery(
                "SELECT * FROM v_KhachHang ORDER BY TenKhachHang");
        }

        // Tìm theo tên hoặc số điện thoại
        public DataTable Search(string tuKhoa)
        {
            return SQLConnection.ExecuteQuery(
                "SELECT * FROM v_KhachHang WHERE TenKhachHang LIKE @kw OR SoDienThoai LIKE @kw ORDER BY TenKhachHang",
                new SqlParameter("@kw", "%" + (tuKhoa ?? "").Trim() + "%"));
        }

        // Thêm khách hàng mới. Điểm/hạng để DEFAULT (sp_ThanhToan tự cập nhật)
        public bool Insert(KhachHangDTO kh)
        {
            int n = SQLConnection.ExecuteNonQuery(
                "INSERT INTO KhachHang (TenKhachHang, SoDienThoai, DiaChi) VALUES (@ten, @sdt, @dc)",
                new SqlParameter("@ten", kh.TenKhachHang),
                new SqlParameter("@sdt", (object)kh.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@dc",  (object)kh.DiaChi      ?? DBNull.Value));
            return n > 0;
        }

        // Sửa thông tin cơ bản (không đụng điểm/hạng/chi tiêu)
        public bool Update(KhachHangDTO kh)
        {
            int n = SQLConnection.ExecuteNonQuery(
                "UPDATE KhachHang SET TenKhachHang=@ten, SoDienThoai=@sdt, DiaChi=@dc WHERE MaKhachHang=@id",
                new SqlParameter("@ten", kh.TenKhachHang),
                new SqlParameter("@sdt", (object)kh.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@dc",  (object)kh.DiaChi      ?? DBNull.Value),
                new SqlParameter("@id",  kh.MaKhachHang));
            return n > 0;
        }

        // Khóa / mở khóa khách hàng
        public bool SetTrangThai(int maKH, bool active)
        {
            int n = SQLConnection.ExecuteNonQuery(
                "UPDATE KhachHang SET TrangThai=@tt WHERE MaKhachHang=@id",
                new SqlParameter("@tt", active),
                new SqlParameter("@id", maKH));
            return n > 0;
        }
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
