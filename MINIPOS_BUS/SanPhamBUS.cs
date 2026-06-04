using System.Data;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO dao = new SanPhamDAO();

        public DataTable GetAllProducts()
        {
            return dao.GetAllProducts();
        }

        public DataTable TimKiem(SanPhamFilterDTO f)
        {
            return dao.TimKiem(f);
        }

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
            return dao.InsertProduct(sp);
        }

        private SanPhamDAO sanPhamDAO = new SanPhamDAO();

        public bool UpdateSanPham(SanPhamDTO sp)
        {
            return sanPhamDAO.UpdateSanPham(sp);
        }
    }
}