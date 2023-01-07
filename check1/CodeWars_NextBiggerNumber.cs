using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_NextBiggerNumber
    {
        public class BiggerNumberFinder
        {
            private char[] number;

            public BiggerNumberFinder(long number)
            {
                this.number = number.ToString().ToCharArray();
            }

            static IEnumerable<IEnumerable<T>>
    GetKCombsWithRept<T>(IEnumerable<T> list, int length) where T : IComparable
            {
                if (length == 1) return list.Select(t => new T[] { t });
                return GetKCombsWithRept(list, length - 1)
                    .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) >= 0),
                        (t1, t2) => t1.Concat(new T[] { t2 }));
            }

            private List<IEnumerable<long>> GetAllNumbersThatContainTheseDigits(long[] digits)
            {
                return GetKCombsWithRept<long>(digits, digits.Length).ToList();
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
                var numbers = new List<long>();
                foreach (var item in longs)
                {
                    numbers.Add(GetFullNumber(item));
                }
                return numbers;
            }

            public long FindNextBiggerNumber()
            {
                if (number.Length == 0 || number.Length == 1)
                {
                    return -1;
                }

                for (int i = 2; i <= number.Length; i++)
                {
                    var tail = GetSpecificAmountOfDigits(i);

                    var allNumbers = GetLongs(
                        GetAllNumbersThatContainTheseDigits(
                        tail));

                    var numberFromTail = Convert.ToUInt32(String.Join("", tail));

                    var seq = FindSeqWithSameDigitsAsTail(allNumbers.Where(y => y > numberFromTail),tail);

                    if (!seq.Any()) continue;
                    else
                    {
                        var nextNumber = seq.Min();

                        return SwapTail(nextNumber);
                    }
                }
                return -1;
            }
            
            private List<long> FindSeqWithSameDigitsAsTail(IEnumerable<long> longs,long[] tail)
            {
                var origin = tail.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });

                var list = new List<long>();
                
                foreach (var item in longs)
                {
                    var tmp = item.ToString().ToCharArray()
                        .Select(x => (long)Char.GetNumericValue(x)).ToArray()
                        .GroupBy(c => c)
                        .Select(c => new { Char = c.Key, Count = c.Count() });

                    bool flag = false;
                    foreach (var ch in origin)
                    {
                        var x = tmp.Where(x => x.Char == ch.Char);
                        
                        if (!x.Any() || x.First().Count != ch.Count)
                        {
                            flag = true;
                            break; 
                        }    
                    }

                    if (flag == false)
                        list.Add(item);
                }
                return list;
            }

            private long SwapTail(long nextNumber)
            {
                var temp = nextNumber.ToString();
                var half = String.Join("", number.Take(number.Length - temp.Length));
                return Convert.ToUInt32(String.Join("", half, temp));
            }
        }

        public static long NextBiggerNumber(long n)
        {
            return new BiggerNumberFinder(n).FindNextBiggerNumber();
        }
    }
}
