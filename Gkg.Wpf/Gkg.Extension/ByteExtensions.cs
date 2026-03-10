using System;
using System.Collections.Generic;
using System.Text;

namespace Gkg.Extension
{
    public static class ByteExtensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }   
    }
}
