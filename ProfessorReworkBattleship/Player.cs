using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Player : Controller
    {
        public override List<Ship> Ships { get; set; } = new List<Ship>();
        public Position pos = new Position();

        /// <summary>
        /// Place your ships
        /// </summary>
        /// <param name="map">Should be the players map</param>
        /// <param name="isRotated">if true the ships is rotated vertically, if false the ships is rotated horizontally</param>
        /// <param name="isPlaced">if true you place the ships, if false you dont</param>
        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            map.ClearMap();
            for (int i = 0; i < Ships.Count; i++)
            {
                for (int x = 0; x < Ships[i].ShipLength; x++)
                {
                    try
                    {
                        if (isRotated && map.IsSpotsEmpty()) // rotates ships horizontally
                        {
                            map.BattleMap[pos.x + x, pos.y].IsPlaced = isPlaced; // check if i placed ship or not
                            map.BattleMap[pos.x + x, pos.y].GetShip = Ships[i]; // get current ship in list
                            Ships[i].Pos = new Position { x = pos.x, y = pos.y }; // saves the x and y position on each ship
                        }
                        else if (!isRotated && map.IsSpotsEmpty()) // rotates ships vertically
                        {
                            map.BattleMap[pos.x, pos.y + x].IsPlaced = isPlaced;
                            map.BattleMap[pos.x, pos.y + x].GetShip = Ships[i];
                            Ships[i].Pos = new Position { x = pos.x, y = pos.y };
                        }
                    }
                    catch
                    {
                        isPlaced = false;
                    }
                }
            }
        }
        /// <summary>
        /// Shoot the enemies ship
        /// </summary>
        /// <param name="map">should be the opponents/AI's map</param>
        /// <param name="ships">should be the opponents/AI's list of ships</param>
        /// <param name="isPlaced">should be false when you move your x around and true when want to place it</param>
        public override void ShootShip(Map map, List<Ship> ships, bool isPlaced)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (pos.x == ships[i].Pos.x && pos.y == ships[i].Pos.y && isPlaced) // if i hit a ship location make fieldcharacter "o" else make it "x"
                {
                    map.BattleMap[pos.x, pos.y].FieldCharacter = "o";
                }
                else if (isPlaced)
                {
                    map.BattleMap[pos.x, pos.y].FieldCharacter = "x";
                }
            }
        }

        public override void AddShips()
        {
            Ships.Add(new Ship("H", 5, pos, ConsoleColor.Red));
            Ships.Add(new Ship("S", 4, pos, ConsoleColor.Blue));
            Ships.Add(new Ship("D", 3, pos, ConsoleColor.Yellow));
            Ships.Add(new Ship("U", 3, pos, ConsoleColor.Green));
            Ships.Add(new Ship("P", 2, pos, ConsoleColor.Magenta));
        }
    }
}
