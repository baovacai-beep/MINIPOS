// Tập tin: HoaDonNhapBUS.cs trong Project MINIPOS_BUS
using System.Data;
using MINIPOS_DAO;

namespace MINIPOS_BUS
{
    public class HoaDonNhapBUS
    {
        private readonly HoaDonNhapDAO _dao = new HoaDonNhapDAO();

        public bool LuuTamHoaDon(int maNV, string ghiChu, DataTable dtItems)
        {
            if (dtItems == null || dtItems.Rows.Count == 0) return false;
            return _dao.LuuTamHoaDon(maNV, ghiChu, dtItems);
        }
        public DataTable GetDanhSachHDNhap() => _dao.GetDanhSachHDNhap();
        public DataTable GetChiTietHDNhap(int maHDNhap) => _dao.GetChiTietHDNhap(maHDNhap);
        public bool XoaHDNhap(int maHDNhap) => _dao.XoaHDNhap(maHDNhap);
    }
}