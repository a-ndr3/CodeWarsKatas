using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_MaximumSubArraySum
    {
        
        public static int MaxSequence(int[] arr)
        {
            if (arr is null || arr.Length == 0)
            {
                return 0;
            }
            
            var arrLst = arr.ToList();

            //var lst = new List<List<int>>();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = i; j < arr.Length; j++)
            //    {
            //        //var ls = new List<int>();
            //        //for (int k = i; k <= j; k++)
            //        //{ ls.Add(arr[k]); }

            //        lst.Add(new ArraySegment<int>(arr, i, j - (i - 1)).ToList());
            //    }
            //}
            
            var rng = Enumerable.Range(0, arrLst.Count)
                .SelectMany(start => 
                    Enumerable.Range(1, arrLst.Count - start)
                        .Select(count => arrLst.GetRange(start, count))
                ).ToList();


            int max = 0;
            foreach (var item in rng)
            {
                var tmp = item.Sum();
                if (tmp > max)
                    max = tmp;
            }

            return max;
        }
    }
}
