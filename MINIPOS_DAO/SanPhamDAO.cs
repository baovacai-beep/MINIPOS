using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class SanPhamDAO
    {
        public DataTable GetAllProducts()
        {
            string query = "SELECT * FROM v_SanPham";

            SqlDataAdapter da = new SqlDataAdapter(query, SQLConnection.GetConnection());

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public SanPhamDTO GetProductById(int maSP)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT * FROM SanPham WHERE MaSanPham=@MaSP";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaSP", maSP);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    return new SanPhamDTO
                    {
                        MaSanPham = Convert.ToInt32(rd["MaSanPham"]),

                        TenSanPham = rd["TenSanPham"].ToString(),

                        MaLoai = Convert.ToInt32(rd["MaLoai"]),

                        DonGiaBan = Convert.ToDecimal(rd["DonGiaBan"]),

                        SoLuongTon = Convert.ToInt32(rd["SoLuongTon"]),

                        Barcode = rd["Barcode"].ToString(),

                        DonViTinh = rd["DonViTinh"].ToString(),

                        MoTa = rd["MoTa"].ToString()
                    };
                }

                return null;
            }
        }

        public bool UpdateSanPham(SanPhamDTO sp)
        {
            string query = @"UPDATE SanPham
            SET
                TenSanPham = @TenSanPham,
                MaLoai = @MaLoai,
                DonGiaBan = @DonGiaBan,
                SoLuongTon = @SoLuongTon,
                Barcode = @Barcode,
                DonViTinh = @DonViTinh,
                TrangThai = @TrangThai
            WHERE MaSanPham = @MaSanPham";

            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MaSanPham", sp.MaSanPham);
                cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);
                cmd.Parameters.AddWithValue("@MaLoai", sp.MaLoai);
                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                cmd.Parameters.AddWithValue("@Barcode", sp.Barcode);
                cmd.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);
                cmd.Parameters.AddWithValue("@TrangThai", sp.TrangThai);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertProduct(SanPhamDTO sp)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO SanPham
                (
                    TenSanPham,
                    MaLoai,
                    DonGiaBan,
                    SoLuongTon,
                    Barcode,
                    DonViTinh,
                    MoTa
                )
                VALUES
                (
                    @TenSanPham,
                    @MaLoai,
                    @DonGiaBan,
                    @SoLuongTon,
                    @Barcode,
                    @DonViTinh,
                    @MoTa
                )";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);

                cmd.Parameters.AddWithValue("@MaLoai", sp.MaLoai);

                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);

                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);

                cmd.Parameters.AddWithValue("@Barcode", sp.Barcode);

                cmd.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);

                cmd.Parameters.AddWithValue("@MoTa", sp.MoTa);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool XoaSanPham(int maSanPham)
        {
            string query = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham";

            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}