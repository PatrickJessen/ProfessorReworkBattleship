using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProfessorReworkBattleship
{
    class Input
    {
        public static bool KeyState(ConsoleKey key)
        {
            //ConsoleKeyInfo newKey = new ConsoleKeyInfo();
            if (Console.ReadKey().Key == key)
            {
                return true;
            }
            return false;
        }
    }
}
