using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MINIPOS_DTO;

namespace MINIPOS_DAO
{
    public class KhuyenMaiDAO
    {
        public List<KhuyenMaiDTO> GetAll()
        {
            var list = new List<KhuyenMaiDTO>();
            string sql = @"
                SELECT km.*, lsp.TenLoai, sp.TenSanPham 
                FROM KhuyenMai km
                LEFT JOIN LoaiSanPham lsp ON km.MaLoai = lsp.MaLoai
                LEFT JOIN SanPham sp ON km.MaSanPham = sp.MaSanPham";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(MapFromReader(dr));
                    }
                }
            }
            return list;
        }

        public KhuyenMaiDTO GetByCode(string code)
        {
            string sql = @"
                SELECT km.*, lsp.TenLoai, sp.TenSanPham 
                FROM KhuyenMai km
                LEFT JOIN LoaiSanPham lsp ON km.MaLoai = lsp.MaLoai
                LEFT JOIN SanPham sp ON km.MaSanPham = sp.MaSanPham
                WHERE km.Code = @Code AND km.TrangThai = 1";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Code", code.Trim());
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return MapFromReader(dr);
                    }
                }
            }
            return null;
        }

        public bool Insert(KhuyenMaiDTO km)
        {
            string sql = @"
                INSERT INTO KhuyenMai (
                    Code, TenKhuyenMai, LoaiKhuyenMai, MaLoai, MaSanPham, 
                    LoaiGiamGia, GiaTriGiam, GiaTriGiaoDichToiThieu, GiamToiDa, 
                    NgayBatDau, NgayKetThuc, SoLuong, SoLuongDaDung, TrangThai
                ) VALUES (
                    @Code, @TenKhuyenMai, @LoaiKhuyenMai, @MaLoai, @MaSanPham, 
                    @LoaiGiamGia, @GiaTriGiam, @GiaTriGiaoDichToiThieu, @GiamToiDa, 
                    @NgayBatDau, @NgayKetThuc, @SoLuong, 0, @TrangThai
                )";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                AddParameters(cmd, km);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(KhuyenMaiDTO km)
        {
            string sql = @"
                UPDATE KhuyenMai SET 
                    Code = @Code, 
                    TenKhuyenMai = @TenKhuyenMai, 
                    LoaiKhuyenMai = @LoaiKhuyenMai, 
                    MaLoai = @MaLoai, 
                    MaSanPham = @MaSanPham, 
                    LoaiGiamGia = @LoaiGiamGia, 
                    GiaTriGiam = @GiaTriGiam, 
                    GiaTriGiaoDichToiThieu = @GiaTriGiaoDichToiThieu, 
                    GiamToiDa = @GiamToiDa, 
                    NgayBatDau = @NgayBatDau, 
                    NgayKetThuc = @NgayKetThuc, 
                    SoLuong = @SoLuong, 
                    TrangThai = @TrangThai
                WHERE MaKhuyenMai = @MaKhuyenMai";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhuyenMai", km.MaKhuyenMai);
                AddParameters(cmd, km);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int maKM)
        {
            // Soft delete
            string sql = "UPDATE KhuyenMai SET TrangThai = 0 WHERE MaKhuyenMai = @MaKhuyenMai";

            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhuyenMai", maKM);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool TangSoLuongDaDung(int id)
        {
            string sql = "UPDATE KhuyenMai SET SoLuongDaDung = SoLuongDaDung + 1 WHERE MaKhuyenMai = @ID";
            using (SqlConnection conn = SQLConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private KhuyenMaiDTO MapFromReader(SqlDataReader dr)
        {
            return new KhuyenMaiDTO
            {
                MaKhuyenMai = (int)dr["MaKhuyenMai"],
                Code = dr["Code"].ToString(),
                TenKhuyenMai = dr["TenKhuyenMai"].ToString(),
                LoaiKhuyenMai = dr["LoaiKhuyenMai"].ToString(),
                MaLoai = dr["MaLoai"] != DBNull.Value ? (int?)dr["MaLoai"] : null,
                TenLoai = dr.TableContainsColumn("TenLoai") && dr["TenLoai"] != DBNull.Value ? dr["TenLoai"].ToString() : null,
                MaSanPham = dr["MaSanPham"] != DBNull.Value ? (int?)dr["MaSanPham"] : null,
                TenSanPham = dr.TableContainsColumn("TenSanPham") && dr["TenSanPham"] != DBNull.Value ? dr["TenSanPham"].ToString() : null,
                LoaiGiamGia = dr["LoaiGiamGia"].ToString(),
                GiaTriGiam = (decimal)dr["GiaTriGiam"],
                GiaTriGiaoDichToiThieu = (decimal)dr["GiaTriGiaoDichToiThieu"],
                GiamToiDa = dr["GiamToiDa"] != DBNull.Value ? (decimal?)dr["GiamToiDa"] : null,
                NgayBatDau = (DateTime)dr["NgayBatDau"],
                NgayKetThuc = (DateTime)dr["NgayKetThuc"],
                SoLuong = dr["SoLuong"] != DBNull.Value ? (int?)dr["SoLuong"] : null,
                SoLuongDaDung = (int)dr["SoLuongDaDung"],
                TrangThai = (bool)dr["TrangThai"]
            };
        }

        private void AddParameters(SqlCommand cmd, KhuyenMaiDTO km)
        {
            cmd.Parameters.AddWithValue("@Code", km.Code.Trim());
            cmd.Parameters.AddWithValue("@TenKhuyenMai", km.TenKhuyenMai);
            cmd.Parameters.AddWithValue("@LoaiKhuyenMai", km.LoaiKhuyenMai);
            cmd.Parameters.AddWithValue("@MaLoai", km.MaLoai.HasValue ? (object)km.MaLoai.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@MaSanPham", km.MaSanPham.HasValue ? (object)km.MaSanPham.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@LoaiGiamGia", km.LoaiGiamGia);
            cmd.Parameters.AddWithValue("@GiaTriGiam", km.GiaTriGiam);
            cmd.Parameters.AddWithValue("@GiaTriGiaoDichToiThieu", km.GiaTriGiaoDichToiThieu);
            cmd.Parameters.AddWithValue("@GiamToiDa", km.GiamToiDa.HasValue ? (object)km.GiamToiDa.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@NgayBatDau", km.NgayBatDau);
            cmd.Parameters.AddWithValue("@NgayKetThuc", km.NgayKetThuc);
            cmd.Parameters.AddWithValue("@SoLuong", km.SoLuong.HasValue ? (object)km.SoLuong.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", km.TrangThai);
        }
    }

    public static class SqlReaderExtensions
    {
        public static bool TableContainsColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
