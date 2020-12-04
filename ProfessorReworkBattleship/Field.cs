using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Field
    {
        public string FieldCharacter { get; set; } = "~";
        public Ship GetShip { get; set; }
        public bool IsPlaced { get; set; }
        public bool HasShip { get; set; }
    }
}
