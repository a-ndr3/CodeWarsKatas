using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace check1
{
    internal class CodeWars_RomanNumeralsHelper
    {
        public static string ToRoman(int n)
        {
            var dict = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

            var sb = new StringBuilder();

            foreach (var item in dict)
            {
                while (n >= item.Key)
                {
                    sb.Append(item.Value);
                    n -= item.Key;
                }
            }

            return sb.ToString();
        }

        public static int FromRoman(string romanNumeral)
        {
            var dict = new Dictionary<string, int>()
            {
                {"I",1 },
                {"IV",4 },
                {"V",5 },
                {"IX",9 },
                {"X",10 },
                {"XL",40 },
                {"L",50 },
                {"XC",90 },
                {"C",100 },
                {"CD",400 },
                {"D",500 },
                {"CM",900 },
                {"M",1000 },
            };

            var len = romanNumeral.Length;
            int result = 0;
            var sb = new StringBuilder();
            for (int i = len-1; i >= 0; i--)
            {
                if (i-1 >= 0)
                {
                    sb.Append(romanNumeral.ElementAt(i-1)).Append(romanNumeral.ElementAt(i));
                    var found = dict.Where(x => x.Key == sb.ToString());

                    if (found.Any())
                    {
                        result += found.First().Value; 
                        sb.Clear();
                        if (i - 2 < 0) break;
                        i--;
                    }
                    else
                    {
                        result += dict.Where(x => x.Key == romanNumeral.ElementAt(i).ToString()).First().Value;
                        sb.Clear();
                    }
                }
                else
                {
                    result += dict.Where(x => x.Key == romanNumeral.ElementAt(i).ToString()).First().Value;
                }
            }
            return result;
        }
    }
}
