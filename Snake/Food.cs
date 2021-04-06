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
            public static bool Done { get; set; } = false;
            public static bool Change { get; set; } = false;
        }

        public static void Add()
        {

            if (Feed.Change || Feed.Check == 0)
            {
                Feed.Check = Feed.Random.Next(Program.Display.FrameChar.Count);
                Feed.Change = false;
            }

            do
            {
                if(Program.Display.FrameChar[Feed.Check] == " ")
                {
                    Program.Display.FrameChar[Feed.Check] = "§";
                    Feed.Done = true;
                }

            } while (!Feed.Done);
        }
    }
}
