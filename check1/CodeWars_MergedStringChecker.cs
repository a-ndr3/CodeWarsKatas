using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_MergedStringChecker
    {
        private static Dictionary<char, int> CountElements(string str)
        {
            var query = str.GroupBy(x => x)
                           .Select(y => new { Key = y, value = y.Count() })
                               .ToDictionary(x => x.Key.Key, x => x.value);

            return query;
        }

        private static bool CheckValues(Dictionary<char,int> pairs, KeyValuePair<char,int> keyValuePair)
        {
            int value = 0;
            pairs.TryGetValue(keyValuePair.Key, out value);

            if (value != keyValuePair.Value) return false;
            else
                return true;
        }
        public static bool isMerge(string s, string part1, string part2)
        {
            if (String.Empty == s && String.Empty == part1 && String.Empty == s && String.Empty == part2) return true;
            if (String.IsNullOrEmpty(s)) return false;

            var fullString = String.Join("", part1.ToLower().Trim(), part2.ToLower());
            var countDictfullString = CountElements(fullString);
            var countDictInitString = CountElements(s);

            foreach (var item in countDictInitString)
            {
                if (!countDictfullString.ContainsKey(item.Key)) return false;

                if (!CheckValues(countDictfullString, item)) return false;
            }

            return true;
        }
    }
}
