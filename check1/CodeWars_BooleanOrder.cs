using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_BooleanOrder
    {
        public class Formula
        {
            public char first;
            public char sign;
            public char second;

            public Formula(char first, char sign, char second)
            {
                this.first = first;
                this.sign = sign;
                this.second = second;
            }
        }
        public class BooleanOrder
        {
            BigInteger result;
            public BooleanOrder(string operands, string operators)
            {
                result = CountArrangements(operands, operators);
            }

            public BigInteger Solve()
            {
                return result;
            }
            
            private BigInteger CountArrangements(string formula, string operators)
            {

                var query = from item1 in formula
                            from item2 in operators
                            from item3 in formula
                            select new Formula(item1,item2,item3);

                var size = query.Count() / formula.Length;

                var splitted = SplitIntoFromulas(query, size);

                return BigInteger.Zero;
            }

            private List<string> SplitIntoFromulas(IEnumerable<Formula> query, int size)
            {
                var list = new List<Formula>();
                var resultList = new List<List<Formula>>();

                int counter = 0;
                for (int i = 0; i < query.Count(); i++)
                {
                    if(counter == size)
                    {
                        resultList.Add(list);
                        list.Clear();
                        counter = 0;
                    }
                    list.Add(query.ElementAt(i));
                    counter++;
                }

                var result = resultList.SelectMany(x => x)
                       .Where((x, index) => index % 5 == 0).Select(x => string.Format("{0}{1}{2}", x.first, x.sign, x.second));

                return null;

            }
        }
    }
}
