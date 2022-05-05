using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class PlayerShip : Player.Player
    {
        Player.Player player;

        public void setUp(string NAME, int XMIN, int XMAX, int YMIN, int YMAX, int INTERVAL)
        {
            player = new Player.Player();
            player.setPlayer(NAME, XMIN, XMAX, YMIN, YMAX, INTERVAL);

            player.addShips(false);
            player.overlapDetection(player.shipList, false);

            player.printList(60, 15);

            player.createGrid();
            player.printGrid();

        }
    }
}
