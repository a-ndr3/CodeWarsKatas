using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_TrailingZeroes
    {
        public static int TrailingZeros(int n)
        {
            if (n < 5) return 0;

            if (n < 0)
                return -1;

            int count = 0;

            for (int i = 5; n / i >= 1; i *= 5)
                count += n / i;

            return count;
        }
    }
}
