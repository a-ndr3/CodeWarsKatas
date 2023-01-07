using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_MoveAllZeroesToTheEnd
    {
        public static int[] MoveZeroes(int[] arr)
        {
            var count = arr.Length; var countDeleted = 0;
            var list = arr.ToList();

            countDeleted = list.RemoveAll(x => x == 0);

            for (int i = 0; i < countDeleted; i++)
            {
                list.Add(0);
            }

            return list.ToArray();
        }
    }
}
