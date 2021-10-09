using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board // Sets up the board
    {
        public Board()
        {
            // Hit marking board
            Horizontal(0, 0, 2, "|", 20, 54);
            Vertical(0, 1, 2, "-", 20, 51);
            Coordinates(1, 0, 53, 22, 4, 2);

            // Playing board
            Horizontal(0, 24, 2, "|", 44, 54);
            Vertical(0, 25, 2, "-", 47, 51);
            Coordinates(1, 24, 53, 45, 4, 2);

            // Center Title Box
            Box(0, 21, 0, 52, 23, "-", "|");

            Console.SetCursorPosition(18, 22);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Battleship v.1.0");
        }

        public void DrawShips(Dictionary<string, List<List<int>>> Ships)
        {
            int x = 0;
            int y = 0;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < Ships.Count; i++)
            {
                var element = Ships.ElementAt(i);
                var Key = element.Key;
                var Value = element.Value;

                if(Value[0].Capacity == 1)
                {
                    foreach(int xEntry in Value[0])
                    {
                        foreach(int yEntry in Value[1])
                        {
                            Console.SetCursorPosition(xEntry, yEntry);
                            Console.Write("X");
                        }
                    }
                }

                else if(Value[0].Capacity != 1)
                {
                    foreach (int yEntry in Value[0])
                    {
                        foreach (int xEntry in Value[1])
                        {
                            Console.SetCursorPosition(yEntry, xEntry);
                            Console.Write("X");
                        }
                    }
                }
            }
        }

        public static void Coordinates(int x, int y, int xMax, int yMax, int xInterval, int yInterval) // Draws the letters at the top and the numbers on the side
        {
            Console.ForegroundColor = ConsoleColor.White;

            // Loop for placing the letters
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int num = 0;
            for (int i = x; i < xMax; i += xInterval)
            {
                Console.SetCursorPosition(i, y);
                Console.WriteLine(chars[num] + " " + chars[num += 1]);
                num += 1;
            }

            // Loop for placing numbers
            num = 0;
            for (int j = y + yInterval; j < yMax; j += yInterval)
            {
                num += 1;
                Console.SetCursorPosition(xMax, j);
                Console.WriteLine(num);
            }
        }

        public static void Horizontal(int x, int y, int interval, string wallV, int bottom, int end) // Draws the vertical part of the grid going up and down
        {
            int NewY = y;

            while (true)
            {
                Console.SetCursorPosition(x, NewY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(wallV);

                if (x >= end)
                {
                    Console.SetCursorPosition(x, NewY);
                    Console.WriteLine(" ");
                    break;
                }

                NewY++;
                if (NewY > bottom)
                {
                    x += interval;
                    NewY = y;
                }
            }
        }

        public static void Vertical(int x, int y, int interval, string wallH, int bottom, int end) // Draws the horizontal part of the grid going left to right
        {
            int NewX = x;

            while (true)
            {
                Console.SetCursorPosition(NewX, y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(wallH);

                if (y >= bottom)
                {
                    Console.SetCursorPosition(NewX, y);
                    Console.WriteLine(" ");
                    break;
                }

                NewX++;
                if (NewX > end)
                {
                    y += interval;
                    NewX = x;
                }
            }
        }

        public static void Box(int x, int y, int xMin, int xMax, int yMax, string top, string wall) // Draws a box using the specified coords
        {
            Console.ForegroundColor = ConsoleColor.White;

            // Draws the top and bottom
            for (int i = x; i < xMax + 1; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(top);

                Console.SetCursorPosition(i, yMax);
                Console.Write(top);
            }

            // Draws the walls
            for (int j = x; j <= xMax; j++)
            {
                if (j == xMin || j == xMax)
                {
                    Console.SetCursorPosition(j, y + 1);
                    Console.Write(wall);
                }
                else
                {
                    Console.SetCursorPosition(j, y + 1);
                    Console.Write(" ");
                }
            }
        }
    }
}
