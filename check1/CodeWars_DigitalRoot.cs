using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_DigitalRoot
    {
        public static int DigitalRoot(long n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += (int)(n % 10);
                n /= 10;
            }
            if (sum > 9)
            {
                return DigitalRoot(sum);
            }
            return sum;
        }
    }
}
