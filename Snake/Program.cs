using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            public static ConsoleColor Color { get; set; } = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            //Can only set window size in windows
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(30, 22);
            }


            //Pull in the game board
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            //Set the values for movement calculations
            string[] Lines = Display.FrameString.ToString().Split((Char)10);
            int Width = Lines[0].Length + 1;
            int Position = (Display.FrameChar.Count / 2) + (Width / 2);

            //Start thred to read key press
            Task.Factory.StartNew(() => Key.Press());

            //Game Loop
            do
            {
                //Set text color
                Console.ForegroundColor = Display.Color;

                //Check Direction for movement
                switch (Snake.Direction)
                {
                    case "Left":
                        Position--;
                        break;

                    case "Right":
                        Position++;
                        break;

                    case "Up":
                        Position -= Width;
                        break;

                    case "Down":
                        Position += Width;
                        break;
                }

                //Add current location to list
                Snake.Location.Add(Position);

                //Pull Display for updating
                Display.FrameChar.Clear();
                Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

                //Reverse locations to get most recent first
                Snake.Location.Reverse();
                int[] Locations = Snake.Location.ToArray();
                Snake.Location.Reverse();

                //Check for collision 
                if (Display.FrameChar[Position] != " " && Display.FrameChar[Position] != "§" && Display.FrameChar[Position] != "Θ")
                {
                    Snake.Dead = true;
                }

                //Add food to board
                Food.Add();

                //Check if eating
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

                //Draw snake to board
                Display.FrameChar[Position] = "Θ";
                if (Locations.Length > Snake.Length)
                {
                    for (int i = 1; i < Snake.Length; i++)
                    {
                        Display.FrameChar[Locations[i]] = "O";
                    }
                }

                //Confirm board has food
                if (!Display.FrameChar.Contains("§"))
                {
                    Food.Feed.Change = true;
                    Food.Add();
                }

                //Check for collision 
                if (Display.FrameChar[Position] != " " && Display.FrameChar[Position] != "§" && Display.FrameChar[Position] != "Θ")
                {
                    Task.Factory.StartNew(() => Beep.Bad());
                    Snake.Dead = true;
                }

                //Update Display
                Display.DisplayFrame.Clear();
                Display.FrameChar.ForEach(Item => Display.DisplayFrame.Append(Item));
                Display.DisplayFrame.Append($"Score: {Snake.Length - 1} Speed: {505 - Snake.Speed}");
                Display.DisplayFrame.Append(System.Environment.NewLine);

                //Write Display to console
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.Write(Display.DisplayFrame);

                //Set game speed
                System.Threading.Thread.Sleep(Snake.Speed);

            } while (!Snake.Dead);

            //Reset game
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Reset.Now();
            Main(args);
        }
    } 
}
