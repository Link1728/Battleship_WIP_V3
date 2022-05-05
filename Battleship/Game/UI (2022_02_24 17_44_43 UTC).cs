using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class UI
    {
        public static string playerCoordLetter = " ";
        public static string playerCoordNumber = " ";


        public static void Key()
        {

        }

        public static void Input() // Displays the prompt and takes the player's input
        {
            Console.SetCursorPosition(65, 11);
            Console.Write("  ");
            Console.SetCursorPosition(65, 12);
            Console.Write("  ");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(57, 10);
            Console.WriteLine("Guess:");

            Console.SetCursorPosition(57, 11);
            Console.Write("Letter: ");
            playerCoordLetter = Console.ReadLine();

            Console.SetCursorPosition(57, 12);
            Console.Write("Number: ");
            playerCoordNumber = Console.ReadLine();

            hitDetection.CheckCoords(playerCoordLetter, playerCoordNumber);
        }

        public void gameFeed()
        {

        }

        public void Menu()
        {

        }

    }
}
