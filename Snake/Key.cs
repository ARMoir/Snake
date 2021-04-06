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
                var Key = Console.ReadKey().Key;

                if (Key == ConsoleKey.W || Key == ConsoleKey.UpArrow)
                {
                    Program.Snake.Direction = "Up";
                }
                else if (Key == ConsoleKey.A || Key == ConsoleKey.LeftArrow)
                {
                    Program.Snake.Direction = "Left";
                }
                else if (Key == ConsoleKey.S || Key == ConsoleKey.DownArrow)
                {
                    Program.Snake.Direction = "Down";
                }
                else if (Key == ConsoleKey.D || Key == ConsoleKey.RightArrow)
                {
                    Program.Snake.Direction = "Right";
                }
                else
                {
                    //Do Nothiing
                }

            } while (true);
        }
    }
}
