using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    abstract class Controller
    {
        public List<Ship> Ships { get; set; } = new List<Ship>();

        private Position pos;

        public Position Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public abstract void PlaceShip(Map map, bool isRotated, bool isPlaced);
        public abstract void ShootShip(Map map, List<Ship> ships, bool isPlaced);
        public void AddShips()
        {
            Ships.Add(new Ship("H", 5, Pos, ConsoleColor.Red));
            Ships.Add(new Ship("S", 4, Pos, ConsoleColor.Blue));
            Ships.Add(new Ship("D", 3, Pos, ConsoleColor.Yellow));
            Ships.Add(new Ship("U", 3, Pos, ConsoleColor.Green));
            Ships.Add(new Ship("P", 2, Pos, ConsoleColor.Magenta));
        }
    }
}