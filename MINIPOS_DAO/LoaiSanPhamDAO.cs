using System.Data;

namespace MINIPOS_DAO
{
    public class LoaiSanPhamDAO
    {
        // Danh sách loại sản phẩm cho combo lọc
        public DataTable GetAll()
        {
            return SQLConnection.ExecuteQuery(
                "SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai");
        }
    }
}
