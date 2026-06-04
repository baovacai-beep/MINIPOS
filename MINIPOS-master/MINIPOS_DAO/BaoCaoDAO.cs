using System;
using System.Data;
using System.Data.SqlClient;

namespace MINIPOS_DAO
{
    public class BaoCaoDAO
    {
        public bool LuuPhienBaoCao(string tieuDe, DateTime tuNgay, DateTime denNgay, decimal doanhThu, int soHD, string ghiChu, int maNV)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = @"INSERT INTO BaoCao (TieuDe, TuNgay, DenNgay, TongDoanhThu, SoHoaDon, GhiChu, MaNhanVien) 
                                 VALUES (@TieuDe, @TuNgay, @DenNgay, @DoanhThu, @SoHD, @GhiChu, @MaNV)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                cmd.Parameters.AddWithValue("@DoanhThu", doanhThu);
                cmd.Parameters.AddWithValue("@SoHD", soHD);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable LocLichSuBaoCao(DateTime tuNgay, DateTime denNgay, string tuKhoa)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = @"SELECT b.*, nv.HoTen AS TenNhanVien 
                                 FROM BaoCao b 
                                 INNER JOIN NhanVien nv ON b.MaNhanVien = nv.MaNhanVien 
                                 WHERE CAST(b.NgayTao AS DATE) BETWEEN @TuNgay AND @DenNgay 
                                   AND (b.TieuDe LIKE @TuKhoa OR b.GhiChu LIKE @TuKhoa)
                                 ORDER BY b.NgayTao DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay.Date);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool CapNhatGhiChuBaoCao(int maBaoCao, string ghiChuMoi)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = "UPDATE BaoCao SET GhiChu = @GhiChu WHERE MaBaoCao = @MaBaoCao";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChuMoi);
                cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaBaoCao(int maBaoCao)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                string query = "DELETE FROM BaoCao WHERE MaBaoCao = @MaBaoCao";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}