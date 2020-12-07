using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProfessorReworkBattleship
{
    class Input
    {
        static ConsoleKey keyInfo = Console.ReadKey().Key;
        public static bool KeyState(ConsoleKey key)
        {
            if (keyInfo == key)
            {
                keyInfo = 0;
                return true;
            }
            return false;
        }

        public static void UpdateKey()
        {
            keyInfo = Console.ReadKey().Key;
        }
    }
}
