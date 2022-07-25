using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_ConseqStrings
    {
        public static string GetLongest(string[] arr, int k)
        {
            if (arr is null)
            {
                return "";
            }

            int longestFirstWord = 0; int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i+k <= arr.Length)
                {
                    //var tmp = String.Join("", arr[i], arr[i + 1]).Length;

                    var tmp = String.Join("", arr.Skip(i).Take(k)).Length;

                    if (tmp > count)
                    {
                        longestFirstWord = i;
                        count = tmp;
                    }

                }
            }
            // return String.Join("", arr[longestFirstWord], arr[longestFirstWord + 1]);
            return String.Join("", arr.Skip(longestFirstWord).Take(k));
        }


        
        public static string GetLongestLinq(string[] arr)
        {
            int longest = 0; int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1; j < arr.Length; j+=2)
                {
                    var x = String.Join("", arr[i], arr[j]).Length;

                    if (x > longest) { longest = x; k = i; }
                }
            }

            return String.Join("", arr[k], arr[k + 1]);
        }
    }
}
