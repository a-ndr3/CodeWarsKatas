using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_LastNumInPowArrays
    {
        public static List<BigInteger> GetArrayEqualToSum(Dictionary<BigInteger, BigInteger> ints, BigInteger num)
        {
            var resultList = new List<BigInteger>();

            BigInteger sum = 0;
            sum = sum + ints.Keys.Last();
            resultList.Add(ints.Values.Last());

            bool flag = true;
            var i = ints.Count - 2;

            while (flag)
            {
                if (sum == num) return resultList;

                var current = ints.ElementAt(i);

                if (current.Key == ints.Keys.ElementAt(0))
                {
                    var tmp = num - sum;
                    if (ints.Keys.Contains(tmp))
                    {
                        var sel = ints.Keys.Where(x => x == tmp);
                        resultList.Add(ints.Select(y => y).Where(x => x.Key == sel.First()).First().Value);
                        break;
                    }
                    else
                    {
                        sum += current.Key;
                        resultList.Add(current.Value);
                        continue;
                    }
                }
                if (sum + current.Key <= num)
                {
                    sum += current.Key;
                    resultList.Add(current.Value);
                    i--;
                    continue;
                }
                i--;
            }

            return resultList;
        }
        public static int GetLastDigit(BigInteger n1, BigInteger n2, int mod = 10)
        {
            if (n2 == 0) return 1;

            var valuesAll2Pow = new Dictionary<BigInteger, BigInteger>();

            valuesAll2Pow.Add(1, n1);

            for (BigInteger i = 2; i <= n2; i *= 2)
            {
                var tmp = BigInteger.Pow(valuesAll2Pow.Last().Value, 2);
                valuesAll2Pow.Add(i, tmp < n2 ? tmp : (tmp % mod));
            }

            var temp = GetArrayEqualToSum(valuesAll2Pow, n2);

            BigInteger result = 1;
            foreach (var item in temp)
            {
                result *= item;
            }

            return (int)(result % mod);
        }

        // solution 1
        public static BigInteger GetPowNumber(BigInteger x, BigInteger y)
        {
            if (y == 0) return 1;

            else if (y == 1) return x;

            else
            {
                BigInteger result = GetPowNumber(x, y / 2);
                
                if (y%2 == 0)
                {
                    return result * result;
                }
                else
                {
                    return result * x * result;
                }
            }
        }
        public static BigInteger GetFullDegree(int[] array)
        {
            BigInteger resultTmp = 0;

            for (int i = array.Length-1; i > 0; i--)
            {
                if ((i-1) == 0) return resultTmp;

                if (i == array.Length - 1)
                {
                    resultTmp = GetPowNumber(array[i-1], array[i]);
                }
                else
                {
                    resultTmp = GetPowNumber(array[i - 1], resultTmp);
                }
            }

            return resultTmp;
        }
        
        // solution 2
        private static int GetSpecificElement(int number, int pos)
        {
            int[] pow2 = new int[] { 2, 4, 8, 6, 2, 4, 8, 6, 2 };
            int[] pow3 = new int[] { 3, 9, 7, 1, 3, 9, 7, 1, 3 };
            int[] pow4 = new int[] { 4, 6, 4, 6, 4, 6, 4, 6, 4 };
            int[] pow7 = new int[] { 7, 9, 3, 1, 7, 9, 3, 1, 7 };
            int[] pow8 = new int[] { 8, 4, 2, 6, 8, 4, 2, 6, 8 };
            int[] pow9 = new int[] { 9, 1, 9, 1, 9, 1, 9, 1, 9 };
            
            switch (number)
            {
                case 1:
                    return 1;
                case 2:
                    return pow2[pos];
                case 3:
                    return pow3[pos];
                case 4:
                    return pow4[pos];
                case 5:
                    return 5;
                case 6:
                    return 6;
                case 7:
                    return pow7[pos];
                case 8:
                    return pow8[pos];
                case 9:
                    return pow9[pos];                    
                default: return 0;
            }
        }

        public static int GetLastNumberOfPow(int[] array)
        {
            if (!array.Any()) return 1;

            var lastNumberOfTheFirstEl = array[0] % 10;
            if (array.Length == 1) return lastNumberOfTheFirstEl;

            
            
            var amountOfEl = array.Length % 10;

            return GetSpecificElement(lastNumberOfTheFirstEl, amountOfEl);
        }


        // solution 3

        public static bool IsEnd(int[] arr, int num)
        {
            return (arr.Length - 1 < num);
        }

        public static bool IsZero(int[]arr, int num)
        {
            if (!IsEnd(arr, num))
                if (arr[num] == 0)
                    return !IsZero(arr, num + 1);
            return false;
        }

        public static bool IsUnity(int[] arr, int num)
        {
            if (IsEnd(arr, num) || arr[num] == 1)
                return true;
            return IsZero(arr, num + 1);
        }

        public static bool IsOdd(int[] arr, int num)
        {
            if (IsEnd(arr, num) || arr[num] % 2 == 1)
                return true;
            return IsZero(arr, num+1);
        }

        public static int pow2(int[] arr, int num)
        {
            if (IsEnd(arr, num) || arr[num] % 2 == 1)
                return 1;
            return IsZero(arr, num + 1) ? 1 : 0;
        }

        public static int pow4(int[] arr, int num)
        {
            if (IsEnd(arr, num)) return 1;
            switch (arr[num] % 4)
            {
                case 0: return IsZero(arr, num + 1) ? 1 : 0;
                case 1: return 1;
                case 2:
                    if (IsZero(arr, num + 1)) return 1;
                    if (IsUnity(arr, num + 1)) return 2;
                    return 0;
                case 3: return IsOdd(arr, num + 1) ? 3 : 1;
                default: return 0;
            }
        }

        public static int GetNum(int[] arr)
        {
            var list = new List<int[]>();

            list.Add(new int[1] { 0 });
            list.Add(new int[1] { 1 });
            list.Add(new int[4] { 2,4,8,6 });
            list.Add(new int[4] { 3,9,7,1 });
            list.Add(new int[2] { 4,6 });
            list.Add(new int[1] { 5 });
            list.Add(new int[1] { 6 });
            list.Add(new int[4] { 7,9,3,1 });
            list.Add(new int[4] { 8,4,2,6 });
            list.Add(new int[2] { 9,1});


            var x = arr[0] % 10;

            if (IsZero(arr, 1)) return 1;

            var row = list.ElementAt(x);

            switch (row.Length)
            {
                case 1: return row[0];
                case 2: return row[1 - pow2(arr, 1)];
                case 4: return row[(pow4(arr, 1) + 3) % 4];
            }
            return 0;
        }

        //solution 4

        public static int GetLastDigit(int[] arr)
        {
            //var list = new List<int>(arr);

            //if (!list.Any()) return 1;

            //if (list.Count == 1) return list[0] % 10;

            //while (list.Count > 1)
            //{
            //    var nums = list.GetRange(list.Count-2, 2);
            //    list.RemoveRange(list.Count-2, 2);

            //    list.Add((int)Math.Pow((int)(nums[0] % 10), (int)((nums[1] - 1) % 4 + 1)) % 10);
            //}
            //return list[0];
            
            BigInteger res = 1;
            foreach (var item in arr.Reverse())
            {
                if (res < 4)
                {
                    res = GetPowNumber(item, res);
                }
                else
                {
                    res = GetPowNumber(item, res % 4 + 4);
                }
            }
            return (int)(res % 10);
        }
        
    }
}
