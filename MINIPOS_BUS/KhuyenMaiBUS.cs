using System;
using System.Collections.Generic;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class KhuyenMaiBUS
    {
        private readonly KhuyenMaiDAO _dao = new KhuyenMaiDAO();

        public List<KhuyenMaiDTO> GetAll()
        {
            return _dao.GetAll();
        }

        public bool Insert(KhuyenMaiDTO km)
        {
            if (km == null || string.IsNullOrWhiteSpace(km.Code))
                return false;
            return _dao.Insert(km);
        }

        public bool Update(KhuyenMaiDTO km)
        {
            if (km == null || km.MaKhuyenMai <= 0 || string.IsNullOrWhiteSpace(km.Code))
                return false;
            return _dao.Update(km);
        }

        public bool Delete(int maKM)
        {
            if (maKM <= 0)
                return false;
            return _dao.Delete(maKM);
        }

        public bool TangSoLuongDaDung(int id)
        {
            if (id <= 0) return false;
            return _dao.TangSoLuongDaDung(id);
        }

        public KhuyenMaiDTO ValidateVoucher(string code, decimal tongTien, List<ChiTietHoaDonDTO> gioHang, out string message)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                message = "Vui lòng nhập mã giảm giá.";
                return null;
            }

            KhuyenMaiDTO km = _dao.GetByCode(code.Trim());
            if (km == null)
            {
                message = "Mã giảm giá không tồn tại hoặc đã bị ngừng áp dụng.";
                return null;
            }

            if (!km.TrangThai)
            {
                message = "Mã giảm giá hiện không hoạt động.";
                return null;
            }

            DateTime now = DateTime.Now;
            if (now < km.NgayBatDau)
            {
                message = $"Mã giảm giá chưa đến thời gian áp dụng (Bắt đầu từ: {km.NgayBatDau:dd/MM/yyyy HH:mm}).";
                return null;
            }

            if (now > km.NgayKetThuc)
            {
                message = "Mã giảm giá đã hết hạn sử dụng.";
                return null;
            }

            if (km.SoLuong.HasValue && km.SoLuongDaDung >= km.SoLuong.Value)
            {
                message = "Mã giảm giá đã hết lượt sử dụng.";
                return null;
            }

            if (tongTien < km.GiaTriGiaoDichToiThieu)
            {
                message = $"Đơn hàng chưa đạt giá trị tối thiểu để áp dụng mã này (Tối thiểu: {km.GiaTriGiaoDichToiThieu:N0} đ).";
                return null;
            }

            // Kiểm tra theo loại khuyến mãi
            if (km.LoaiKhuyenMai == "NhomSanPham")
            {
                bool coSPThuocNhom = false;
                foreach (var item in gioHang)
                {
                    if (KiemTraSanPhamThuocLoai(item.MaSanPham, km.MaLoai.GetValueOrDefault()))
                    {
                        coSPThuocNhom = true;
                        break;
                    }
                }

                if (!coSPThuocNhom)
                {
                    message = "Đơn hàng không chứa sản phẩm nào thuộc nhóm được áp dụng khuyến mãi.";
                    return null;
                }
            }
            else if (km.LoaiKhuyenMai == "SanPham")
            {
                bool coSP = false;
                foreach (var item in gioHang)
                {
                    if (item.MaSanPham == km.MaSanPham.GetValueOrDefault())
                    {
                        coSP = true;
                        break;
                    }
                }

                if (!coSP)
                {
                    message = $"Đơn hàng không chứa sản phẩm được áp dụng khuyến mãi (Yêu cầu có sản phẩm mã: {km.MaSanPham}).";
                    return null;
                }
            }

            message = "Áp dụng mã giảm giá thành công!";
            return km;
        }

        public decimal TinhTienGiam(KhuyenMaiDTO km, decimal tongTien, List<ChiTietHoaDonDTO> gioHang)
        {
            if (km == null) return 0;

            decimal soTienGiam = 0;

            if (km.LoaiKhuyenMai == "ToanBoHoaDon")
            {
                if (km.LoaiGiamGia == "PhanTram")
                {
                    soTienGiam = tongTien * km.GiaTriGiam / 100;
                    if (km.GiamToiDa.HasValue && soTienGiam > km.GiamToiDa.Value)
                    {
                        soTienGiam = km.GiamToiDa.Value;
                    }
                }
                else if (km.LoaiGiamGia == "TienMat")
                {
                    soTienGiam = km.GiaTriGiam;
                }
            }
            else if (km.LoaiKhuyenMai == "NhomSanPham")
            {
                decimal tongTienGiamNhom = 0;
                foreach (var item in gioHang)
                {
                    if (KiemTraSanPhamThuocLoai(item.MaSanPham, km.MaLoai.GetValueOrDefault()))
                    {
                        decimal giamDongSP = 0;
                        if (km.LoaiGiamGia == "PhanTram")
                        {
                            giamDongSP = item.SoLuong * item.DonGia * km.GiaTriGiam / 100;
                        }
                        else if (km.LoaiGiamGia == "TienMat")
                        {
                            giamDongSP = item.SoLuong * km.GiaTriGiam;
                        }
                        tongTienGiamNhom += giamDongSP;
                    }
                }
                soTienGiam = tongTienGiamNhom;
                if (km.GiamToiDa.HasValue && soTienGiam > km.GiamToiDa.Value)
                {
                    soTienGiam = km.GiamToiDa.Value;
                }
            }
            else if (km.LoaiKhuyenMai == "SanPham")
            {
                foreach (var item in gioHang)
                {
                    if (item.MaSanPham == km.MaSanPham.GetValueOrDefault())
                    {
                        if (km.LoaiGiamGia == "PhanTram")
                        {
                            soTienGiam = item.SoLuong * item.DonGia * km.GiaTriGiam / 100;
                        }
                        else if (km.LoaiGiamGia == "TienMat")
                        {
                            soTienGiam = item.SoLuong * km.GiaTriGiam;
                        }
                        break;
                    }
                }
                if (km.GiamToiDa.HasValue && soTienGiam > km.GiamToiDa.Value)
                {
                    soTienGiam = km.GiamToiDa.Value;
                }
            }

            if (soTienGiam > tongTien)
            {
                soTienGiam = tongTien;
            }

            return Math.Round(soTienGiam, 0);
        }

        private bool KiemTraSanPhamThuocLoai(int maSanPham, int maLoai)
        {
            string sql = "SELECT COUNT(1) FROM SanPham WHERE MaSanPham = @MaSP AND MaLoai = @MaLoai";
            System.Data.DataTable dt = SQLConnection.ExecuteQuery(
                sql.Replace("@MaSP", maSanPham.ToString()).Replace("@MaLoai", maLoai.ToString())
            );
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }
    }
}
