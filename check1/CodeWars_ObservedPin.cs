using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace check1
{
    public class CodeWars_ObservedPin
    {
        public class Numbers : IEnumerable<Number>
        {
            List<Number> numbers;

            public Numbers(string number)
            {
                this.numbers = new List<Number>();

                foreach (var item in number)
                {
                    numbers.Add(new Number((int)Char.GetNumericValue(item), false));
                }
            }

            public override int GetHashCode()
            {
                int temp = 1;

                foreach (var item in numbers)
                {
                    temp = (17 + temp) * (item.GetNumber() + 23);
                }

                return temp;
            }

            public override bool Equals(object obj)
            {
                Numbers other = obj as Numbers;

                for (int i = 0; i < other.numbers.Count(); i++)
                {
                    if (other.numbers[i].GetNumber() != this.numbers[i].GetNumber())
                        return false;
                }

                return true;
            }

            public Numbers(Number[] number)
            {
                this.numbers = number.ToList();
            }

            public IEnumerator GetEnumerator()
            {
                return numbers.GetEnumerator();
            }

            public Number GetNumber(int position)
            {
                return numbers.ElementAtOrDefault(position);
            }

            IEnumerator<Number> IEnumerable<Number>.GetEnumerator()
            {
                return (IEnumerator<Number>)GetEnumerator();
            }

            private static Numbers GetReplacedNumber(int position, Numbers number, Number valueToswap)
            {
                var tmp = new Number[number.numbers.Count()];
                number.numbers.CopyTo(tmp);
                valueToswap.SetChangedState(true);
                tmp[position] = valueToswap;

                return new Numbers(tmp);
            }


            public static HashSet<Numbers> GetSwappedNumbersUsingPairInSpecificPosition(int position, Numbers numberToSwap)
            {
                var result = new HashSet<Numbers>();

                var pair = pairs.GetValueOrDefault(numberToSwap.numbers[position].GetNumber());

                foreach (var item in pair.GetElements())
                {
                    if (numberToSwap.numbers[position].GetStage() == false)
                    {
                        result.Add(GetReplacedNumber(position, numberToSwap, item));
                    }
                }

                return result;
            }
        }
        public struct Number
        {
            int number;
            bool wasChanged;

            public Number(int number, bool wasChanged)
            {
                this.number = number;
                this.wasChanged = wasChanged;
            }

            public void SetChangedState(bool state)
            {
                this.wasChanged = state;
            }
            public int GetNumber()
            {
                return number;
            }
            public bool GetStage()
            {
                return wasChanged;
            }
        }

        public class Pair
        {
            public Pair(Number a, Number? b = null, Number? c = null, Number? d = null)
            {
                this.pairs = new Tuple<Number, Number?, Number?, Number?>(a, b, c, d);
            }

            private Tuple<Number, Number?, Number?, Number?> pairs;

            public List<Number> GetElements()
            {
                var list = new List<Number>();

                list.Add(pairs.Item1);

                if (pairs.Item2.HasValue)
                    list.Add(pairs.Item2.Value);

                if (pairs.Item3.HasValue)
                    list.Add(pairs.Item3.Value);

                if (pairs.Item4.HasValue)
                    list.Add(pairs.Item4.Value);

                return list;
            }
        }

        private static Dictionary<int, Pair> pairs = new Dictionary<int, Pair>()
        {
            [1] = new Pair(new Number(2, false), new Number(4, false)),
            [2] = new Pair(new Number(1, false), new Number(5, false), new Number(3, false)),
            [3] = new Pair(new Number(2, false), new Number(6, false)),
            [4] = new Pair(new Number(1, false), new Number(5, false), new Number(7, false)),
            [5] = new Pair(new Number(2, false), new Number(4, false), new Number(6, false), new Number(8, false)),
            [6] = new Pair(new Number(3, false), new Number(5, false), new Number(9, false)),
            [7] = new Pair(new Number(4, false), new Number(8, false)),
            [8] = new Pair(new Number(7, false), new Number(5, false), new Number(9, false), new Number(0, false)),
            [9] = new Pair(new Number(6, false), new Number(8, false)),
            [0] = new Pair(new Number(8, false))
        };


        private static HashSet<Numbers> GetAllChanged(Numbers number)
        {
            var temp = new HashSet<Numbers>();
            int count = 0;

            foreach (Number item in number)
            {
                temp.UnionWith(Numbers.GetSwappedNumbersUsingPairInSpecificPosition(count, number));
                count++;
            }

            return temp;
        }
        private static List<string> GetPinsAsStrings(HashSet<Numbers> list)
        {
            var ls = new List<string>();
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                foreach (Number it in item)
                {
                    sb.Append(it.GetNumber());
                }
                ls.Add(sb.ToString());
                sb.Clear();
            }

            return ls;
        }

        public static List<string> GetPINs(string observed)
        {
            if (observed.Count() == 0)
                return null;

            var observedPin = new Numbers(observed);

            var temp = GetAllChanged(observedPin);

            var length = observed.Length;

            if (length >= 4) length = length / 2 + 2;

            for (int i = 0; i <= length; i++)
            {
                foreach (var item in temp.ToList())
                {
                    temp.UnionWith(GetAllChanged(item));
                }
            }

            temp.Add(observedPin);
            return GetPinsAsStrings(temp);
        }

    }


    public class CheckMe
    {
        public static List<string> GetCombination(List<string> left, List<string> right)
        {
            var result = new List<string>();

            for (int l = 0; l < left.Count(); ++l)
            {
                for (int r = 0; r < right.Count(); ++r)
                {
                    result.Add(left[l] + right[r]);
                }
            }

            return result;
        }
        
        public static List<List<string>> pairs = new List<List<string>>() //0-9
      { new List<string>() { "0", "8"},
      { new List<string>() {"1", "2", "4"} },
      { new List<string>() {"1", "2", "3", "5"} },
      { new List<string>() {"2", "3", "6"} },
      { new List<string>() {"1", "4", "5", "7"} },
      { new List<string>() {"2", "4", "5", "6", "8"} },
      { new List<string>() {"3", "5", "6", "9"} },
      { new List<string>() {"4", "7", "8"} },
      { new List<string>() {"0", "5", "7", "8", "9"} },
      { new List<string>() {"6", "8", "9"} } };

        public static List<string> GetPINs(string observed)
        {
            if (observed.Count() == 0)
                return null;

            List<string> result = pairs[(int)char.GetNumericValue(observed[0])];  //==  /*observed[0] - '0'*/ 
            
            for (int i = 1; i < observed.Count(); ++i)
            {
                result = GetCombination(result, pairs[(int)char.GetNumericValue(observed[i])]);
            }

            return result;
        }

    }

    public class CheckMe2
    {
        public static List<string> GetPINs(string s) =>
       new[] { "08", "124", "1235", "236", "1457", "24568", "3569", "478", "57890", "689" }[s[0] - '0']
       .SelectMany(c => s.Length > 1 ? GetPINs(s.Substring(1)).Select(p => c + p) : new[] { "" + c }).ToList();
    }
}
