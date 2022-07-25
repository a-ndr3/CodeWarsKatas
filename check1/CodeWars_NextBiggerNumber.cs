using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_NextBiggerNumber
    {
        public static char[] Swap(char[] str, int pos1, int pos2)
        {      
            var tmp = str.ElementAt(pos1);
            str[pos1] = str[pos2];
            str[pos2] = tmp;
            return str;
        }
        public static long NextBiggerNumber(long n)
        {
            var tmp = n.ToString().ToCharArray();

            int count = 0;
            for (int i = tmp.Length-1; i > 0; i--)
            {
                var x = String.Join("", Swap(tmp, i, tmp.Length - 1 - count));
                
                var temp = Convert.ToUInt32(x);
                if (temp > n) return temp;
                else { count++; continue; }
            }
            return 0;
        }
    }
}
