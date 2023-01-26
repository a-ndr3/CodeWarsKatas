using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_MathExpressionEval
    {
        public static class Evaluate
        {
            public static string SolveUsingDataTable(string expression)
            {
                return Convert.ToDouble(new DataTable().Compute(expression, "")).ToString();
            }         
        }
    }
}
