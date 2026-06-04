// Tập tin: BaoCaoBUS.cs trong Project MINIPOS_BUS
using System;
using System.Data;
using MINIPOS_DAO;

namespace MINIPOS_BUS
{
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAO _dao = new BaoCaoDAO();

        public bool LuuPhienBaoCao(string tieuDe, DateTime tuNgay, DateTime denNgay, decimal doanhThu, int soHD, string ghiChu, int maNV)
        {
            if (string.IsNullOrWhiteSpace(tieuDe)) return false;
            return _dao.LuuPhienBaoCao(tieuDe, tuNgay, denNgay, doanhThu, soHD, ghiChu, maNV);
        }

        public DataTable GetLichSuBaoCao(DateTime tuNgay, DateTime denNgay, string tuKhoa)
        {
            if (tuNgay.Date > denNgay.Date) throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
            return _dao.LocLichSuBaoCao(tuNgay, denNgay, tuKhoa);
        }

        public bool UpdateGhiChuBaoCao(int maBaoCao, string ghiChuMoi) => _dao.CapNhatGhiChuBaoCao(maBaoCao, ghiChuMoi);
        public bool XoaBaoCao(int maBaoCao) => _dao.XoaBaoCao(maBaoCao);
    }
}