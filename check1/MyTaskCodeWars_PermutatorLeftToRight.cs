using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class MyTaskCodeWars_PermutatorLeftToRight
    {
        //LINQ Solution for chars
        static IEnumerable<char[]> GetEveryPermutationFromLeftToRight(char[] array)
        {
            return System.Linq.Enumerable
                .Range(0, 1 << array.Length)
                    .Where(mask => mask != 0)
                        .Select(mask => array
                             .Where((v, i) => ((1 << i) & mask) != 0).ToArray());
        }

        //Deafult string solution
        public static class PermutatorLeftToRight
        {
            private static List<string> finalList;

            public static string[] GetStrings(char[] array)
            {
                finalList = new List<string>();
                var workList = new List<string>();

                foreach (var item in array)
                {
                    workList.AddRange(finalList);

                    workList = AddLetter(workList, item);

                    AddToFinal(workList, item);

                    workList.Clear();
                }

                return finalList.ToArray();
            }

            private static List<string> AddLetter(List<string> listToAddChar, char letter)
            {
                var tempList = new List<string>();

                foreach (var item in listToAddChar)
                {
                    var sb = new StringBuilder();
                    sb.Append(item).Append(letter);

                    tempList.Add(sb.ToString());
                }

                return tempList;
            }

            private static void AddToFinal(List<string> tempList, char letter)
            {
                foreach (var item in tempList)
                {
                    finalList.Add(item);
                }
                finalList.Add(letter.ToString());
            }
        }

        //Generic solution
        public static class PermutatorLeftToRight<T>
        {
            private static List<List<T>> finalList;

            public static List<List<T>> GetArray(T[] array)
            {
                finalList = new List<List<T>>();
                var workList = new List<List<T>>();

                foreach (var item in array)
                {
                    workList.AddRange(finalList);

                    workList = AddLetter(workList, item);

                    AddToFinal(workList, item);

                    workList.Clear();
                }

                return finalList;
            }

            private static List<List<T>> AddLetter(List<List<T>> listToAddChar, T letter)
            {
                var tempList = new List<List<T>>();

                foreach (var item in listToAddChar)
                {
                    var temp = item.ToList();
                    temp.Add(letter);
                    tempList.Add(temp);
                }

                return tempList;
            }

            private static void AddToFinal(List<List<T>> tempList, T letter)
            {
                foreach (var item in tempList)
                {
                    finalList.Add(item);
                }
                finalList.Add(new List<T>() { letter });
            }
        }
    }
}
