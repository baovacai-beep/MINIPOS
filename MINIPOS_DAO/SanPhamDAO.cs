using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        // tao cau WHERE theo cac dieu kien loc, dung chung cho 2 ham tim kiem
        private string BuildWhere(SanPhamFilterDTO f, List<SqlParameter> ps)
        {
            StringBuilder sql = new StringBuilder(" WHERE TrangThai = 1");

            if (!string.IsNullOrWhiteSpace(f.TuKhoa))
            {
                sql.Append(" AND (TenSanPham LIKE @kw OR Barcode LIKE @kw)");
                ps.Add(new SqlParameter("@kw", "%" + f.TuKhoa.Trim() + "%"));
            }
            if (f.MaLoai.HasValue)
            {
                sql.Append(" AND MaLoai = @maLoai");
                ps.Add(new SqlParameter("@maLoai", f.MaLoai.Value));
            }
            if (f.GiaMin.HasValue && f.GiaMin.Value > 0)
            {
                sql.Append(" AND DonGiaBan >= @giaMin");
                ps.Add(new SqlParameter("@giaMin", f.GiaMin.Value));
            }
            if (f.GiaMax.HasValue && f.GiaMax.Value > 0)
            {
                sql.Append(" AND DonGiaBan <= @giaMax");
                ps.Add(new SqlParameter("@giaMax", f.GiaMax.Value));
            }

            // loc theo tinh trang ton kho
            if (f.TonKho == TrangThaiKhoFilter.ConHang)
                sql.Append(" AND SoLuongTon > 0");
            else if (f.TonKho == TrangThaiKhoFilter.SapHet)
                sql.Append(" AND SoLuongTon > 0 AND SoLuongTon <= SoLuongTonToiThieu");
            else if (f.TonKho == TrangThaiKhoFilter.HetHang)
                sql.Append(" AND SoLuongTon = 0");

            return sql.ToString();
        }

        // tim kiem nang cao cho form Kho (lay het cot cua v_SanPham)
        public DataTable TimKiem(SanPhamFilterDTO f)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            string sql = "SELECT * FROM v_SanPham" + BuildWhere(f, ps) + " ORDER BY TenSanPham";
            return SQLConnection.ExecuteQuery(sql, ps.ToArray());
        }

        // tim kiem nang cao cho form Ban hang (dat ten cot giong gio hang dung)
        public DataTable TimKiemBanHang(SanPhamFilterDTO f)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            string sql =
                "SELECT MaSanPham AS [Mã SP], TenSanPham AS [Tên SP], TenLoai AS [Loại SP], " +
                "DonGiaBan AS [Đơn giá], DonViTinh AS [Đơn vị], SoLuongTon AS [Tồn kho] " +
                "FROM v_SanPham" + BuildWhere(f, ps) + " ORDER BY TenSanPham";
            return SQLConnection.ExecuteQuery(sql, ps.ToArray());
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