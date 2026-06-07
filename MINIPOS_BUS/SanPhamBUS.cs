using System.Data;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO dao = new SanPhamDAO();

        private SanPhamDAO sanPhamDAO = new SanPhamDAO();

        public DataTable GetAllProducts()
        {
            return dao.GetAllProducts();
        }

        // tim kiem nang cao cho form Kho
        public DataTable TimKiem(SanPhamFilterDTO f)
        {
            return dao.TimKiem(f);
        }

        // tim kiem nang cao cho form Ban hang
        public DataTable TimKiemBanHang(SanPhamFilterDTO f)
        {
            return dao.TimKiemBanHang(f);
        }

        public SanPhamDTO GetProductById(int id)
        {
            return dao.GetProductById(id);
        }

        public bool InsertProduct(SanPhamDTO sp)
        {
            return sanPhamDAO.InsertProduct(sp);
        }

        public bool UpdateSanPham(SanPhamDTO sp)
        {
            return sanPhamDAO.UpdateSanPham(sp);
        }

        public bool DeleteProduct(int maSanPham)
        {
            return sanPhamDAO.DeleteProduct(maSanPham);
        }
    }
}