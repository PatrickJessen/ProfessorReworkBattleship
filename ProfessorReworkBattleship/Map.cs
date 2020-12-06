using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Map
    {
        public Field[,] BattleMap { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            BattleMap = new Field[width, height];

            for (int x = 0; x < height; x++)
            {
                for (int y  = 0; y < width; y++)
                {
                    BattleMap[y, x] = new Field();
                }
            }
        }

        public bool IsSpotsEmpty()
        {
            bool temp = false;
            for (int x = 0; x < BattleMap.GetLength(0); x++)
            {
                for (int y = 0; y < BattleMap.GetLength(1); y++)
                {
                    if (BattleMap[x, y].GetShip != null)
                    {
                        temp = BattleMap[x, y].HasShip = true; // if ship is placed at current location return true else false
                    }
                }
            }
            return temp;           
        }

        public void ClearMap()
        {
            for (int x = 0; x < BattleMap.GetLength(0); x++)
            {
                for (int y = 0; y < BattleMap.GetLength(1); y++)
                {
                    if (BattleMap[x, y].IsPlaced == false)
                    {
                        BattleMap[x, y].GetShip = null; // resets ship to next location to move it around without placing it everytime
                        if (BattleMap[x, y].FieldCharacter == "x")
                        {
                            BattleMap[x, y].FieldCharacter = "~"; // resets the x to next location to move it around without placing it everytime
                        }
                    }
                }
            }
        }
    }
}
