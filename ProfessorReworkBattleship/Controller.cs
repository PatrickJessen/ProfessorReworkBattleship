using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    abstract class Controller
    {
        public abstract List<Ship> ships { get; set; }
        public abstract void PlaceShip(Map map, bool isRotated, bool isPlaced);
        public abstract void ShootShip();
        public abstract void AddShips();
    }
}
