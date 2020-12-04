using System;
using System.Collections.Generic;

namespace ProfessorReworkBattleship
{
    interface IDummy
    {
        int Function(int x);
    }

    class Class1 : IDummy
    {
        public int Function(int x)
        {
            return x * 32;
        }
    }
    class Class2 : IDummy
    {
        public int Function(int x)
        {
            return x * 64;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IDummy> dummies = new List<IDummy>();
            Class1 a = new Class1();
            Class2 b = new Class2();
            dummies.Add(a);
            dummies.Add(b);

            foreach(var dummy in dummies)
            {
                Console.WriteLine(dummy.Function(1));
            }

            //Draw draw = new Draw();
            //draw.DrawMap();
            //Console.ReadKey();
        }
    }
}
