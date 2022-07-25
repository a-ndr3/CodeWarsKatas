using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_rgb
    {
        public static string Rgb(int r, int g, int b)
        {
            r = r < 0 ? r = 0 : r; r = r > 255 ? r = 255 : r;
            g = g < 0 ? g = 0 : g; g = g > 255 ? g = 255 : g;
            b = b < 0 ? b = 0 : b; b = b > 255 ? b = 255 : b;

            return String.Join("", r.ToString("X2"), g.ToString("X2"), b.ToString("X2"));
        }
    }
}
