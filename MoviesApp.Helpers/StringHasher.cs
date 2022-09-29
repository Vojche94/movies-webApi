using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MoviesApp.Helpers
{
    public static class StringHasher
    {
        public static string HasherGenerator(string pass)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(pass));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);
            return hashedPassword;
        }
    }
}
