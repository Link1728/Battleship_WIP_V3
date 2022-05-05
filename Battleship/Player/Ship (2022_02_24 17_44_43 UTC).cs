using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public int hitSpaces;
        public string orientation;

        public List<int> xCOORDS;
        public List<int> yCOORDS;

        public bool isSunk;
        public bool isPlaced;

        private static readonly Random rnd = new Random();
        private static readonly object syncLock = new object();

        public Ship(int spaces, bool sunk, bool placed)
        {
            // orientation's base value is horizontal (H)
            orientation = "H";

            isSunk = sunk;
            isPlaced = placed;
            hitSpaces = spaces;

            xCOORDS = new List<int>(1);
            yCOORDS = new List<int>(1);
        }

        public void checkIfSunk()
        {
            if (isSunk)
            {
            }
            else
                isSunk = false;
        }



        public void Orientation()
        {
            Random rndA = new Random(Guid.NewGuid().GetHashCode());

            #region Random Orientation
            int x = 0;

            x = rndA.Next(11);

            if (x == 1 || x == 3 || x == 5 || x == 7 || x == 9)
                orientation = "H";
            else if (x == 0 || x == 2 || x == 4 || x == 6 || x == 8 || x == 10)
                orientation = "V";
            #endregion

            if (orientation == "V")
            {
                xCOORDS = new List<int>(1);
                yCOORDS = new List<int>(hitSpaces);
            }

            else if (orientation == "H")
            {
                xCOORDS = new List<int>(hitSpaces);
                yCOORDS = new List<int>(1);
            }
        }

        // Takes both xCoord and yCoord lists and creates random values
        public void RandomizeCoords(List<int> xValues, List<int> yValues, int xMin, int xMax, int yMin, int yMax)
        {
            int x = 0;
            int count = 0;

            List<int> xTemp = xValues;
            List<int> yTemp = yValues;

            /***** X-Values *****/
            #region X-Values Calculations

            if (xTemp.Capacity == 1) // Checks if the x list has one entry
            {
                x = RandomNumberOdd(xMin, xMax);

                while (true)
                {
                    if (x == xMax)
                        x = RandomNumberOdd(xMin, xMax);
                    else
                        break;
                }

                xTemp.Add(x);
            }

            else if (xTemp.Capacity > 1) // Checks if the x list has more than one entry
            {
                x = RandomNumberOdd(xMin, xMax);

                while (true)
                {
                    if (x == xMax || (x + xTemp.Capacity) > xMax)
                        x = RandomNumberOdd(xMin, xMax);
                    else
                        break;
                }

                for (int i = 0; i < xTemp.Capacity; i++)
                {
                    xTemp.Add(x + count);
                    count++;
                }
            }
            #endregion

            /***** Y-Values *****/
            #region Y-Values Calculations

            x = 0;
            count = 0;

            if (yTemp.Capacity == 1) // Checks if the y list has one entry
            {
                x = RandomNumberEven(yMin, yMax);

                while (true)
                {
                    if (x == yMin)
                        x = RandomNumberEven(yMin, yMax);
                    else
                        break;
                }

                yTemp.Add(x);
            }

            else if (yTemp.Capacity > 1) // Checks if the y list has more than one entry
            {
                x = RandomNumberEven(yMin, yMax);

                while (true)
                {
                    if (x == yMax || (x + yTemp.Capacity) > yMax)
                        x = RandomNumberEven(yMin, yMax);
                    else
                        break;
                }

                for (int i = 0; i < yTemp.Capacity; i++)
                {
                    yTemp.Add(x + count);
                    count++;
                }
            }

            #endregion

            isPlaced = true;
        }

        public static int RandomNumberEven(int min, int max) // Generates random even numbers within the specified range
        {
            int ans;

            lock (syncLock)
                ans = rnd.Next(min, max);

            if (ans % 2 == 0)
                return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }

        public static int RandomNumberOdd(int min, int max) // Generates random odd numbers within the specified range
        {
            int ans;

            lock (syncLock)
                ans = rnd.Next(min, max);

            if (ans % 2 == 1)
                return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }
    }
}
