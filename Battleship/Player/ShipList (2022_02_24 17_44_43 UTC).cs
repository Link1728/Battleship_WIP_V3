using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Player
{
    public class ShipList
    {
        public Dictionary<string, Ship> ships;
        public int[,] grid;

        public void setList(int xMax, int yMax)
        {
            // Grid is 26 x 10, coords are odd x even (51 x 20)
            grid = new int[xMax, yMax];
            ships = new Dictionary<string, Ship>();

        }

        public void removeShip(int index)
        {
            var element = ships.ElementAt(index);
            var key = element.Key;

            ships.Remove(key);
        }

        // Ship Types

        public void addDestroyer()
        {
            Ship destroyer = new Ship(2, false, false);
            ships.Add("Destroyer", destroyer);
        }

        public void addSubmarine()
        {
            Ship submarine = new Ship(3, false, false);
            ships.Add("Submarine", submarine);
        }

        public void addCruiser()
        {
            Ship cruiser = new Ship(3, false, false);
            ships.Add("Cruiser", cruiser);
        }

        public void addBattleship()
        {
            Ship battleship = new Ship(4, false, false);
            ships.Add("Battleship", battleship);
        }

        public void addAircraftCarrier()
        {
            Ship aircraftcarrier = new Ship(5, false, false);
            ships.Add("Aircraft Carrier", aircraftcarrier);
        }

    }
}
