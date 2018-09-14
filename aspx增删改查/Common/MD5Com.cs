using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class MD5Com
    {
        public static string GetMd5String(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder sbr = new StringBuilder();
            foreach (byte b in md5Buffer)
            {
                sbr.Append(b.ToString("x2"));
            }
            return sbr.ToString();


            //X为     十六进制 
            //2为     每次都是两位数
            //比如   0x0A ，若没有2,就只会输出0xA 
            //假设有两个数10和26，正常情况十六进制显示0xA、0x1A，
            //这样看起来不整齐，为了好看，可以指定"X2"，这样显示出来就是：0x0A、0x1A
        }
    }
}
