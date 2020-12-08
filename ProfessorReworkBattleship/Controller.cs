using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    abstract class Controller
    {
        public List<Ship> Ships { get; set; } = new List<Ship>();

        public Position Pos = new Position();
        public bool RotateShip { get; set; }
        public int Counter { get; set; }
        public abstract void PlaceShip(Map map, bool isRotated, bool isPlaced);
        public abstract void ShootShip(Map map, bool isPlaced);
        public void AddShips()
        {
            Ships.Add(new Ship("H", 5, Pos, ConsoleColor.Red));
            Ships.Add(new Ship("S", 4, Pos, ConsoleColor.Blue));
            Ships.Add(new Ship("D", 3, Pos, ConsoleColor.Yellow));
            Ships.Add(new Ship("U", 3, Pos, ConsoleColor.Green));
            Ships.Add(new Ship("P", 2, Pos, ConsoleColor.Magenta));
        }

        public void IsSpotsEmpty(Map map)
        {
            for (int i = 0; i < Ships[Counter].ShipLength; i++)
            {
                if (!RotateShip && map.BattleMap[Pos.x, Pos.y + i].GetShip != null)
                {
                    map.BattleMap[Pos.x, Pos.y + i].HasShip = true;
                }
                else if (RotateShip && map.BattleMap[Pos.x + i, Pos.y].GetShip != null)
                {
                    map.BattleMap[Pos.x + i, Pos.y].HasShip = true;
                }
                else
                {
                    map.BattleMap[Pos.x + i, Pos.y].HasShip = false;
                    map.BattleMap[Pos.x, Pos.y + i].HasShip = false;
                }
            }
        }
    }
}