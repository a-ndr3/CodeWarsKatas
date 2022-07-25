using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_SnailMatrix
    {
        public class Coordinates : IEquatable<Coordinates>
        {
            public int x { get; set; }
            public int y { get; set; }

            public override int GetHashCode()
            {
                return 14 * (x + 2) + 55 * (y + 1);
            }

            public override bool Equals(object obj)
            {
                return obj is Coordinates && Equals((Coordinates)obj);
            }

            public bool Equals(Coordinates p)
            {
                return x == p.x && y == p.y;
            }

        }

        public static void GetCoordinatesRowsForward(int[][] array, HashSet<Coordinates> coordinates, int row)
        {
            for (int i = 0; i < array.Length; i++)
            {
                coordinates.Add(new Coordinates { x = row, y = i });
            }
        }

        public static void GetCoordinatesRowsBackward(int[][] array, HashSet<Coordinates> coordinates, int row)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                coordinates.Add(new Coordinates { x = row, y = i });
            }
        }

        public static void GetCoordinatesColumnsForward(int[][] array, HashSet<Coordinates> coordinates, int col)
        {
            for (int i = 0; i < array.Length; i++)
            {
                coordinates.Add(new Coordinates { x = i, y = col });
            }
        }

        public static void GetCoordinatesColumnsBackward(int[][] array, HashSet<Coordinates> coordinates, int col)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                coordinates.Add(new Coordinates { x = i, y = col });
            }
        }

        public static int[] GetArrayFromCoordinates(int[][] array, HashSet<Coordinates> coordinates)
        {
            var tmp = new List<int>();
            foreach (var item in coordinates)
            {
                tmp.Add(array[item.x][item.y]);
            }
            return tmp.ToArray();
        }

        public static int[] Snail(int[][] array)
        {
            if (array.Length == 1)
            {
                if (array.ElementAt(0).Length == 0)
                {
                    return new int[] { };
                }
                else
                {
                    if (array.Length == 1)
                    {
                        return new int[1] { array.ElementAt(0)[0] };
                    }
                }
            }

            var coordinates = new HashSet<Coordinates>();

            var amountOfRows = array.Length - 1;

            for (int i = 0; i < amountOfRows; i++)
            {
                GetCoordinatesRowsForward(array, coordinates, i);
                GetCoordinatesColumnsForward(array, coordinates, amountOfRows - i);
                GetCoordinatesRowsBackward(array, coordinates, amountOfRows - i);
                GetCoordinatesColumnsBackward(array, coordinates, i);
            }

            return GetArrayFromCoordinates(array, coordinates);
        }
    }
}
