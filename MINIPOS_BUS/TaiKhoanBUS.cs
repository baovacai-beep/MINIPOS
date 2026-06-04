using System;
using System.Security.Cryptography;
using System.Text;
using MINIPOS_DAO;
using MINIPOS_DTO;

namespace MINIPOS_BUS
{
    public class TaiKhoanBUS
    {
        private readonly TaiKhoanDAO _dao = new TaiKhoanDAO();

        public TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new ArgumentException("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Vui lòng nhập mật khẩu.");

            TaiKhoanDTO taiKhoan = _dao.DangNhap(tenDangNhap.Trim(), MaHoaMD5(matKhau.Trim()));

            if (taiKhoan == null)
                throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng.");

            _dao.CapNhatLanDangNhapCuoi(taiKhoan.MaTaiKhoan);

            return taiKhoan;
        }

        public void DoiMatKhau(int maTaiKhoan, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu) || string.IsNullOrWhiteSpace(matKhauMoi))
                throw new ArgumentException("Vui lòng nhập đầy đủ mật khẩu.");

            if (matKhauMoi.Trim().Length < 6)
                throw new Exception("Mật khẩu mới phải từ 6 ký tự trở lên.");

            string hashCu = _dao.LayMatKhauHash(maTaiKhoan);
            if (hashCu == null)
                throw new Exception("Không tìm thấy tài khoản.");

            if (MaHoaMD5(matKhauCu.Trim()) != hashCu)
                throw new Exception("Mật khẩu hiện tại không đúng.");

            _dao.CapNhatMatKhau(maTaiKhoan, MaHoaMD5(matKhauMoi.Trim()));
        }

        private static string MaHoaMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
