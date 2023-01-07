using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_TopWords
    {
        private static Dictionary<string, int> CountElements(string[] str)
        {
            var query = str.GroupBy(x => x)
                           .Select(y => new { Key = y, value = y.Count() })
                               .ToDictionary(x => x.Key.Key, x => x.value);

            return query;
        }

        private static bool CheckIfPreviousOrNextIsCharOrDigit(int index, string str)
        {
            if (str.ElementAtOrDefault(index + 1) != default && Char.IsLetterOrDigit(str[index + 1]))
                return true;
            if (str.ElementAtOrDefault(index - 1) != default && Char.IsLetterOrDigit(str[index - 1]))
                return true;
            return false;

        }
        private static string RemoveSpecialCharacters(string str)
        {
            str = Regex.Replace(str, @"\s+", " ");
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\'' && (CheckIfPreviousOrNextIsCharOrDigit(i, str)))
                {
                    sb.Append(str[i]);
                    continue;
                }
                if (!Char.IsLetterOrDigit(str[i]))
                { 
                    sb.Append(" "); 
                    continue; 
                };
                if (Char.IsLetterOrDigit(str[i]))
                { 
                    sb.Append(str[i]); 
                    continue; 
                }
                if (Char.IsWhiteSpace(str[i]))
                { 
                    sb.Append(str[i]); 
                    continue; 
                }
            }

            //foreach (var item in str)
            //{
            //    if (Char.IsLetterOrDigit(item) || item == '\'')
            //        sb.Append(item);
            //    if (Char.IsWhiteSpace(item))
            //        sb.Append(item);
            //}

            return sb.ToString();
        }
        public static List<string> Top3(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            var str = RemoveSpecialCharacters(s);

            var temp = str.Split(" ");

            if (!temp.Any())
            {
                return new List<string>();
            }

            var wordsAndAmounts = CountElements(temp);

            wordsAndAmounts.Remove(" ");
            wordsAndAmounts.Remove("");

            var query = wordsAndAmounts.OrderByDescending(x => x.Value)
                                            .ThenBy(x => x.Key);

            if (query.Count() > 2)
            {
                var list = new List<string>();
                var result = query.Take(3);

                foreach (var item in result)
                {
                    list.Add(item.Key.ToLower());
                }

                return list;
            }

            if (query.Count() == 2)
            {
                var list = new List<string>();
                var result = query.Take(2);

                foreach (var item in result)
                {
                    list.Add(item.Key.ToLower());
                }

                return list;
            }

            if (query.Count() == 1)
            {
                var list = new List<string>();

                list.Add(query.First().Key.ToLower());

                return list;
            }


            return new List<string>();
        }
    }
}
