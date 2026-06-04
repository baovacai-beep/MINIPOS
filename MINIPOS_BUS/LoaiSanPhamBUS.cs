using System.Data;
using MINIPOS_DAO;

namespace MINIPOS_BUS
{
    public class LoaiSanPhamBUS
    {
        private readonly LoaiSanPhamDAO _dao = new LoaiSanPhamDAO();

        public DataTable GetAll()
        {
            return _dao.GetAll();
        }
    }
}
