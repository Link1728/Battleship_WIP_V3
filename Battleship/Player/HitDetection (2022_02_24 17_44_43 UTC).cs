using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class hitDetection // Determines whether the guess hit a part of the enemy ship and if it sunk or not
    {
        public static int CurrentX = 0;
        public static int CurrentY = 0;

        public static void CheckCoords(string playerCoordLetter, string playerCoordNumber) // Determines the correct position for the player's inputted coords
        {
            int x = 0;
            int y = 0;

            #region CoordLetter
            switch(playerCoordLetter)
            {
                case "A":
                    x = 1;
                    break;
                case "B":
                    x = 2;
                    break;
                case "C":
                    x = 3;
                    break;
                case "D":
                    x = 4;
                    break;
                case "E":
                    x = 5;
                    break;
                case "F":
                    x = 6;
                    break;
                case "G":
                    x = 7;
                    break;
                case "H":
                    x = 8;
                    break;
                case "I":
                    x = 9;
                    break;
                case "J":
                    x = 10;
                    break;
                case "K":
                    x = 11;
                    break;
                case "L":
                    x = 12;
                    break;
                case "M":
                    x = 13;
                    break;
                case "N":
                    x = 14;
                    break;
                case "O":
                    x = 15;
                    break;
                case "P":
                    x = 16;
                    break;
                case "Q":
                    x = 17;
                    break;
                case "R":
                    x = 18;
                    break;
                case "S":
                    x = 19;
                    break;
                case "T":
                    x = 20;
                    break;
                case "U":
                    x = 21;
                    break;
                case "V":
                    x = 22;
                    break;
                case "W":
                    x = 23;
                    break;
                case "X":
                    x = 24;
                    break;
                case "Y":
                    x = 25;
                    break;
                case "Z":
                    x = 26;
                    break;
                default:
                    Console.Write("Cannot accept input. Try again.");
                    break;
            }
            #endregion

            #region CoordNumber
            switch(playerCoordNumber)
            {
                case "1":
                    y = 1;
                    break;
                case "2":
                    y = 2;
                    break;
                case "3":
                    y = 3;
                    break;
                case "4":
                    y = 4;
                    break;
                case "5":
                    y = 5;
                    break;
                case "6":
                    y = 6;
                    break;
                case "7":
                    y = 7;
                    break;
                case "8":
                    y = 8;
                    break;
                case "9":
                    y = 9;
                    break;
                case "10":
                    y = 10;
                    break;
                case "11":
                    y = 11;
                    break;
                case "12":
                    y = 12;
                    break;
                case "13":
                    y = 13;
                    break;
                case "14":
                    y = 14;
                    break;
                case "15":
                    y = 15;
                    break;
                case "16":
                    y = 16;
                    break;
                case "17":
                    y = 17;
                    break;
                case "18":
                    y = 18;
                    break;
                case "19":
                    y = 19;
                    break;
                case "20":
                    y = 20;
                    break;
                default:
                    Console.Write("Cannot accept input. Try again.");
                    break;
            }
            #endregion

            CurrentX = x;
            CurrentY = y;

            Console.SetCursorPosition(x, y);

            // return if hit connected, ie true/false
        }

        public void checkHit()
        {

        }
    }
}
