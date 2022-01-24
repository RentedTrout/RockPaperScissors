using System;
using System.Threading;
using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    /// <summary>
    /// Class to handle outputs to the console window
    /// </summary>
    public static class ScreenOutputs
    {
        /// <summary>
        /// Initial splash screen
        /// </summary>
        public static void SplashScreen()
        {
            Console.Clear();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            string text = "Welcome to Rock, Paper, Scissors!";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
            Console.CursorTop++;

            Console.WriteLine();

            RockPaperScissor();

            Thread.Sleep(2000);
            Console.WriteLine();

            PressEnterToContinue(true);
        }

        /// <summary>
        /// Anscii art for ROCK
        /// </summary>
        /// <param name="centreText"></param>
        public static void LeftSideRock(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______  ",
                "-----'   ____) ",
                "        ()____)",
                "        ()____)",
                "        ()___) ",
                "-----.__()__)  "
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Anscii art for SCISSORS
        /// </summary>
        /// <param name="centreText"></param>
        public static void LeftSideScissors(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______      ",
                "-----'   ____)____ ",
                "         _________)",
                "         _________)",
                "        ()___)     ",
                "-----.__()__)      "
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Anscii art for PAPEE
        /// </summary>
        /// <param name="centreText"></param>
        /// 
        public static void LeftSidePaper(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______      ",
                "-----'   ____)____ ",
                "         _________)",
                "         _________)",
                "         ________) ",
                "-----.__________)  "
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Animation for 1, 2, 3 etc
        /// </summary>
        public static void RockPaperScissor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LeftSideRock(true);

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            LeftSidePaper(true);

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            LeftSideScissors(true);
            Console.WriteLine();
            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Handles all Press Enter To Continue
        /// </summary>
        /// <param name="centreText"></param>
        public static void PressEnterToContinue(bool centreText)
        {
            ConsoleKeyInfo keyPressed;
            string text = "Press [Enter] to continue...";

            if (centreText)
                CentreConsoleOutput(text);
            else
                Console.WriteLine(text);

            Console.WriteLine();
            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.Enter);
        }

        /// <summary>
        /// Centre text in console window
        /// </summary>
        /// <param name="text"></param>
        public static void CentreConsoleOutput(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Gets console entry for player 1
        /// </summary>
        /// <returns></returns>
        public static string GetPlayer1Name()
        {
            Console.Clear();
            Console.WriteLine("Player 1. Enter your name : ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("");
            return player1Name;
        }

        /// <summary>
        /// Gets console entry for player 1
        /// </summary>
        /// <returns></returns>
        public static string GetPlayer2Name()
        {
            Console.WriteLine("Player 2. Enter your name : ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("");
            return player1Name;
        }


        /// <summary>
        /// Determine player 2 - Human or Computer
        /// </summary>
        /// <param name="player1Name"></param>
        /// <returns></returns>
        public static bool GetPlayer1Opponent()
        {
            ConsoleKeyInfo keyPressed;

            Console.WriteLine("Please choose an opponent:");
            Console.WriteLine("[H] : Human opponent");
            Console.WriteLine("[C] : Computer");

            Console.WriteLine("please make a choice:");

            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.H && keyPressed.Key != ConsoleKey.C);

            Console.WriteLine("");

            // true = human, false = computer
            return keyPressed.Key == ConsoleKey.H;
        }

        public static Game GetGameToPlay()
        {
            ConsoleKeyInfo keyPressed;
            Game selectedGame = Game.Classic;

            Console.WriteLine($"Welcome...");
            Console.WriteLine("Please choose a game to play:");
            Console.WriteLine("[C] : Classic - Rock, Paper, Scissors");
            Console.WriteLine("[E] : Enhanced - Rock, Paper, Scissors, Flamethrower");
            Console.WriteLine("[B] : Big Bang - Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("[H] : Help");

            Console.WriteLine("please make a choice:");

            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.C
                    && keyPressed.Key != ConsoleKey.E
                    && keyPressed.Key != ConsoleKey.B
                    && keyPressed.Key != ConsoleKey.H);

            switch (keyPressed.Key)
            {
                case ConsoleKey.C:
                    selectedGame = Game.Classic;
                    break;

                case ConsoleKey.E:
                    selectedGame = Game.Enhanced;
                    break;

                case ConsoleKey.B:
                    selectedGame = Game.BigBang;
                    break;

                case ConsoleKey.H:
                    DisplayHelp();
                    break;

            }

            Console.WriteLine("");

            // true = human, false = computer
            return selectedGame;
        }

        public static void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Classic - Rock, Paper, Scissors");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Rock : Beats scissors");
            Console.WriteLine("Paper : Beats Rock");
            Console.WriteLine("Scissors : Beat paper");

            Console.WriteLine();
            Console.WriteLine("Enhanced - Rock, Paper, Scissors, Flamethrower");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Rock : Beats Scissors");
            Console.WriteLine("Paper : Beats Rock");
            Console.WriteLine("Scissors : Beat Paper");
            Console.WriteLine("Flamethrower : Beat Paper");


            Console.WriteLine();
            Console.WriteLine("Big Bang - Rock, Paper, Scissors, Lizard, Spock");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Rock : Beats Scissors and Lizard");
            Console.WriteLine("Paper : Beats Rock and Spock");
            Console.WriteLine("Scissors : Beat Paper and Lizard");
            Console.WriteLine("Lizard : Beats Paper and Spock");
            Console.WriteLine("Spock : Beats Scissors and Rock");
            Console.WriteLine();

            PressEnterToContinue(false);

            GetGameToPlay();
        }
    }
}




    