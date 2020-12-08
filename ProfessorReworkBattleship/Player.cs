using System;
using System.Collections.Generic;
using System.Text;


namespace ProfessorReworkBattleship
{
    class Player : Controller
    {
        /// <summary>
        /// Place your ships
        /// </summary>
        /// <param name="map">Should be the players map</param>
        /// <param name="isRotated">if true the ships is rotated vertically, if false the ships is rotated horizontally</param>
        /// <param name="isPlaced">if true you place the ships, if false you dont</param>
        public override void PlaceShip(Map map, bool isRotated, bool isPlaced)
        {
            map.ClearMap();
            for (int x = 0; x < Ships[Counter].ShipLength; x++)
            {
                try
                {
                    if (isRotated && !map.BattleMap[Pos.x + x , Pos.y].HasShip) // rotates ships horizontally
                    {
                        map.BattleMap[Pos.x + x, Pos.y].IsPlaced = isPlaced; // check if i placed ship or not
                        map.BattleMap[Pos.x + x, Pos.y].GetShip = Ships[Counter]; // get current ship in list
                        //Ships[Counter].Pos = new Position { x = Pos.x, y = Pos.y }; // saves the x and y position on each ship
                    }
                    else if (!isRotated && !map.BattleMap[Pos.x, Pos.y + x].HasShip) // rotates ships vertically
                    {
                        map.BattleMap[Pos.x, Pos.y + x].IsPlaced = isPlaced;
                        map.BattleMap[Pos.x, Pos.y + x].GetShip = Ships[Counter];
                        
                        //Ships[Counter].Pos = new Position { x = Pos.x, y = Pos.y };
                    }
                }
                catch
                {
                    isPlaced = false;
                }
            }
        }
        /// <summary>
        /// Shoot the enemies ship
        /// </summary>
        /// <param name="map">should be the opponents/AI's map</param>
        /// <param name="ships">should be the opponents/AI's list of ships</param>
        /// <param name="isPlaced">should be false when you move your x around and true when want to place it</param>
        public override void ShootShip(Map map, bool isPlaced)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                if (Pos.x == Ships[i].Pos.x && Pos.y == Ships[i].Pos.y && isPlaced) // if i hit a ship location make fieldcharacter "o" else make it "x"
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
                Pos.x--;
                PlaceShip(map, RotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.DownArrow))
            {
                Pos.x++;
                PlaceShip(map, RotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.LeftArrow))
            {
                Pos.y--;
                PlaceShip(map, RotateShip, false);
            }
            else if (Input.KeyState(ConsoleKey.RightArrow))
            {
                Pos.y++;
                PlaceShip(map, RotateShip, false);
            }
        }

        public void EnterAndRotate(Map map)
        {
            if (Input.KeyState(ConsoleKey.B))
            {
                RotateShip = true;
            }
            else if (Input.KeyState(ConsoleKey.N))
            {
                RotateShip = false;
            }
            else if (Input.KeyState(ConsoleKey.Enter))
            {
                PlaceShip(map, RotateShip, ShipCanBePlaced(map));
                ShipIsPlaced(map);
            }
        }

        private void ShipIsPlaced(Map map)
        {
            if (map.BattleMap[Pos.x, Pos.y].IsPlaced && !map.BattleMap[Pos.x, Pos.y].HasShip)
            {
                IsSpotsEmpty(map);
                Ships[Counter].Pos = new Position { x = Pos.x, y = Pos.y };
                Counter++;
                //IsSpotsEmpty(map);
            }
        }

        private bool ShipCanBePlaced(Map map)
        {
            for (int i = 0; i < Ships[Counter].ShipLength; i++)
            {
                if (!RotateShip && map.BattleMap[Pos.x, Pos.y + i].HasShip || RotateShip && map.BattleMap[Pos.x + i, Pos.y].HasShip)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
