using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_DirectionsReduction
    {
        public static string[] dirReduc(String[] arr)
        {
            var res = new List<string>();
            var stack = new Stack<string>();
            foreach (var item in arr)
            {
                if (stack.Count == 0)
                {
                    stack.Push(item);
                }
                else
                {
                    var top = stack.Peek();
                    if (top == "NORTH" && item == "SOUTH" || top == "SOUTH" && item == "NORTH" || top == "EAST" && item == "WEST" || top == "WEST" && item == "EAST")
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(item);
                    }
                }
            }
            foreach (var item in stack)
            {
                res.Add(item);
            }
            return res.ToArray();
        }

        public static string[] ddirReduc(String[] arr)
        {
            var res = new List<string>();

            foreach (var item in arr)
            {
                if (res.Count() == 0)
                    res.Add(item);
                else
                {
                    if (res.Last() == "NORTH" && item == "SOUTH" || res.Last() == "SOUTH" && item == "NORTH" || res.Last() == "EAST" && item == "WEST" || res.Last() == "WEST" && item == "EAST")
                    {
                        res.RemoveAt(res.Count() - 1);
                    }
                    else
                    {
                        res.Add(item);
                    }
                }
            }
            return res.ToArray();
        }
    }
}
