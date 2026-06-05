using System;
using System.Data;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class KhachHangDAO
    {
        // lay danh sach tat ca khach hang (kem hang thanh vien)
        public DataTable GetAll()
        {
            string sql = @"
                SELECT kh.MaKhachHang, kh.TenKhachHang, kh.SoDienThoai, kh.DiaChi,
                       kh.DiemTichLuy, kh.TongChiTieu, kh.MaHang, htv.TenHang,
                       htv.TyLeGiamGia, kh.NgayDangKy, kh.TrangThai
                FROM KhachHang kh
                JOIN HangThanhVien htv ON kh.MaHang = htv.MaHang
                ORDER BY kh.TenKhachHang";
            return SQLConnection.ExecuteQuery(sql);
        }

        // tim khach hang theo ten hoac so dien thoai
        public DataTable Search(string tuKhoa)
        {
            string sql = @"
                SELECT kh.MaKhachHang, kh.TenKhachHang, kh.SoDienThoai, kh.DiaChi,
                       kh.DiemTichLuy, kh.TongChiTieu, kh.MaHang, htv.TenHang,
                       htv.TyLeGiamGia, kh.NgayDangKy, kh.TrangThai
                FROM KhachHang kh
                JOIN HangThanhVien htv ON kh.MaHang = htv.MaHang
                WHERE kh.TenKhachHang LIKE @kw OR kh.SoDienThoai LIKE @kw
                ORDER BY kh.TenKhachHang";
            return SQLConnection.ExecuteQuery(sql,
                new SqlParameter("@kw", "%" + (tuKhoa ?? "").Trim() + "%"));
        }

        // them khach hang moi (diem va hang de mac dinh)
        public bool Insert(KhachHangDTO kh)
        {
            int n = SQLConnection.ExecuteNonQuery(
                "INSERT INTO KhachHang (TenKhachHang, SoDienThoai, DiaChi) VALUES (@ten, @sdt, @dc)",
                new SqlParameter("@ten", kh.TenKhachHang),
                new SqlParameter("@sdt", (object)kh.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@dc", (object)kh.DiaChi ?? DBNull.Value));
            return n > 0;
        }

        // sua thong tin co ban cua khach hang
        public bool Update(KhachHangDTO kh)
        {
            int n = SQLConnection.ExecuteNonQuery(
                "UPDATE KhachHang SET TenKhachHang=@ten, SoDienThoai=@sdt, DiaChi=@dc WHERE MaKhachHang=@id",
                new SqlParameter("@ten", kh.TenKhachHang),
                new SqlParameter("@sdt", (object)kh.SoDienThoai ?? DBNull.Value),
                new SqlParameter("@dc", (object)kh.DiaChi ?? DBNull.Value),
                new SqlParameter("@id", kh.MaKhachHang));
            return n > 0;
        }

        // khoa hoac mo khoa khach hang
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
