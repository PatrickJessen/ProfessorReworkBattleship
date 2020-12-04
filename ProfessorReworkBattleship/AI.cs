using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class AI : Controller
    {
        public override List<Ship> ships { get; set; } = new List<Ship>();

        public override void AddShips()
        {
            throw new NotImplementedException();
        }

        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            throw new NotImplementedException();
        }

        public override void ShootShip()
        {
            throw new NotImplementedException();
        }
    }
}
