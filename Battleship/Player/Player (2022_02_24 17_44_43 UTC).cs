using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Player
{
    public class Player
    {
        public string name;

        private int xMin;
        private int xMax;
        private int yMin;
        private int yMax;
        private int interval;

        public ShipList shipList;

        public void setPlayer(string NAME, int XMIN, int XMAX, int YMIN, int YMAX, int INTERVAL)
        {
            name = NAME;

            xMin = XMIN;
            xMax = XMAX;
            yMin = YMIN;
            yMax = YMAX;
            interval = INTERVAL;

            shipList = new ShipList();
            shipList.setList(xMax, yMax);
        }

        // Add ships to shipList
        public void addShips(bool isAI)
        {
            shipList.addDestroyer();
            shipList.addSubmarine();
            shipList.addCruiser();
            shipList.addBattleship();
            shipList.addAircraftCarrier();

            for (int i = 0; i < shipList.ships.Count(); i++)
            {
                var element = shipList.ships.ElementAt(i);
                var value = element.Value;

                if(isAI)
                {
                    value.Orientation();
                    value.RandomizeCoords(value.xCOORDS, value.yCOORDS, xMin, xMax, yMin, yMax);
                }
                else
                    placeShip(value);
            }            
        }

        // Create grid for referencing ship placements
        public void createGrid()
        {
            for (int i = 0; i < shipList.ships.Count(); i++)
            {
                var element = shipList.ships.ElementAt(i);
                var value = element.Value;

                // Row and column iterators
                for (int row = 0; row != xMax; row++)
                {
                    for (int column = 0; column != yMax; column++)
                    {
                        // Current x and y value iterators
                        for (int j = 0; j < value.xCOORDS.Count(); j++)
                        {
                            for (int k = 0; k < value.yCOORDS.Count(); k++)
                            {
                                if (row == value.xCOORDS[j] && column == value.yCOORDS[k])
                                    shipList.grid[row, column] = 1;
                            }
                        }
                    }
                }
            }
        }

        // Print grid to screen
        public void printGrid()
        {
            // Row and column iterators
            for (int row = 0; row != xMax; row++)
            {
                for (int column = 0; column != yMax; column++)
                {
                    Console.SetCursorPosition(row, column);
                    Console.Write(shipList.grid[row, column]);
                }
            }
        }

        // Print ship's coords and status to screen
        public void printList(int startX, int startY)
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Print ship coords
            for (int i = 0; i < shipList.ships.Count; i++)
            {
                var element = shipList.ships.ElementAt(i);
                var value = element.Value;
                var key = element.Key;

                Console.SetCursorPosition(startX, startY);
                Console.Write(key + ": ");

                // Print x-values
                for (int j = 0; j < value.xCOORDS.Count; j++)
                {
                    if (value.xCOORDS.Count == 1)
                        Console.Write((value.xCOORDS[j] + count) + " / ");
                    else
                        Console.Write((value.xCOORDS[j] + count) + " ");

                    count += interval;
                }

                // Print y-values
                for (int k = 0; k < value.yCOORDS.Count; k++)
                {
                    if (value.yCOORDS.Count == 1)
                        Console.Write(" / " + (value.yCOORDS[k] + count));
                    else
                        Console.Write((value.yCOORDS[k] + count) + " ");

                    count += interval;
                }

                // Print isSunk and isPlaced bools
                Console.SetCursorPosition(startX + 43, 0);
                Console.Write("Sunk:   Placed: ");

                Console.SetCursorPosition(startX + 40, startY);
                Console.Write("   " + value.isSunk + "   " + value.isPlaced);

                startY++;
            }
        }

        // Draw ships to screen
        public void drawShips(ShipList shipList)
        {
            int x = 0;
            int y = 0;
            int count = 0;

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < shipList.ships.Count(); i++)
            {
                var element = shipList.ships.ElementAt(i);
                var value = element.Value;

                foreach (int xEntry in value.xCOORDS)
                {
                    foreach (int yEntry in value.yCOORDS)
                    {
                        // Fix cursorPos for interval
                        Console.SetCursorPosition((xEntry), (yEntry));

                        if(value.isSunk)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("0");
                        }
                    }
                }
            }
        }



        // Allows player to set ship and save coords to that ship
            // For placing ships:
                // [Arrow Keys] move around board according to interval
                    // Else, prevent movement onto pos with ship placed
                // [ENTER] place ship
                    // Check if ship already in same pos (overlap detection)
                        // If so, display error message
        public void placeShip(Ship ship)
        {
            int x;
            int y;
            int count;

            bool isFinished = false;
            bool rot = false;

            ConsoleKeyInfo input;
            x = xMin;
            y = yMin;
            count = 0;

            while (isFinished == false)
            {
                Console.SetCursorPosition(x, y);
                input = Console.ReadKey();

                switch (input.Key)
                {
                    // Move ship: Up, Down, Left, Right
                    case ConsoleKey.UpArrow:
                        // y - 1
                        if ((y - interval) < yMin)
                            y = yMax;
                        else
                            y -= interval;
                        break;
                    case ConsoleKey.DownArrow:
                        // y + 1
                        if ((y + interval) > yMax)
                            y = yMin;
                        else
                            y += interval;
                        break;
                    case ConsoleKey.LeftArrow:
                        // x - 1
                        if ((x - interval) < xMin)
                            x = xMax;
                        else
                            x -= interval;
                        break;
                    case ConsoleKey.RightArrow:
                        // x + 1
                        if ((x + interval) > xMax)
                            x = xMin;
                        else
                            x += interval;
                        break;

                    // Rotate ship
                    case ConsoleKey.Spacebar:
                        // orientation = H/V
                        if (rot == false)
                        {
                            ship.orientation = "H";
                            rot = true;
                        }
                        else if (rot == true)
                        {
                            ship.orientation = "V";
                            rot = false;
                        }
                        Console.SetCursorPosition(100, 10);
                        Console.Write("Current rot: " + ship.orientation);
                        break;

                    // Place ship
                    case ConsoleKey.Enter:
                        // Set ship's values
                        if (ship.orientation == "V")
                        {
                            ship.xCOORDS = new List<int>(1);
                            ship.yCOORDS = new List<int>(ship.hitSpaces);

                            ship.xCOORDS.Add(x);

                            for (int i = 0; i < ship.yCOORDS.Capacity; i++)
                            {
                                ship.yCOORDS.Add(y + count);
                                count++;
                            }
                        }

                        else if (ship.orientation == "H")
                        {
                            ship.xCOORDS = new List<int>(ship.hitSpaces);
                            ship.yCOORDS = new List<int>(1);

                            for (int i = 0; i < ship.xCOORDS.Capacity; i++)
                            {
                                ship.xCOORDS.Add(x + count);
                                count++;
                            }

                            ship.yCOORDS.Add(y);
                        }

                        ship.isPlaced = true;
                        isFinished = true;
                        break;
                } // end switch
            } // end while
        }



        // Take single values (x/y) and search for same value amongst rest
        // Compare the same value pairs and determine if they intersect/overlap
        // If intersect/overlap, randomize values again
        // overlapDetection until good

        public void overlapDetection(ShipList shipList, bool isAI)
        {
            // Take first ship's (x,y) values, compare to other ships until all have be cycled through
            // Repeat until the final - 1 ship's values are calculated

            int currentX = 0;
            int currentY = 0;

            int nextX = 0;
            int nextY = 0;

            List<int> currentXValues = new List<int>();
            List<int> currentYValues = new List<int>();

            List<int> nextXValues = new List<int>();
            List<int> nextYValues = new List<int>();



            for (int i = 0; i < shipList.ships.Count() - 1; i++)
            {
                // Get current values
                var element = shipList.ships.ElementAt(i);
                var value = element.Value;

                currentXValues = value.xCOORDS;
                currentYValues = value.yCOORDS;


                for (int j = i + 1; j < shipList.ships.Count(); j++)
                {
                    // Get next values
                    element = shipList.ships.ElementAt(j);
                    value = element.Value;

                    nextXValues = value.xCOORDS;
                    nextYValues = value.yCOORDS;

                    for (int k = 0; k < currentXValues.Count(); k++)
                    {
                        for (int l = 0; l < currentYValues.Count(); l++)
                        {
                            // Assign current x/y values
                            currentX = currentXValues[k];
                            currentY = currentYValues[l];

                            for (int m = 0; m < nextXValues.Count(); m++)
                            {
                                for (int n = 0; n < nextYValues.Count(); n++)
                                {
                                    // Assign next x/y values
                                    nextX = nextXValues[m];
                                    nextY = nextYValues[n];

                                    // if the currentX is equal to x while the currentY is equal to y (vertex overlap):
                                    // reshuffle coords of current ship
                                    if ((currentX == nextX) && (currentY == nextY))
                                    {
                                        shipList.removeShip(i);

                                        switch (i)
                                        {
                                            case 0:
                                                shipList.addDestroyer();
                                                break;
                                            case 1:
                                                shipList.addSubmarine();
                                                break;
                                            case 2:
                                                shipList.addCruiser();
                                                break;
                                            case 3:
                                                shipList.addBattleship();
                                                break;
                                            case 4:
                                                shipList.addAircraftCarrier();
                                                break;
                                        }

                                        element = shipList.ships.ElementAt(i);
                                        value = element.Value;

                                        if (isAI)
                                        {
                                            value.Orientation();
                                            value.RandomizeCoords(value.xCOORDS, value.yCOORDS, xMin, xMax, yMin, yMax);
                                        }
                                        else
                                            placeShip(value);

                                    } // end if
                                } // end for
                            } // end for
                        } // end for
                    } // end for
                } // end for
            } // end for
        }
    }
}
