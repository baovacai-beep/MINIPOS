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

            // ── 2. Băm mật khẩu MD5 ───────────────────────────────────
            string matKhauMD5 = MaHoaMD5(matKhau.Trim());

            // ── 3. Gọi DAO xác thực ───────────────────────────────────
            TaiKhoanDTO taiKhoan = _dao.DangNhap(tenDangNhap.Trim(), matKhauMD5);

            if (taiKhoan == null)
                throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng.");

            // ── 4. Cập nhật thời gian đăng nhập cuối ─────────────────
            _dao.CapNhatLanDangNhapCuoi(taiKhoan.MaTaiKhoan);

            return taiKhoan;
        }

        // ── Helper: MD5 hash ─────────────────────────────────────────────
        private static string MaHoaMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));   // lowercase hex, khớp DB
                return sb.ToString();
            }
        }
    }
}
