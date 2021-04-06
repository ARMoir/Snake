using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Reset
    {
        public static void Now()
        {
            Program.Display.FrameChar.Clear();
            Program.Display.FrameString.Clear();
            Program.Display.DisplayFrame.Clear();

            Program.Snake.Location.Clear();
            Program.Snake.Dead = false;
            Program.Snake.Length = 1;
            Program.Snake.Direction = "";
            Program.Snake.Speed = 500;

            Food.Feed.Drop = 0;
            Food.Feed.Check = 0;
            Food.Feed.Change = true;
        }
    }
}
