using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_TwoSum
    {
        public static int[] TwoSum(int[] numbers, int target)
        {
            var result = new List<int>();

            var tuple = numbers.SelectMany((x, i) => numbers.Skip(i + 1), (x, y) => Tuple.Create(x, y)).Select(x => x).Where(y => y.Item1 + y.Item2 == target);

            if (!tuple.Any()) return new int[] { };

            var firstIndex = Array.IndexOf(numbers, tuple.First().Item1);
            result.Add(firstIndex);

            var second = Array.IndexOf(numbers, tuple.First().Item2,0);

            if (second == -1 || firstIndex == second)
            {
                second = Array.IndexOf(numbers, tuple.First().Item2, firstIndex + 1);
            }

            result.Add(second);

            return result.ToArray();

        }
    }
}
