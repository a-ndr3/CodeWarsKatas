using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_Scramblies
    {
        private static Dictionary<char,int> CountElements(string str)
        {
            var query = str.GroupBy(x => x)
                           .Select(y => new { Key = y, value = y.Count() })
                               .ToDictionary(x => x.Key.Key, x => x.value);

            return query;
        }
        public static bool Scramble(string str1, string str2)
        {
            var selectFromStr1 = CountElements(str1.ToLower());
            var selectFromStr2 = CountElements(str2.ToLower());

            foreach (var item in selectFromStr2)
            {
                int value = 0;
                if (!selectFromStr1.TryGetValue(item.Key, out value)) return false;

                if (value < item.Value) return false;
            }

            return true;
        }
    }
}
