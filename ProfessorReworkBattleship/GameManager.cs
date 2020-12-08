using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class GameManager
    {
        Player player = new Player();
        AI ai = new AI();

        public void PlayerManager(Map map)
        {
            player.Navigation(map);
            player.EnterAndRotate(map);
        }

        public void AIManager(Map map)
        {
            ai.PlaceShip(map, false, true);
        }

        public void AddShipsToList()
        {
            player.AddShips();
            ai.AddShips();
        }

        private bool IsPlayerShipsPlaced()
        {
            return false;
        }
    }
}
