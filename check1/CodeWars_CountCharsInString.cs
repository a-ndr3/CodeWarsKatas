using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_CountCharsInString
    {
        public static Dictionary<char, int> CountCharsInString(string str)
        {
            if (String.IsNullOrEmpty(str)) return new Dictionary<char, int>();

            var query = str.GroupBy(x => x)
                            .Select(y => new { Key = y, value = y.Count() })
                                .ToDictionary(x => x.Key.Key, x => x.value);
            
            return query;
        }
    }
}
