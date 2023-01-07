using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_RailFenceCipher
    {
        public abstract class EncodeSupportMethods
        {
            public abstract void SetLevels(int amountOfLevels);
        }

        public class Level
        {
            public Level(int firstPosition, int secondPosition)
            {
                this.firstPosition = firstPosition;
                this.secondPosition = secondPosition;
            }

            protected int firstPosition { get; set; }
            protected int secondPosition { get; set; }

            public int GetFirst()
            {
                return firstPosition;
            }

            public int GetSecond()
            {
                return secondPosition;
            }
        }

        public class Encoding : EncodeSupportMethods
        {
            protected List<Level> defaultLevels2 = new List<Level>() { new Level(1, 1), new Level(1, 1) };
            protected List<Level> defaultLevels3 = new List<Level>() { new Level(3, 3), new Level(1, 1), new Level(3, 3) };

            internal List<Level> levels;

            public string EncodeString(string stringToEncode)
            {
                var tempList = new List<string>();

                int counter = 0;
                foreach (var item in levels)
                {
                    tempList.Add(GetPieceOfString(stringToEncode, item, counter));
                    counter++;
                }

                return string.Join("", tempList);
            }

            private string GetPieceOfString(string str, Level level, int startingPos)
            {
                List<char> result = new List<char>();

                var first = level.GetFirst();
                var second = level.GetSecond();

                if (first == second)
                {
                    for (int i = startingPos; i < str.Length; i += (first + 1))
                    {
                        result.Add(str[i]);
                    }

                }
                else
                {
                    int lastStep = first;
                    for (int i = startingPos; i <= str.Length;)
                    {
                        if (i >= str.Length)
                            break;

                        result.Add(str[i]);

                        if (lastStep == first)
                        {
                            i += first + 1; lastStep = second; continue;
                        }
                        if (lastStep == second)
                        {
                            i += second + 1; lastStep = first; continue;
                        }
                    }
                }

                return string.Join("", result);
            }
            public override void SetLevels(int amountOfLevels)
            {
                levels = new List<Level>();

                if (amountOfLevels == 2)
                {
                    levels = defaultLevels2;
                }
                else if (amountOfLevels == 3)
                {
                    levels = defaultLevels3;
                }
                else
                {
                    levels = GetLevels(amountOfLevels);
                }
            }

            private List<Level> GetLevels(int neededDeep)
            {
                var tempLevels = new List<Level>();

                var firstLevel = ((neededDeep - 2) * 2) + 1;

                tempLevels.Add(new Level(firstLevel, firstLevel));

                var lvlCounter = firstLevel; int j = 1;

                for (int i = 1; j <= firstLevel - 2; i++)
                {
                    lvlCounter = lvlCounter - 2;
                    tempLevels.Add(new Level(lvlCounter, j));
                    j += 2;
                }

                tempLevels.Add(new Level(firstLevel, firstLevel));

                return tempLevels;
            }
        }

        public class Decoding
        {
            internal Queue<Level> levels;
            public Decoding(List<Level> levels1)
            {
                levels = new Queue<Level>(levels1);
            }
            private char[,] GetMatrix(string stringToDecode, int key)
            {
                var strLength = stringToDecode.Length;

                var matrix = new char[key, strLength];

                for (int i = 0; i < key; i++)
                {
                    for (int j = 0; j < strLength; j++)
                    {
                        matrix[i, j] = '\n';
                    }
                }

                int rows, cols = 0; int counter = 0;

                for (cols = 0; cols < key; cols++)
                {
                    var theLevel = levels.Dequeue();
                    var firstStep = theLevel.GetFirst();
                    var secondStep = theLevel.GetSecond();

                    int move = firstStep;

                    for (rows = cols; rows < strLength;)
                    {
                        matrix[cols, rows] = stringToDecode[counter];

                        if (move == firstStep)
                        {
                            move = secondStep;
                            rows += firstStep + 1;
                        }
                        else
                        {
                            move = firstStep;
                            rows += secondStep + 1;
                        }
                        counter++;
                    }

                }

                return matrix;
            }
            public string Decode(string stringToDecode, int key)
            {
                var decodedMessage = new StringBuilder();

                var matrix = GetMatrix(stringToDecode, key);

                bool wasFlag = false;
                for (int i = 0, j = 0; j < stringToDecode.Length; j++)
                {
                    decodedMessage.Append(matrix[i, j]);

                    if (i+1 == key)
                    {
                        wasFlag = true;
                    }
                    if (wasFlag && i - 1 != -1)
                        i--;
                    else
                    if (i - 1 < 0)
                    {
                        i++;
                        wasFlag = false;
                    }
                    else
                    {
                        i++;
                    }
                    
                }

                return decodedMessage.ToString();
            }
        }
        public static string Encode(string s, int n)
        {
            Encoding encoding = new Encoding();
            encoding.SetLevels(n);
            var encodedString = encoding.EncodeString(s);

            return encodedString;
        }

        public static string Decode(string s, int n)
        {
            var encoding = new Encoding();
            encoding.SetLevels(n);

            var decoding = new Decoding(encoding.levels);
            var decodedString = decoding.Decode(s, n);

            return decodedString;
        }
    }
}
