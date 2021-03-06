using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Score
    {
        public static void Update()
        {
            try
            {
                //Get High Score from Settings
                if (Program.Display.HighScore == 0)
                {
                    Program.Display.HighScore = Properties.Settings.Default.Score;
                }

                //Check High Score
                if (Program.Snake.Length > Program.Display.HighScore)
                {
                    Program.Display.HighScore = Program.Snake.Length - 1;
                    Directory.CreateDirectory(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData, System.Environment.SpecialFolderOption.Create));
                    Properties.Settings.Default.Score = Program.Display.HighScore;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Clear()
        {
            try
            {
                Program.Display.HighScore = 0;
                Directory.CreateDirectory(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData, System.Environment.SpecialFolderOption.Create));
                Properties.Settings.Default.Score = 0;
                Properties.Settings.Default.Save();
                Console.Clear();
            }
            catch (Exception)
            {

            }
        }
    }
}
