using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Beep
    {
        public static void Bad()
        {
            Console.Beep(330, 500);
        }

        public static void Good()
        {
            Console.Beep(370, 500);
        }
    }
}
