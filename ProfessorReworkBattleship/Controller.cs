using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    abstract class Controller
    {
        public abstract List<Ship> Ships { get; set; }
        public abstract void PlaceShip(Map map, bool isRotated, bool isPlaced);
        public abstract void ShootShip(Map map, List<Ship> ships, bool isPlaced);
        public abstract void AddShips();
    }
}