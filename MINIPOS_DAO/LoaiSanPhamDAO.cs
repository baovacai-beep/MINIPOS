using System.Data;

namespace MINIPOS_DAO
{
    public class LoaiSanPhamDAO
    {
        // lay danh sach loai san pham cho combo loc
        public DataTable GetAll()
        {
            return SQLConnection.ExecuteQuery(
                "SELECT MaLoai, TenLoai FROM LoaiSanPham ORDER BY TenLoai");
        }
    }
}
