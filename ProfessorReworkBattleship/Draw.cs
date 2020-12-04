using System;
using System.Collections.Generic;
using System.Text;

namespace ProfessorReworkBattleship
{
    class Draw
    {
        Map map = new Map(10, 20);

        public void DrawMap()
        {
            for (int x = 0; x < map.BattleMap.GetLength(0); x++)
            {
                for (int y = 0; y < map.BattleMap.GetLength(1); y++)
                {
                    Console.Write(map.BattleMap[x, y].FieldCharacter);
                }
                Console.WriteLine();
            }
        }
    }
}
