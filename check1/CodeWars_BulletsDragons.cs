using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_BulletsDragons
    {
        public static bool Hero(int bullets, int dragons)
        {
            return ((bullets / dragons) >= 2) ? true : false;
        }
    }
}
