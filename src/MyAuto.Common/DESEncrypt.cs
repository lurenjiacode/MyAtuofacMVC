using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MyAuto.Common
{
    public class DESEncrypt
    {
        /// <summary>
        /// Base64解密，编码方式为Encoding.UTF8
        /// </summary>
        /// <param name="Text">密文</param>
        /// <returns>明文</returns>
        public static string Base64Decrypt(string Text)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(Text);
            try
            {
                decode = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                decode = Text;
            }
            return decode;
        }
    }
}
