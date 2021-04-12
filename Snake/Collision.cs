using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Collision
    {
        public static class Safe
        {
            public static string[] Values { get; set; } = { " ", "§", "Θ"};
        }

        public static void Check(int Position)
        {
            if (!Safe.Values.Contains(Program.Display.FrameChar[Position]))
            {
                Task.Factory.StartNew(() => Beep.Bad());
                Program.Snake.Dead = true;
            }
        }
    }
}
