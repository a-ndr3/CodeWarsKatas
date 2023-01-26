using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_NextBiggerNumber
    {
        public static IEnumerable<IEnumerable<T>> Permutate<T>(IEnumerable<T> source)
        {
            var xs = source.ToArray();
            return xs.Length == 1 ? new[] { xs } : (
                        from n in Enumerable.Range(0, xs.Length)
                        let cs = xs.Skip(n).Take(1)
                        let dss = Permutate<T>(xs.Take(n).Concat(xs.Skip(n + 1)))
                        from ds in dss
                        select cs.Concat(ds)
                    ).Distinct(new EnumerableEqualityComparer<T>());
        }

        IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        private class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            public bool Equals(IEnumerable<T> a, IEnumerable<T> b)
            {
                return a.SequenceEqual(b);
            }

            public int GetHashCode(IEnumerable<T> t)
            {
                return t.Take(1).Aggregate(0, (a, x) => a ^ x.GetHashCode());
            }
        }


        public class BiggerNumberFinder
        {
            private char[] number;
            private long numberValue;

            public BiggerNumberFinder(long number)
            {
                this.numberValue = number;
                this.number = number.ToString().ToCharArray();
            }

            private List<IEnumerable<long>> GetAllNumbersThatContainTheseDigits(long[] digits)
            {
                return Permutate(digits).ToList();           
            }

            private long[] GetSpecificAmountOfDigits(int length)
            {
                return number.TakeLast(length).Select(x => (long)Char.GetNumericValue(x)).ToArray();
            }

            private long GetFullNumber(IEnumerable<long> ints)
            {
                var sb = new StringBuilder();
                foreach (var item in ints)
                {
                    sb.Append(item);
                }

                return Convert.ToUInt32(sb.ToString());
            }

            private List<long> GetLongs(List<IEnumerable<long>> longs)
            {
                var numbers = new HashSet<long>();
                foreach (var item in longs)
                {
                    numbers.Add(GetFullNumber(item));
                }
                return numbers.ToList();
            }

            public long DoJob()
            {
                if (number.Length == 0 || number.Length == 1)
                {
                    return -1;
                }

                var allNumbers = GetLongs(
                       GetAllNumbersThatContainTheseDigits(GetSpecificAmountOfDigits(number.Length)));

                var result = allNumbers.OrderBy(x => x).Where(y => y > numberValue);

                if (result.Any())
                {
                    return result.First();
                }
                else
                {
                    return -1;
                }
            }

        }

        public static long NextBiggerNumber(long n)
        {
            return new BiggerNumberFinder(n).DoJob();
        }
    }
}
