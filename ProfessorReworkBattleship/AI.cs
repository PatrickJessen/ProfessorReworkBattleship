using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class AI : Controller
    {
        public override List<Ship> Ships { get; set; } = new List<Ship>();
        public Position pos = new Position();
        Random rand = new Random();

        int lastGuessedX;
        int lastGuessedY;

        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                pos.x = rand.Next(0, map.Height - Ships[i].ShipLength);
                pos.y = rand.Next(0, map.Width - Ships[i].ShipLength);
                for (int x = 0; x < Ships[i].ShipLength; x++)
                {
                    if (RandomRotate() == isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[pos.x + x, pos.y].IsPlaced = isPlaced;
                        map.BattleMap[pos.x + x, pos.y].GetShip = Ships[i];
                        Ships[i].Pos = new Position { x = pos.x, y = pos.y };
                    }
                    else if (RandomRotate() == !isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[pos.x, pos.y + x].IsPlaced = isPlaced;
                        map.BattleMap[pos.x, pos.y + x].GetShip = Ships[i];
                        Ships[i].Pos = new Position { x = pos.x, y = pos.y };
                    }
                }
            }
        }

        public override void ShootShip(Map map, List<Ship> ships, bool isPlaced)
        {
            if (!LastTurnHit(ships))
            {
                pos.x = rand.Next(0, map.Height);
                pos.y = rand.Next(0, map.Width);
            }
            else if (LastTurnHit(ships))
            {

            }
            lastGuessedX = pos.x;
            lastGuessedY = pos.y;
        }

        public override void AddShips()
        {
            Ships.Add(new Ship("H", 5, pos, ConsoleColor.Red));
            Ships.Add(new Ship("S", 4, pos, ConsoleColor.Blue));
            Ships.Add(new Ship("D", 3, pos, ConsoleColor.Yellow));
            Ships.Add(new Ship("U", 3, pos, ConsoleColor.Green));
            Ships.Add(new Ship("P", 2, pos, ConsoleColor.Magenta));
        }
        private bool RandomRotate()
        {
            int x = rand.Next(0, 2);
            if (x == 0)
            {
                return true;
            }
            return false;
        }

        private bool LastTurnHit(List<Ship> ships)
        {
            bool temp = true;
            for (int i = 0; i < ships.Count; i++)
            {
                if (lastGuessedX != ships[i].Pos.x && lastGuessedY != ships[i].Pos.y)
                {
                    temp = false;
                }
            }
            return temp;
        }
    }
}
