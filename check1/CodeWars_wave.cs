using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_wave
    {
        public static List<string> wave(string str)
        {
            var resultsList = new List<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i])) continue;

                sb[i] = char.ToUpper(str[i]);
                resultsList.Add(sb.ToString());
                sb[i] = char.ToLower(str[i]);
            }

            return resultsList;
        }


        public List<string> wavN(string str) => str
        .Select((c, i) => str.Substring(0, i) + Char.ToUpper(c) + str.Substring(i + 1))
        .Where(x => x != str)
        .ToList();
    }
}
