using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_BigIntSum
    {
        public static string Add(string a, string b)
        {
            var bigIntA = BigInteger.Parse(a);
            var bigIntB = BigInteger.Parse(b);

            return (bigIntA + bigIntB).ToString();
        }

    }
}
