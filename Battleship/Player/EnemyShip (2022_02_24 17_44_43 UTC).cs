using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class EnemyShip : Player.Player
    {
        Player.Player player;

        public void setUp(string NAME, int XMIN, int XMAX, int YMIN, int YMAX, int INTERVAL)
        {
            player = new Player.Player();
            player.setPlayer(NAME, XMIN, XMAX, YMIN, YMAX, INTERVAL);

            player.addShips(true);
            player.overlapDetection(player.shipList, true);

            player.createGrid();
            player.printGrid();

            Console.Clear();
            player.drawShips(player.shipList);
            player.printList(60, 1);

        }
    }
}
