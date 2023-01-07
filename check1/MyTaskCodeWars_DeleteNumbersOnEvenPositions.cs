using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class MyTaskCodeWars_DeleteNumbersOnEvenPositions
    {
        ////удалить все числа стоящие на четных позициях из массива

        public static class DelNums
        {
            public static List<T> DeleteNums<T> (List<T> list)
            {
                var tmp = list.Where((x, i) => i % 2 != 0).ToList();
                return tmp;
            }
        }


        //solution 2, simple one

        public static class DelNums2
        {
            public static List<T> DeleteNums<T>(List<T> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list.RemoveAt(i);
                }
                return list;
            }
        }
    }
}
