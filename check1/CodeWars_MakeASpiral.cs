using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static check1.Program;

namespace check1
{
    internal class CodeWars_MakeASpiral
    {
        public class Coordinate
        {
            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Coordinate(Coordinate coord)
            {
                this.x = coord.x;
                this.y = coord.y;
            }

            public int x { get; set; }
            public int y { get; set; }
        }
        public static class Movement
        {
            public static List<Coordinate> MoveRightFromLeft(Coordinate start, int steps, int addsOnLayers, int innerLayer)
            {
                var list = new List<Coordinate>();

                for (int i = addsOnLayers + innerLayer; i < steps; i++)
                {
                    list.Add(new Coordinate(start.x,i));
                }

                return list;
            }
            public static List<Coordinate> MoveLeftFromRight(Coordinate start, int steps, int addsOnLayers, int innerLayer)
            {
                var list = new List<Coordinate>();

                for (int i = steps - 2; i >= addsOnLayers + innerLayer; i--)
                {
                    list.Add(new Coordinate(start.x, i));
                }

                return list;
            }
            public static List<Coordinate> MoveTopFromBottom(Coordinate start, int steps, int addsOnLayers, int innerLayer)
            {
                var list = new List<Coordinate>();              

                for (int i = steps - 2; i > addsOnLayers + innerLayer; i--)
                {
                    list.Add(new Coordinate(i, start.y));
                }

                return list;
            }
            public static List<Coordinate> MoveBottomFromTop(Coordinate start, int steps, int addsOnLayers, int innerLayer)
            {
                var list = new List<Coordinate>();

                for (int i = addsOnLayers+innerLayer; i < steps; i++)
                {
                    list.Add(new Coordinate(i, start.y));
                }

                return list;
            }
        }

        public static int[,] GetSpiralArray(int size)
        {
            int[,] array = new int[size, size];

            List<Coordinate> visited = new List<Coordinate>();

            var startCoordinate = new Coordinate(0, 0);

            FillArrayWithZeroes(array);
            GetAllCoordinates(size, visited, startCoordinate);
            CheckIfDevidesBy6(size, visited);

            foreach (var item in visited)
            {
                array[item.x, item.y] = 1;
            }

            var coords = GenerateFixCoordinates(size);

            foreach (var item in coords)
            {
                array[item.x, item.y] = 1;
            }

            return array;
        }

        private static void CheckIfDevidesBy6(int size, List<Coordinate> visited)
        {
            int counterInside = 6;

            while (counterInside < size)
            {
                counterInside += 4;
            }

            if (counterInside == size)
            {
                visited.Remove(visited.Last());
            }
        }

        private static void GetAllCoordinates(int size, List<Coordinate> visited, Coordinate startCoordinate)
        {
            int ycounter = 0; int innerLayer = 0;

            for (int layer = 0; layer < size; layer += 2)
            {
                startCoordinate.x = layer;
                startCoordinate.y = ycounter;

                visited.AddRange(Movement.MoveRightFromLeft(startCoordinate, size - layer, ycounter, innerLayer));
                visited.AddRange(Movement.MoveBottomFromTop(visited.Last(), size - layer, ycounter + 1, innerLayer));
                visited.AddRange(Movement.MoveLeftFromRight(visited.Last(), size - layer, ycounter, innerLayer));
                visited.AddRange(Movement.MoveTopFromBottom(visited.Last(), size - layer, ycounter + 1, innerLayer));

                ycounter++; innerLayer++;
            }
        }

        private static void FillArrayWithZeroes(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = 0;
                }
                
            }
        }
        private static List<Coordinate> GenerateFixCoordinates(int size)
        {
            var list = new List<Coordinate>();

            int count = 0;
           
            do
            {
                size -= 4;
                count++;
            } 
            while (size > 4);

            if (count == 1)
            {
                list.Add(new Coordinate(2, 1));
            }
            else
            {
                list.Add(new Coordinate(2, 1));
                for (int i = 1; i < count; i++)
                {
                    list.Add(new Coordinate(list.Last().x + 2, list.Last().y + 2));
                }
            }
            return list;
        }

        public static void PrintArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(" " + arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
