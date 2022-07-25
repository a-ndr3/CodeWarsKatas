using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_Int32ToIP
    {
        private static string GetBinary(uint ip)
        {
            var tmp = Convert.ToString(ip, 2);
            if (tmp.Length < 32)
            {
                return tmp.PadLeft(32, '0');
            }
            return tmp;
        }

        private static int GetDec(string item)
        {
            return Convert.ToInt32(item, 2);
        }

        public static string UInt32ToIP(uint ip)
        {
            if (ip <= 256) return $"0.0.0.{ip}";

            var sb = new StringBuilder();
            var binary = GetBinary(ip);

            int i = 0;
            while (i <= binary.Length)
            {
                if (i + 8 <= binary.Length)
                {
                    sb.Append(GetDec(binary.Substring(i, 8)));
                    i = i + 8;
                    if (i == 32)
                        break;
                    sb.Append(".");
                }
                else
                {
                    while (i != 32)
                    {
                        sb.Append("0");
                        i += 8;
                        if (i == 32)
                            break;
                        sb.Append(".");
                    }
                    break;
                }
            }

            return sb.ToString();
        }

        public static string uu(uint ip)
        {
            return IPAddress.Parse(ip.ToString()).ToString();
        }


        //var a = UInt32ToIP(756435763);
        //var x = IPAddress.Parse("756435763");

        //var b = string.Join(".", (new int[] { 24, 16, 8, 0 }).Select(e => 756435763 >> e & 255));


        //byte[] bytes = BitConverter.GetBytes(756435763);
        //Array.Reverse(bytes);

        //    var c = string.Join(".", bytes);
        //var c1 = new IPAddress(bytes).ToString();
    }
}
