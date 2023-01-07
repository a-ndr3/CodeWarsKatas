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




            //public class MathEvaluator
            //{
            //    private double result = 0.0;
            //    private readonly string expression;

            //    public enum MathEvalAction : byte
            //    {
            //        Addition = 0,
            //        Substraction = 1,

            //        Multiplication = 10,
            //        Division = 11
            //    }
            //    public struct MathEvaluatorObject
            //    {
            //        public double? Number1;
            //        public double? Number2;
            //        public MathEvalAction Action;
            //    }
            //    private void ParseExpression(string expression)
            //    {
            //        var fullParsedExpressionToBeSolvedForEachIntoResult = new ParenthesisSeparator(expression).GetResult();

            //        var cache = new List<double>();

            //        foreach (var item in fullParsedExpressionToBeSolvedForEachIntoResult)
            //        {
            //            if (item.Number1 != null && item.Number2 != null)
            //            {
            //                double temp1 = item.Action switch
            //                {
            //                    MathEvalAction.Addition => Addition((double)item.Number1, (double)item.Number2),
            //                    MathEvalAction.Division => Division((double)item.Number1, (double)item.Number2),
            //                    MathEvalAction.Substraction => Substraction((double)item.Number1, (double)item.Number2),
            //                    MathEvalAction.Multiplication => Multiplication((double)item.Number1, (double)item.Number2)
            //                };
            //                cache.Add(temp1);
            //            }
            //            else
            //            {
            //                if (item.Number1 == null && item.Number2 == null)
            //                {
            //                    //result += cache.ElementAt(cache.Count - 1) + cache.Last();
            //                    result = item.Action switch
            //                    {
            //                        MathEvalAction.Addition => Addition(cache.Last(),cache.ElementAt(cache.Count - 2)),
            //                        MathEvalAction.Division => Division(cache.Last(),cache.ElementAt(cache.Count - 2)),
            //                        MathEvalAction.Substraction => Substraction(cache.Last(), cache.ElementAt(cache.Count - 2)),
            //                        MathEvalAction.Multiplication => Multiplication(cache.Last(),cache.ElementAt(cache.Count - 2))
            //                    };
            //                }
            //                else
            //                {
            //                    double temp = item.Action switch
            //                    {
            //                        MathEvalAction.Addition => Addition(item.Number1 ?? cache.Last(), item.Number2 ?? 0),
            //                        MathEvalAction.Division => Division(item.Number1 ?? cache.Last(), item.Number2 ?? 1),
            //                        MathEvalAction.Substraction => Substraction(item.Number1 ?? cache.Last(), item.Number2 ?? 0),
            //                        MathEvalAction.Multiplication => Multiplication(item.Number1 ?? cache.Last(), item.Number2 ?? 1)
            //                    };

            //                    cache.Add(temp);
            //                }
            //            }
            //        }
            //    }
            //    public MathEvaluator(string expression)
            //    {
            //        this.expression = expression;
            //    }

            //    public double GetResult()
            //    {
            //        ParseExpression(expression);
            //        return result;
            //    }

            //    private class ParenthesisSeparator
            //    {
            //        private List<MathEvaluatorObject> parsedExpression;
            //        public ParenthesisSeparator(string expression)
            //        {
            //            var list = new List<MathEvaluatorObject>();
            //            parsedExpression = Parse(expression, list);
            //        }

            //        private List<MathEvaluatorObject> Parse(string expression, List<MathEvaluatorObject> objects)
            //        {
            //            var firstOccurence = GetIndexOfFirstSymbolFromTheBeginning(expression, '(');

            //            if (firstOccurence != -1)
            //            {
            //                var lastOccurence = GetIndexOfFirstSymbolFromTheEnd(expression, ')');

            //                if (ParenthesisExistanceBetweenIndexex(expression, firstOccurence, lastOccurence))
            //                {
            //                    Parse(GetSubString(expression, firstOccurence, lastOccurence), objects);
            //                }
            //                else
            //                {
            //                    var substrSplitted = GetSubString(expression, firstOccurence, lastOccurence);
            //                    var mathObj = new MathEvaluatorObject();

            //                    if (substrSplitted.Contains("--"))
            //                    {
            //                        mathObj.Number1 = substrSplitted.First();
            //                        mathObj.Number2 = substrSplitted.Last();
            //                        mathObj.Action = MathEvalAction.Substraction;
            //                    }
            //                    else
            //                    {
            //                        var symbolForSplit = "";
            //                        if (substrSplitted.Length == 4 || substrSplitted.Length == 5) symbolForSplit = substrSplitted.ElementAt(2).ToString();
            //                        if (substrSplitted.Length == 3) symbolForSplit = substrSplitted.ElementAt(1).ToString();

            //                        var temp = substrSplitted.Split(symbolForSplit);

            //                        mathObj.Number1 = !String.IsNullOrEmpty(temp.First()) ? Convert.ToDouble(temp.First()) : null;
            //                        mathObj.Number2 = Convert.ToDouble(temp.Last());

            //                        mathObj.Action = symbolForSplit switch
            //                        {
            //                            "+" => MathEvalAction.Addition,
            //                            "-" => MathEvalAction.Substraction,
            //                            "*" => MathEvalAction.Multiplication,
            //                            "/" => MathEvalAction.Division
            //                        };
            //                    }

            //                    objects.Add(mathObj);
            //                    expression = RemovePart(expression, firstOccurence, lastOccurence);
            //                }
            //            }

            //            do
            //            {
            //                if (expression.Contains('*') || expression.Contains('/'))
            //                {
            //                    var tuple = GetMathObjectWithHighPriority(expression);
            //                    objects.Add(tuple.Item1);

            //                    if (tuple.Item2 - tuple.Item3 != 0)
            //                        expression = RemovePart(expression, tuple.Item2, tuple.Item3);
            //                    else
            //                        expression = String.Empty;
            //                }
            //                else
            //                {
            //                    var tuple = GetMathObjectWithLowPriority(expression);
            //                    objects.Add(tuple.Item1);

            //                    if (tuple.Item2 - tuple.Item3 != 0)
            //                        expression = RemovePart(expression, tuple.Item2, tuple.Item3);
            //                    else
            //                        expression = String.Empty;
            //                }
            //            } while (expression != "");

            //            return objects;
            //        }

            //        private (MathEvaluatorObject, int, int) GetMathObjectWithLowPriority(string expression)
            //        {
            //            var mathObj = new MathEvaluatorObject();

            //            for (int i = 0; i < expression.Length; i++)
            //            {
            //                if (expression[i] == '+' || expression[i] == '-')
            //                {
            //                    if (expression[i] == '+') mathObj.Action = MathEvalAction.Addition;
            //                    else mathObj.Action = MathEvalAction.Substraction;

            //                    if (i - 1 <= 0 && i + 1 >= expression.Length)
            //                    {
            //                        mathObj.Number1 = null;
            //                        mathObj.Number2 = null;

            //                        return new(mathObj, i, i);
            //                    }

            //                    if (i - 1 < 0 || i + 2 >= expression.Length) // *4...  || *-4...
            //                    {
            //                        if (i + 1 == '-')
            //                        {
            //                            mathObj.Number1 = null;
            //                            mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);

            //                            return new(mathObj, i, i + 2);
            //                        }
            //                        else
            //                        {
            //                            mathObj.Number1 = null;
            //                            mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                            return new(mathObj, i, i + 1);
            //                        }


            //                    }
            //                    if (Char.IsDigit(expression[i - 1]) && Char.IsDigit(expression[i + 1]))
            //                    {
            //                        mathObj.Number1 = Char.GetNumericValue(expression[i - 1]);
            //                        mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                        return new(mathObj, i - 1, i + 1);
            //                    }
            //                    else
            //                        if (Char.IsDigit(expression[i - 2]) && Char.IsDigit(expression[i + 1]))
            //                    {
            //                        mathObj.Number1 = -Char.GetNumericValue(expression[i - 2]);
            //                        mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                        return new(mathObj, i - 2, i + 1);
            //                    }
            //                    else
            //                        if (Char.IsDigit(expression[i - 1]) && Char.IsDigit(expression[i + 2]))
            //                    {
            //                        mathObj.Number1 = Char.GetNumericValue(expression[i - 1]);
            //                        mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);
            //                        return new(mathObj, i - 1, i + 2);
            //                    }
            //                    else if (Char.IsDigit(expression[i - 2]) && Char.IsDigit(expression[i + 2]))
            //                    {
            //                        mathObj.Number1 = -Char.GetNumericValue(expression[i - 2]);
            //                        mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);
            //                        return new(mathObj, i - 2, i + 2);
            //                    }
            //                }
            //            }
            //            return new(default, default, default);
            //        }

            //        private (MathEvaluatorObject, int, int) GetMathObjectWithHighPriority(string expression)
            //        {
            //            var mathObj = new MathEvaluatorObject();

            //            for (int i = 0; i < expression.Length; i++)
            //            {
            //                if (expression[i] == '*' || expression[i] == '/')
            //                {
            //                    if (expression[i] == '*') mathObj.Action = MathEvalAction.Multiplication;
            //                    else mathObj.Action = MathEvalAction.Division;

            //                    if (i - 1 <= 0 && i + 1 >= expression.Length)
            //                    {
            //                        mathObj.Number1 = null;
            //                        mathObj.Number2 = null;

            //                        return new(mathObj, i, i);
            //                    }

            //                    if (i - 1 < 0 || i + 2 >= expression.Length) // *4...  || *-4...
            //                    {
            //                        if (i + 1 == '-')
            //                        {
            //                            mathObj.Number1 = null;
            //                            mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);

            //                            return new(mathObj, i, i + 2);
            //                        }
            //                        else
            //                        {
            //                            mathObj.Number1 = null;
            //                            mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                            return new(mathObj, i, i + 1);
            //                        }


            //                    }
            //                    if (Char.IsDigit(expression[i - 1]) && Char.IsDigit(expression[i + 1]))
            //                    {
            //                        mathObj.Number1 = Char.GetNumericValue(expression[i - 1]);
            //                        mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                        return new(mathObj, i - 1, i + 1);
            //                    }
            //                    else
            //                        if (Char.IsDigit(expression[i - 2]) && Char.IsDigit(expression[i + 1]))
            //                    {
            //                        mathObj.Number1 = -Char.GetNumericValue(expression[i - 2]);
            //                        mathObj.Number2 = Char.GetNumericValue(expression[i + 1]);
            //                        return new(mathObj, i - 2, i + 1);
            //                    }
            //                    else
            //                        if (Char.IsDigit(expression[i - 1]) && Char.IsDigit(expression[i + 2]))
            //                    {
            //                        mathObj.Number1 = Char.GetNumericValue(expression[i - 1]);
            //                        mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);
            //                        return new(mathObj, i - 1, i + 2);
            //                    }
            //                    else if (Char.IsDigit(expression[i - 2]) && Char.IsDigit(expression[i + 2]))
            //                    {
            //                        mathObj.Number1 = -Char.GetNumericValue(expression[i - 2]);
            //                        mathObj.Number2 = -Char.GetNumericValue(expression[i + 2]);
            //                        return new(mathObj, i - 2, i + 2);
            //                    }
            //                }
            //            }
            //            return new(default, default, default);
            //        }

            //        private string RemovePart(string str, int ind1, int ind2)
            //        {
            //            return str.Remove(ind1, GetSubString(str, ind1, ind2).Length + 2);
            //        }
            //        private string GetSubString(string str, int ind1, int ind2)
            //        {
            //            return str.Substring(ind1 + 1, ind2 - ind1 - 1);
            //        }
            //        private int GetIndexOfFirstSymbolFromTheBeginning(string str, char symbol)
            //        {
            //            return str.IndexOf(symbol);
            //        }

            //        private int GetIndexOfFirstSymbolFromTheEnd(string str, char symbol)
            //        {
            //            return str.LastIndexOf(symbol);
            //        }

            //        private bool ParenthesisExistanceBetweenIndexex(string str, int ind1, int ind2)
            //        {
            //            var substr = GetSubString(str, ind1, ind2);

            //            if (substr.Contains('(')) return true;

            //            else return false;

            //        }
            //        public List<MathEvaluatorObject> GetResult()
            //        {
            //            return parsedExpression;
            //        }
            //    }

            //    private static double Addition(double d1, double d2)
            //    {
            //        return d1 + d2;
            //    }

            //    private static double Multiplication(double d1, double d2)
            //    {
            //        return d1 * d2;
            //    }

            //    private static double Division(double d1, double d2)
            //    {
            //        return d1 / d2;
            //    }

            //    private static double Substraction(double d1, double d2)
            //    {
            //        return d1 - d2;
            //    }
            //}


            //public static double Solve(string expression)
            //{
            //    var evaluator = new MathEvaluator(expression);

            //    return evaluator.GetResult();
            //}
        }
    }
}
