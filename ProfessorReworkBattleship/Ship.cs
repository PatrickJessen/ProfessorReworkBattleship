using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Ship
    {
        public string ShipCharacter { get; set; }
        public int ShipLength { get; set; }
        public Position Pos { get; set; }
        public ConsoleColor Color { get; set; }

        public Ship(string shipCharacter, int shipLength, Position pos, ConsoleColor color)
        {
            ShipCharacter = shipCharacter;
            ShipLength = shipLength;
            Pos = pos;
            Color = color;
        }
    }
}
