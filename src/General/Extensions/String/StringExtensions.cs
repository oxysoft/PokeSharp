using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace General.Extensions
{
    public static class StringExtensions
    {
        #region Methods
        public static string WithFormat(this string value, params object[] parameters)
        {           
            return string.Format(value, parameters);
        }
        public static bool IsEqual(this string value1, string value2)
        {
            return value1.ToLower() == value2.ToLower();
        }
        public static string Md5(this string value)
        {
            MD5 md5 = MD5.Create();

            byte[] data = System.Text.Encoding.Default.GetBytes(value);
            byte[] hash = md5.ComputeHash(data);

            StringBuilder hashBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hashBuilder.Append(hash[i].ToString("X2"));
            }

            return hashBuilder.ToString().ToLower();
        }
        #endregion
    }
}
