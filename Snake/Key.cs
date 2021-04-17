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

                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        Program.Snake.Direction = (int)Program.Snake.Directions.Up;
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        Program.Snake.Direction = (int)Program.Snake.Directions.Left;
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        Program.Snake.Direction = (int)Program.Snake.Directions.Down;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        Program.Snake.Direction = (int)Program.Snake.Directions.Right;
                        break;

                    case ConsoleKey.Delete:
                        Score.Clear();
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(-1);
                        break;

                    case ConsoleKey.R:
                        if (Program.Display.Color != ConsoleColor.Red)
                        {
                            Program.Display.Color = ConsoleColor.Red;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.G:
                        if (Program.Display.Color != ConsoleColor.Green)
                        {
                            Program.Display.Color = ConsoleColor.Green;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.B:
                        if (Program.Display.Color != ConsoleColor.Blue)
                        {
                            Program.Display.Color = ConsoleColor.Blue;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.C:
                        if (Program.Display.Color != ConsoleColor.Cyan)
                        {
                            Program.Display.Color = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.M:
                        if (Program.Display.Color != ConsoleColor.Magenta)
                        {
                            Program.Display.Color = ConsoleColor.Magenta;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;

                    case ConsoleKey.Y:
                        if (Program.Display.Color != ConsoleColor.Yellow)
                        {
                            Program.Display.Color = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Program.Display.Color = ConsoleColor.White;
                        }
                        break;
                }

            } while (true);
        }
    }
}
