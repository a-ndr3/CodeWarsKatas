using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_SumStrings
    {
        public static string sumStrings(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return b;
            }
            if (string.IsNullOrEmpty(b))
            {
                return a;
            }
            return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString();
        }
    }
}
