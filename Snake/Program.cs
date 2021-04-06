using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static class Globals
        {
            public static List<string> FrameChar { get; set; } = new List<string>();
            public static List<int> Location { get; set; } = new List<int>();
            public static StringBuilder FrameString { get; set; } = new StringBuilder();
            public static StringBuilder Display { get; set; } = new StringBuilder();
            public static bool Dead { get; set; } = false;
            public static int Length { get; set; } = 1;
            public static string Direction { get; set; } = "Right";           
        }
        static void Main(string[] args)
        {
            Frame.SetFrame();

            Globals.FrameChar.AddRange(Globals.FrameString.ToString().Select(Chars => Chars.ToString()));

            int Start = 32;
            int Position = (Globals.FrameChar.Count / 2) + ((Start / 2) - 2);

            Task.Factory.StartNew(() => Key.Press());

            do
            {
                if (Globals.Direction == "Right")
                {
                    Position++;
                }
                if (Globals.Direction == "Down")
                {
                    Position += Start;
                }
                if (Globals.Direction == "Left")
                {
                    Position--;
                }
                if (Globals.Direction == "Up")
                {
                    Position -= Start;
                }


                Globals.Location.Add(Position);

                Globals.FrameChar.Clear();
                Globals.FrameChar.AddRange(Globals.FrameString.ToString().Select(Chars => Chars.ToString()));

                Globals.FrameChar[360] = "§";

                if(Globals.FrameChar[Position] == "§")
                {
                    Console.Beep(330, 400);
                    Globals.Length++;
                }

                Globals.Location.Reverse();
                int[] Locations = Globals.Location.ToArray();
                Globals.Location.Reverse();

                Globals.FrameChar[Position] = "Θ";
                if (Locations.Length > Globals.Length)
                {
                    for (int i = 1; i < Globals.Length; i++)
                    {
                        Globals.FrameChar[Locations[i]] = "O";
                    }
                }

                if (Globals.FrameChar[Position] != " " && Globals.FrameChar[Position] != "§" && Globals.FrameChar[Position] != "Θ")
                {
                    Globals.Dead = true;
                }


                Globals.Display.Clear();
                Globals.FrameChar.ForEach(Item => Globals.Display.Append(Item));

                Console.Clear();
                Console.Write(Globals.Display);

                System.Threading.Thread.Sleep(500);

            } while (!Globals.Dead);
        }
    } 
}
