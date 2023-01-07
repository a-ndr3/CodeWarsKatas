using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_oddInt
    {
        public static int find_it(int[] seq)
        {
            var query = seq.GroupBy(x => x)
                          .Select(y => new { Key = y, value = y.Count() })
                              .ToDictionary(x => x.Key.Key, x => x.value);

            return query.Where(s => s.Value % 2 == 1).First().Key;
        }
    }
}
