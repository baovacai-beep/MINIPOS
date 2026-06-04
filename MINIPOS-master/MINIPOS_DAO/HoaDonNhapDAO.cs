using System;
using System.Data;
using System.Data.SqlClient;

namespace MINIPOS_DAO
{
    public class HoaDonNhapDAO
    {
        public bool LuuTamHoaDon(int maNV, string ghiChu, DataTable dtItems)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlMaster = "INSERT INTO HoaDonNhap (MaNhanVien, TenGhiChu) VALUES (@MaNV, @GhiChu); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdMaster = new SqlCommand(sqlMaster, conn, trans);
                    cmdMaster.Parameters.AddWithValue("@MaNV", maNV);
                    cmdMaster.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu);

                    int maHDNhap = Convert.ToInt32(cmdMaster.ExecuteScalar());

                    string sqlDetail = "INSERT INTO ChiTietHoaDonNhap (MaHDNhap, MaSanPham, SoLuong) VALUES (@MaHDNhap, @MaSP, @SL);";
                    foreach (DataRow row in dtItems.Rows)
                    {
                        SqlCommand cmdDetail = new SqlCommand(sqlDetail, conn, trans);
                        cmdDetail.Parameters.AddWithValue("@MaHDNhap", maHDNhap);
                        cmdDetail.Parameters.AddWithValue("@MaSP", row["MaSanPham"]);
                        cmdDetail.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdDetail.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public DataTable GetDanhSachHDNhap()
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = @"SELECT h.MaHDNhap, h.NgayLuu, h.TenGhiChu, nv.HoTen AS TenNhanVien 
                                 FROM HoaDonNhap h 
                                 INNER JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien 
                                 ORDER BY h.NgayLuu DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetChiTietHDNhap(int maHDNhap)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = @"SELECT ct.MaSanPham, sp.TenSanPham, ct.SoLuong, sp.DonGiaBan 
                                 FROM ChiTietHoaDonNhap ct 
                                 INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham 
                                 WHERE ct.MaHDNhap = @MaHDNhap";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHDNhap", maHDNhap);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool XoaHDNhap(int maHDNhap)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = "DELETE FROM HoaDonNhap WHERE MaHDNhap = @MaHDNhap";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHDNhap", maHDNhap);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}