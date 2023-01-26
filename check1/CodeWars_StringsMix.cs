using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace check1
{
    internal class CodeWars_StringsMix
    {
        public class StringParts
        {
            public char Symbol { get; set; }
            public int Amount { get; set; }
            public int StringNumber { get; set; }

            public bool EqualCharAmount { get; set; }
        }

        public static string Mix(string s1, string s2)
        {
            var tempCollection = GetCollectionOfChars(s1, s2);

            var result = GetFinalString(tempCollection);

            return result;
        }

        private static List<List<StringParts>> GetCollectionOfChars(string s1, string s2)
        {
            var selection1 = GetSelection(s1, 1);

            var selection2 = GetSelection(s2, 2);

            var selection3 = GetFullCollectionOfChars(selection1, selection2);

            return selection3;
        }

        private static List<List<StringParts>> GetFullCollectionOfChars(List<StringParts> collection1, List<StringParts> collection2)
        {
            var firstList = GetCollection(collection1, collection2); 
            var secondList = GetCollection(collection2, firstList);

            var result = firstList.Concat(secondList)
              .OrderByDescending(x => x.Amount)
              .GroupBy(x => x.Amount).Select(u => u.ToList()).ToList();

            return result;
        }

        private static List<StringParts> GetCollection(List<StringParts> collection1, List<StringParts> collection2)
        {
            var list = new List<StringParts>();

            foreach (var item in collection1)
            {              
                var tmp = collection2.Select(x => x).Where(y => y.Symbol == item.Symbol);

                if (tmp.Any())
                {
                    if (tmp.First().Amount > item.Amount)
                    { 
                        list.Add(tmp.First());
                    }
                    else if (tmp.First().Amount == item.Amount)
                    {
                        var temp = item;
                        temp.EqualCharAmount = true;
                        temp.StringNumber = -1;
                        list.Add(temp);
                    }
                    else
                    {
                        list.Add(item);
                    }
                    collection2.Remove(tmp.First());
                }
                else
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private static List<StringParts> GetSelection(string str, int stringNumber)
        {
            return str.GroupBy(x => x)
                .Where(y => y.Key >= 97 && y.Key <= 122)
                .Select(x => new StringParts { Symbol = x.Key, Amount = x.Count(), StringNumber = stringNumber })
                .Where(c => c.Amount > 1).ToList();
        }
        private static string GetFinalString(List<List<StringParts>> collection)
        {
            var sb = new StringBuilder();

            var strings = new List<string>();

            foreach (var item in collection)
            {
                foreach (var it in item)
                {
                    if (it.EqualCharAmount)
                    {
                        sb.Append("=:");
                    }
                    else
                    {
                        sb.Append(it.StringNumber).Append(":");
                    }

                    for (int i = 0; i < it.Amount; i++)
                    {
                        sb.Append(it.Symbol);
                    }

                    strings.Add(sb.ToString());

                    sb.Clear();
                }
            }

            var resultString = string.Join("/", strings.OrderByDescending(x => x.Length).ThenBy(y => y[0]).ThenBy(c => c[2]));

            return resultString;
        }
    }
}
