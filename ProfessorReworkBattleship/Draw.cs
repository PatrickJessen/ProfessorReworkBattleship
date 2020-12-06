using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProfessorReworkBattleship
{
    class Draw
    {
        Map map = new Map(10, 20);
        Thread input = new Thread(StartThread);
        private static void StartThread()
        {
            //while (true)
            Input.KeyState(0);
        }

        public void GameLoop()
        {
            input.Start();
            input.IsBackground = true;
            while (true)
            {
                if (Input.KeyState(ConsoleKey.G))
                {
                    Console.WriteLine("test");
                }
                if (Input.KeyState(ConsoleKey.F))
                {
                    Console.WriteLine("test2");
                }
                if (Input.KeyState(ConsoleKey.A))
                {
                    Console.WriteLine("test2");
                }
            }

        }

        public void test()
        {
            if (Input.KeyState(ConsoleKey.G))
            {
                Console.WriteLine("test");
            }
        }

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
