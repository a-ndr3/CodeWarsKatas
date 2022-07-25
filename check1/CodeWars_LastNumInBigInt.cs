using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace check1
{
    internal class CodeWars_LastNumInBigInt
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

        //var y = BigInteger.ModPow(999, 9999, 10);

        //var x = CodeWars_LastNumInBigInt.GetLastDigit(999, 9999);
    }
}
