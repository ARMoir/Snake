using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Key
    {
        public static void Press()
        {
            do
            {
                var info = Console.ReadKey();
                if (info.KeyChar == 'd')
                {
                    Program.Snake.Direction = "Right";
                }
                else if (info.KeyChar == 's')
                {
                    Program.Snake.Direction = "Down";
                }
                else if (info.KeyChar == 'a')
                {
                    Program.Snake.Direction = "Left";
                }
                else if (info.KeyChar == 'w')
                {
                    Program.Snake.Direction = "Up";
                }
                else
                {
                    //Do Nothiing
                }
            } while (true);
        }
    }
}
