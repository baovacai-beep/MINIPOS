using System;
using System.Data;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class SanPhamDAO
    {
        public DataTable GetAllProducts()
        {
            using (SqlConnection conn =
                SQLConnection.GetConnection())
            {
                conn.Open();

                string query =
                    "SELECT * FROM v_SanPham";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
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

                        Loai = Convert.ToInt32(rd["Loai"]),

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

        public bool UpdateProduct(SanPhamDTO sp)
        {
            using (SqlConnection conn = SQLConnection.GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE SanPham
                SET
                    TenSanPham=@TenSanPham,
                    Loai=@Loai,
                    DonGiaBan=@DonGiaBan,
                    SoLuongTon=@SoLuongTon,
                    Barcode=@Barcode,
                    DonViTinh=@DonViTinh,
                    MoTa=@MoTa
                WHERE MaSanPham=@MaSanPham";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);

                cmd.Parameters.AddWithValue("@Loai", sp.Loai);

                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);

                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);

                cmd.Parameters.AddWithValue("@Barcode", sp.Barcode);

                cmd.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);

                cmd.Parameters.AddWithValue("@MoTa", sp.MoTa);

                cmd.Parameters.AddWithValue("@MaSanPham", sp.MaSanPham);

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
                    Loai,
                    DonGiaBan,
                    SoLuongTon,
                    Barcode,
                    DonViTinh,
                    MoTa
                )
                VALUES
                (
                    @TenSanPham,
                    @Loai,
                    @DonGiaBan,
                    @SoLuongTon,
                    @Barcode,
                    @DonViTinh,
                    @MoTa
                )";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);

                cmd.Parameters.AddWithValue("@Loai", sp.Loai);

                cmd.Parameters.AddWithValue("@DonGiaBan", sp.DonGiaBan);

                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);

                cmd.Parameters.AddWithValue("@Barcode", sp.Barcode);

                cmd.Parameters.AddWithValue("@DonViTinh", sp.DonViTinh);

                cmd.Parameters.AddWithValue("@MoTa", sp.MoTa);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}