using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_RangeExtraction
    {
        public static string GetRange(out int x, int begin, int[] arr)
        {
            var sb = new StringBuilder(); int count = 0; x = begin;
            for (int i = begin; i < arr.Length; i++)
            {
                if ((i+1 < arr.Length) && arr[i] + 1 == arr[i + 1]) { count++; continue;}
                else
                    if (count >= 2)
                {
                    sb.Append(arr[begin]).Append('-').Append(arr[i]);
                    x = i;
                    return sb.ToString();
                }
                else
                {
                    if (begin != i)
                    { 
                        sb.Append(arr[begin]).Append(',').Append(arr[i]); 
                    }
                    else
                    {
                        sb.Append(arr[begin]).Append(',');
                    }
                    x = i;
                    return sb.ToString();
                }
            }
            return sb.ToString();
        }
        public static string Extract(int[] args)
        {
            var sb = new StringBuilder();

            int last = 0;
            for (int i = 0; i < args.Length; i++)
            {
                var tmp = GetRange(out last, i, args);
                sb.Append(tmp);
                if (last == i) continue;
                else
                { i = last; sb.Append(','); }
            }

            var temp =  sb.ToString();
            if (temp.Last() == ',') return temp.Remove(temp.Length - 1);
            return temp;
        }
    }
}
