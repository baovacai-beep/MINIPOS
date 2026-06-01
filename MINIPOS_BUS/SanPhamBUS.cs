using System.Data;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO dao =
            new SanPhamDAO();

        public DataTable GetAllProducts()
        {
            return dao.GetAllProducts();
        }

        public SanPhamDTO GetProductById(int id)
        {
            return dao.GetProductById(id);
        }

        public bool InsertProduct(SanPhamDTO sp)
        {
            return dao.InsertProduct(sp);
        }

        public bool UpdateProduct(SanPhamDTO sp)
        {
            return dao.UpdateProduct(sp);
        }
    }
}