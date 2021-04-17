using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Snake
{
    class Beep
    {
        public static void Bad()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Beep(330, 500);
            }
        }

        public static void Good()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Beep(370, 500);
            }
        }
    }
}
