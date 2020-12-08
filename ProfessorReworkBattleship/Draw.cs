using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProfessorReworkBattleship
{
    class Draw
    {
        Map Playermap = new Map(10, 20);
        Map AImap = new Map(10, 20);
        GameManager manager = new GameManager();
        Thread input = new Thread(StartThread);
        private static void StartThread()
        {
            while (true)
                Input.UpdateKey();
            //Input.KeyState(0);
        }

        public void GameLoop()
        {
            input.Start();

            manager.AddShipsToList();
            while (true)
            {
                DrawMap(Playermap);
                manager.PlayerManager(Playermap);
                Console.SetCursorPosition(0, 0);
                //DrawMap(AImap);
                //manager.AIManager(AImap);
                //Console.SetCursorPosition(0, 0);
            }

        }

        public void DrawMap(Map playerMap)
        {
            for (int x = 0; x < playerMap.BattleMap.GetLength(0); x++)
            {
                for (int y = 0; y < playerMap.BattleMap.GetLength(1); y++)
                {
                    if (playerMap.BattleMap[x, y].GetShip != null)
                    {
                        Console.ForegroundColor = playerMap.BattleMap[x, y].GetShip.Color;
                        Console.Write(playerMap.BattleMap[x, y].GetShip.ShipCharacter);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(playerMap.BattleMap[x, y].FieldCharacter);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
