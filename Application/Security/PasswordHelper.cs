using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public class PasswordHelper
    {
        public static string EncodePasswordSha256(string pass)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] originalBytes = Encoding.UTF8.GetBytes(pass);
                byte[] encodedBytes = sha256.ComputeHash(originalBytes);
                return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
