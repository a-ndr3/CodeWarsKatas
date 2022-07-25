using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_SumOfInterwals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            if (intervals is null)
            {
                throw new ArgumentNullException(nameof(intervals));
            }

            var x = intervals
      .SelectMany(i => Enumerable.Range(i.Item1, i.Item2 - i.Item1))
      .Distinct()
      .Count(); return 0;

            //Array.Sort(intervals);


            //int x = intervals[0].Item1, res = 0;

            //foreach (var item in intervals)
            //{
            //    if (item.Item2 >= x)
            //    {
            //        var t = item.Item1 > x ? item.Item1 : x;
            //        res += item.Item2 - t;
            //        x = item.Item2;
            //    }
            //}
            //return res;

        }
    }
}