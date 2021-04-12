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
                    Program.Snake.Direction = (int)Program.Snake.Directions.Up;
                }
                else if (Key == ConsoleKey.A || Key == ConsoleKey.LeftArrow)
                {
                    Program.Snake.Direction = (int)Program.Snake.Directions.Left;
                }
                else if (Key == ConsoleKey.S || Key == ConsoleKey.DownArrow)
                {
                    Program.Snake.Direction = (int)Program.Snake.Directions.Down;
                }
                else if (Key == ConsoleKey.D || Key == ConsoleKey.RightArrow)
                {
                    Program.Snake.Direction = (int)Program.Snake.Directions.Right;
                }
                else if (Key == ConsoleKey.Q)
                {
                    Environment.Exit(-1);
                }
                else if (Key == ConsoleKey.G)
                {
                    if(Program.Display.Color != ConsoleColor.Green)
                    {
                        Program.Display.Color = ConsoleColor.Green;
                    }
                    else
                    {
                        Program.Display.Color = ConsoleColor.White;
                    }
                }
                else if (Key == ConsoleKey.R)
                {
                    if (Program.Display.Color != ConsoleColor.Red)
                    {
                        Program.Display.Color = ConsoleColor.Red;
                    }
                    else
                    {
                        Program.Display.Color = ConsoleColor.White;
                    }
                }
                else if (Key == ConsoleKey.B)
                {
                    if (Program.Display.Color != ConsoleColor.Blue)
                    {
                        Program.Display.Color = ConsoleColor.Blue;
                    }
                    else
                    {
                        Program.Display.Color = ConsoleColor.White;
                    }
                }
                else if (Key == ConsoleKey.Y)
                {
                    if (Program.Display.Color != ConsoleColor.Yellow)
                    {
                        Program.Display.Color = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Program.Display.Color = ConsoleColor.White;
                    }
                }
                else if (Key == ConsoleKey.P)
                {
                    if (Program.Display.Color != ConsoleColor.Magenta)
                    {
                        Program.Display.Color = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Program.Display.Color = ConsoleColor.White;
                    }
                }
                else
                {
                    //Do Nothiing
                }

            } while (true);
        }
    }
}
