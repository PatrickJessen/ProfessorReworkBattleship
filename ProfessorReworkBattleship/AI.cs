using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class AI : Controller
    {

        Random rand = new Random();

        int lastGuessedX;
        int lastGuessedY;

        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                Pos.x = rand.Next(0, map.Height - Ships[i].ShipLength);
                Pos.y = rand.Next(0, map.Width - Ships[i].ShipLength);
                for (int x = 0; x < Ships[i].ShipLength; x++)
                {
                    if (RandomRotate() == isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[Pos.x + x, Pos.y].IsPlaced = isPlaced;
                        map.BattleMap[Pos.x + x, Pos.y].GetShip = Ships[i];
                        Ships[i].Pos = new Position { x = Pos.x, y = Pos.y };
                    }
                    else if (RandomRotate() == !isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[Pos.x, Pos.y + x].IsPlaced = isPlaced;
                        map.BattleMap[Pos.x, Pos.y + x].GetShip = Ships[i];
                        Ships[i].Pos = new Position { x = Pos.x, y = Pos.y };
                    }
                }
            }
        }

        public override void ShootShip(Map map, List<Ship> ships, bool isPlaced)
        {
            if (!LastTurnHit(ships))
            {
                Pos.x = rand.Next(0, map.Height);
                Pos.y = rand.Next(0, map.Width);
            }
            else if (LastTurnHit(ships))
            {

            }
            lastGuessedX = Pos.x;
            lastGuessedY = Pos.y;
        }

        private bool RandomRotate()
        {
            return Convert.ToBoolean(rand.Next(0, 2));
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
