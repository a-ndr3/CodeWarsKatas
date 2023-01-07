using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_UniqueOrder
    {
        private static List<T> GetUniqObjectsFromIEnumerable<T>(IEnumerable<T> iterable)
        {
            var resultList = new List<T>();
            resultList.Add(iterable.First());

            var lastElement = iterable.First();
            foreach (var item in iterable.Skip(1))
            {
                if (!item.Equals(lastElement))
                { resultList.Add(item); lastElement = item; }
                else
                    lastElement = item;
            }
            return resultList;
        }
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            if (!iterable.Any()) return new List<T>();

            if (iterable.Count() > 1) return GetUniqObjectsFromIEnumerable(iterable);

            if (typeof(string) == iterable.First().GetType()) return UniqueInOrderIfString(iterable.First());

            return GetUniqObjectsFromIEnumerable(iterable);
        }
        private static IEnumerable<T> UniqueInOrderIfString<T>(T str)
        {
            if (str is String s)
            {
                var firstStepList = new List<char>();
                var resultList = new List<T>();

                firstStepList.Add(s.ToString().First());

                var lastElement = s.First();
                foreach (var item in s.Skip(1))
                {
                    if (!item.Equals(lastElement))
                    { firstStepList.Add(item); lastElement = item; }
                    else
                        lastElement = item;
                }
                foreach (var item in firstStepList)
                {
                    resultList.Add((T)(object)item.ToString());
                }
                return resultList;
            }
            return new List<T>();
        }


        ///Best practice
        public static IEnumerable<T> UniqueInOrderBest<T>(IEnumerable<T> iterable)
        {
            T previous = default(T);
            foreach (T current in iterable)
            {
                if (!current.Equals(previous))
                {
                    previous = current;
                    yield return current;
                }
            }
        }
    }
}
