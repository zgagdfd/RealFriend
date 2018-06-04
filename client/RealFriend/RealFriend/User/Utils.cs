using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RealFriend.User
{
    class Utils
    {
        // 32位MD5加密
        public static string GetMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(s[i].ToString("x"));
            }
            return sb.ToString().Trim();
        }
    }
}
