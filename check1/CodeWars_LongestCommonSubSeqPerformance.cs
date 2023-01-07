using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static check1.Program;

namespace check1
{
    internal class CodeWars_LongestCommonSubSeqPerformance
    {
        private static char[] GetCommonSequence(string s1, string s2)
        {
            int size1 = s1.Length;
            int size2 = s2.Length;

            var table = new int[size1 + 1, size2 + 1];

            for (int i = 0; i <= size1; i++)
            {
                for (int j = 0; j <= size2; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        table[i, j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                    }
                }
            }

            var ind = table[size1, size2];

            char[] lcs = new char[ind + 1];
            lcs[ind] = Convert.ToChar("");

            while (size1 > 0 && size2 > 0)
            {
                if (s1[size1 - 1] == s2[size2 - 1])
                {
                    lcs[ind - 1] = s1[size1 - 1];


                    size1--;
                    size2--;
                    ind--;

                }

                else if (table[size1 - 1, size2] > table[size1, size2 - 1])
                {
                    size1--;
                }
                else
                {
                    size2--;
                }
            }
            return lcs;
        }
        public static string Lcs(string a, string b)
        {
            var arrResult = GetCommonSequence(a, b);

            var sb = new StringBuilder();

            foreach (var item in arrResult)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }


        public static string Lcs2(string a, string b)
        {
            return GetCommonSeq(a, b);
        }

        private static string GetCommonSeq(string s1, string s2)
        {
            var seq1 = GetAllSequences(s1);
            var seq2 = GetAllSequences(s2);

            var union = GetUnionOfSequences(new HashSet<string>[] { seq1, seq2 });

            return union.Where(x => x.Length == union.Max(y => y.Length)).First();
        }
        private static HashSet<string> GetAllSequences(string str)
        {
            var result = Enumerable
                 .Range(0, 1 << str.Length)
                    .Where(mask => mask >= 0)
                        .Select(mask => str
                             .Where((v, i) => ((1 << i) & mask) != 0)
                                 .ToArray());

            var set = new HashSet<string>();

            foreach (var item in result)
            {
                set.Add(GetStringFromCharArray(item));
            }

            return set;
        }

        private static string GetStringFromCharArray(char[] array)
        {
            var sb = new StringBuilder();

            foreach (var item in array)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
        private static HashSet<string> GetUnionOfSequences(HashSet<string>[] hashsets)
        {
            var result = new HashSet<string>(hashsets.First());

            foreach (var item in hashsets.Skip(1))
            {
                result.IntersectWith(item);
            }

            return result;
        }
    }
}
