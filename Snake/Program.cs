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
            public static string Direction { get; set; } = "";
            public static int Speed { get; set; } = 500;
        }

        public static class Display
        {
            public static List<string> FrameChar { get; set; } = new List<string>();
            public static StringBuilder FrameString { get; set; } = new StringBuilder();
            public static StringBuilder DisplayFrame { get; set; } = new StringBuilder();
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(30, 22);
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            string[] Lines = Display.FrameString.ToString().Split(Environment.NewLine.ToCharArray());
            int Start = Lines[0].Length + 2;
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

                Snake.Location.Reverse();
                int[] Locations = Snake.Location.ToArray();
                Snake.Location.Reverse();

                if (Display.FrameChar[Position] != " " && Display.FrameChar[Position] != "§" && Display.FrameChar[Position] != "Θ")
                {
                    Snake.Dead = true;
                }

                Food.Add();

                if (!Display.FrameChar.Contains("§"))
                {
                    Food.Feed.Change = true;
                    Food.Add();
                }

                if (Display.FrameChar[Position] == "§")
                {
                    Task.Factory.StartNew(() => Beep.Good());
                    Snake.Length++;
                    Food.Feed.Change = true;

                    if(Snake.Speed > 15)
                    {
                        Snake.Speed -= 15;
                    }   
                }

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
                    Task.Factory.StartNew(() => Beep.Bad());
                    Snake.Dead = true;
                }

                Display.DisplayFrame.Clear();
                
                Display.FrameChar.ForEach(Item => Display.DisplayFrame.Append(Item));
                Display.DisplayFrame.Append($"Score: {Snake.Length - 1} Speed: {500 - Snake.Speed}");
                Display.DisplayFrame.Append(System.Environment.NewLine);

                Console.Clear();
                Console.Write(Display.DisplayFrame);

                System.Threading.Thread.Sleep(Snake.Speed);

            } while (!Snake.Dead);

            System.Threading.Thread.Sleep(1000);
            Reset.Now();
            Main(args);
        }
    } 
}
