namespace MINIPOS_DTO
{
    public enum TrangThaiKhoFilter { TatCa = 0, ConHang = 1, SapHet = 2, HetHang = 3 }

    public class SanPhamFilterDTO
    {
        public string  TuKhoa { get; set; }                 // tên hoặc barcode
        public int?    MaLoai { get; set; }                 // null = tất cả loại
        public decimal? GiaMin { get; set; }
        public decimal? GiaMax { get; set; }
        public TrangThaiKhoFilter TonKho { get; set; } = TrangThaiKhoFilter.TatCa;
    }
}
