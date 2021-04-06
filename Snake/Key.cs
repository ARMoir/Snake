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
                    Program.Globals.Direction = "Right";
                }
                else if (info.KeyChar == 's')
                {
                    Program.Globals.Direction = "Down";
                }
                else if (info.KeyChar == 'a')
                {
                    Program.Globals.Direction = "Left";
                }
                else if (info.KeyChar == 'w')
                {
                    Program.Globals.Direction = "Up";
                }
                else
                {
                    //Do Nothiing
                }
            } while (true);
        }
    }
}
