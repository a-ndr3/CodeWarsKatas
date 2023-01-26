using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_FindTheUniqNumber<T>
    {
        public static T GetUnique(IEnumerable<T> numbers)
        {
            return numbers.GroupBy(n => n).OrderBy(g => g.Count()).First().Key;
        }
    }
}
