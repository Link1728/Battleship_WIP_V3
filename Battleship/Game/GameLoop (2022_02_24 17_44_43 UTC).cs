using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class GameLoop
    {

        public void SetUp()
        {
            Board board = new Board();
            //board.drawHalfBoard();

            // Grid is 26 x 10, coords are odd x even (51 x 20)

            //PlayerShip pS = new PlayerShip();
            //pS.setUp("Player-1", 1, 26, 2, 10, 2);

            EnemyShip eS = new EnemyShip();
            eS.setUp("CPU", 1, 26, 2, 10, 2);

            //board.drawBoard();
        }

        public void Update()
        {

        }

        public void GameOver()
        {

        }
    }
}
