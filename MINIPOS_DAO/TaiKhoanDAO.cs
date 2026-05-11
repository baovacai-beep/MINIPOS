using System;
using System.Data;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhauMD5)
        {
            TaiKhoanDTO result = null;

            string sql = @"
                SELECT
                    tk.MaTaiKhoan,
                    tk.TenDangNhap,
                    tk.MaVaiTro,
                    vt.TenVaiTro,
                    tk.TrangThai,
                    tk.NgayTao,
                    tk.LanDangNhapCuoi,
                    nv.MaNhanVien,
                    nv.HoTen
                FROM TaiKhoan tk
                INNER JOIN VaiTro  vt ON tk.MaVaiTro   = vt.MaVaiTro
                LEFT  JOIN NhanVien nv ON nv.MaTaiKhoan = tk.MaTaiKhoan
                WHERE tk.TenDangNhap = @TenDangNhap
                  AND tk.MatKhau     = @MatKhau
                  AND tk.TrangThai   = 1";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau",     matKhauMD5);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = new TaiKhoanDTO
                        {
                            MaTaiKhoan       = (int)dr["MaTaiKhoan"],
                            TenDangNhap      = dr["TenDangNhap"].ToString(),
                            MaVaiTro         = (int)dr["MaVaiTro"],
                            TenVaiTro        = dr["TenVaiTro"].ToString(),
                            TrangThai        = (bool)dr["TrangThai"],
                            NgayTao          = (DateTime)dr["NgayTao"],
                            LanDangNhapCuoi  = dr["LanDangNhapCuoi"] == DBNull.Value
                                                   ? (DateTime?)null
                                                   : (DateTime)dr["LanDangNhapCuoi"],
                            MaNhanVien       = dr["MaNhanVien"] == DBNull.Value
                                                   ? 0
                                                   : (int)dr["MaNhanVien"],
                            HoTen            = dr["HoTen"] == DBNull.Value
                                                   ? string.Empty
                                                   : dr["HoTen"].ToString()
                        };
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Cập nhật cột LanDangNhapCuoi sau khi đăng nhập thành công.
        /// </summary>
        public void CapNhatLanDangNhapCuoi(int maTaiKhoan)
        {
            string sql = "UPDATE TaiKhoan SET LanDangNhapCuoi = GETDATE() WHERE MaTaiKhoan = @MaTaiKhoan";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
