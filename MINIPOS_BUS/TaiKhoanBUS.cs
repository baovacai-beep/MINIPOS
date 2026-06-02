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
            // ── 1. Validate đầu vào ────────────────────────────────────
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                throw new ArgumentException("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Vui lòng nhập mật khẩu.");

            // ── 2. Mã hóa mật khẩu MD5 để so khớp với cơ sở dữ liệu ─────────
            string matKhauMD5 = MaHoaMD5(matKhau.Trim());

            // ── 3. Gọi DAO xác thực ───────────────────────────────────
            TaiKhoanDTO taiKhoan = _dao.DangNhap(tenDangNhap.Trim(), matKhauMD5);

            if (taiKhoan == null)
                throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng.");

            // ── 4. Cập nhật thời gian đăng nhập cuối ─────────────────
            _dao.CapNhatLanDangNhapCuoi(taiKhoan.MaTaiKhoan);

            return taiKhoan;
        }

        private string MaHoaMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
