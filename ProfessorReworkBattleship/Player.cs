using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Player : Controller
    {
        Position pos = new Position();

        public override List<Ship> ships { get; set; } = new List<Ship>();


        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                try
                {
                    if (isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[pos.x + i, pos.y].IsPlaced = isPlaced;
                        map.BattleMap[pos.x + i, pos.y].GetShip = ships[i];
                        ships[i].Pos = new Position { x = pos.x + i, y = pos.y };
                    }
                    else if (isRotated && map.IsSpotsEmpty())
                    {
                        map.BattleMap[pos.x, pos.y + i].IsPlaced = isPlaced;
                        map.BattleMap[pos.x, pos.y + i].GetShip = ships[i];
                        ships[i].Pos = new Position { x = pos.x, y = pos.y + i };
                    }
                }
                catch
                {
                    isPlaced = false;
                }
            }
        }
        public override void AddShips()
        {
            ships.Add(new Ship("H", 5, pos, ConsoleColor.Red));
            ships.Add(new Ship("S", 4, pos, ConsoleColor.Blue));
            ships.Add(new Ship("D", 3, pos, ConsoleColor.Yellow));
            ships.Add(new Ship("U", 3, pos, ConsoleColor.Green));
            ships.Add(new Ship("P", 2, pos, ConsoleColor.Magenta));
        }

        public override void ShootShip()
        {
            throw new NotImplementedException();
        }
    }
}
