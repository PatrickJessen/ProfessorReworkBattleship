using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Player : Controller
    {
        bool rotateShip = false;
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
                            map.BattleMap[Pos.x + x, Pos.y].IsPlaced = isPlaced; // check if i placed ship or not
                            map.BattleMap[Pos.x + x, Pos.y].GetShip = Ships[i]; // get current ship in list
                            Ships[i].Pos = new Position { x = Pos.x, y = Pos.y }; // saves the x and y position on each ship
                        }
                        else if (!isRotated && map.IsSpotsEmpty()) // rotates ships vertically
                        {
                            map.BattleMap[Pos.x, Pos.y + x].IsPlaced = isPlaced;
                            map.BattleMap[Pos.x, Pos.y + x].GetShip = Ships[i];
                            Ships[i].Pos = new Position { x = Pos.x, y = Pos.y };
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
                if (Pos.x == ships[i].Pos.x && Pos.y == ships[i].Pos.y && isPlaced) // if i hit a ship location make fieldcharacter "o" else make it "x"
                {
                    map.BattleMap[Pos.x, Pos.y].FieldCharacter = "o";
                }
                else if (isPlaced)
                {
                    map.BattleMap[Pos.x, Pos.y].FieldCharacter = "x";
                }
            }
        }

        public void Navigation(Map map)
        {
            if (Input.KeyState(ConsoleKey.UpArrow))
            {
                Pos.y--;
                PlaceShip(map, rotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.DownArrow))
            {
                Pos.y++;
                PlaceShip(map, rotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.LeftArrow))
            {
                Pos.x--;
                PlaceShip(map, rotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.RightArrow))
            {
                Pos.x++;
                PlaceShip(map, rotateShip, false);
            }
        }

        public void EnterAndRotate(Map map)
        {
            if (Input.KeyState(ConsoleKey.B))
            {
                rotateShip = true;
            }
            else if (Input.KeyState(ConsoleKey.N))
            {
                rotateShip = false;
            }
            else if (Input.KeyState(ConsoleKey.Enter))
            {
                PlaceShip(map, rotateShip, true);
            }
        }
    }
}
