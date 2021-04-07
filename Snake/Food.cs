using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Food
    {
        public static class Feed
        {
            public static Random Random { get; set; } = new Random();
            public static int Drop { get; set; } = 0;
            public static int Check { get; set; } = 0;
            public static bool Change { get; set; } = false;
        }

        public static void Add()
        {
            if (Feed.Check == 0)
            {
                Feed.Check = Feed.Random.Next(Program.Display.FrameChar.Count);
                Feed.Change = true;
            }

            if (Feed.Change)
            {
                Feed.Check = Feed.Random.Next(Program.Display.FrameChar.Count - 1);
                Feed.Change = false;
            }

            if (Program.Display.FrameChar[Feed.Check] == " ")
            {
                Program.Display.FrameChar[Feed.Check] = "§";
            }
            else
            {
                Feed.Change = true;
            }
        }
    }
}
