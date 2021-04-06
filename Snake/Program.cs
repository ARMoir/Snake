using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static class Snake
        {
            public static List<int> Location { get; set; } = new List<int>();
            public static bool Dead { get; set; } = false;
            public static int Length { get; set; } = 1;
            public static string Direction { get; set; } = "Right";           
        }

        public static class Display
        {
            public static List<string> FrameChar { get; set; } = new List<string>();
            public static StringBuilder FrameString { get; set; } = new StringBuilder();
            public static StringBuilder DisplayFrame { get; set; } = new StringBuilder();
        }

        static void Main(string[] args)
        {
            Frame.SetFrame();

            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            int Start = 32;
            int Position = (Display.FrameChar.Count / 2) + ((Start / 2) - 2);

            Task.Factory.StartNew(() => Key.Press());

            do
            {
                if (Snake.Direction == "Right")
                {
                    Position++;
                }
                if (Snake.Direction == "Down")
                {
                    Position += Start;
                }
                if (Snake.Direction == "Left")
                {
                    Position--;
                }
                if (Snake.Direction == "Up")
                {
                    Position -= Start;
                }


                Snake.Location.Add(Position);

                Display.FrameChar.Clear();
                Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

                Display.FrameChar[360] = "§";

                if(Display.FrameChar[Position] == "§")
                {
                    Console.Beep(330, 400);
                    Snake.Length++;
                }

                Snake.Location.Reverse();
                int[] Locations = Snake.Location.ToArray();
                Snake.Location.Reverse();

                Display.FrameChar[Position] = "Θ";
                if (Locations.Length > Snake.Length)
                {
                    for (int i = 1; i < Snake.Length; i++)
                    {
                        Display.FrameChar[Locations[i]] = "O";
                    }
                }

                if (Display.FrameChar[Position] != " " && Display.FrameChar[Position] != "§" && Display.FrameChar[Position] != "Θ")
                {
                    Snake.Dead = true;
                }


                Display.DisplayFrame.Clear();
                Display.FrameChar.ForEach(Item => Display.DisplayFrame.Append(Item));

                Console.Clear();
                Console.Write(Display.DisplayFrame);

                System.Threading.Thread.Sleep(500);

            } while (!Snake.Dead);
        }
    } 
}
