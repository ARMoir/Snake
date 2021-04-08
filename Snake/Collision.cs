using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Collision
    {
        public static void Check(int Position)
        {
            if (Program.Display.FrameChar[Position] != " " && Program.Display.FrameChar[Position] != "§" && Program.Display.FrameChar[Position] != "Θ")
            {
                Program.Snake.Dead = true;
                Task.Factory.StartNew(() => Beep.Bad());
            }
        }
    }
}
