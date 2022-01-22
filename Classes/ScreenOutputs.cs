using System;
using System.Threading;

namespace RockPaperScissors.Classes
{
    public static class ScreenOutputs
    {
        public static void SplashScreen()
        {
            ConsoleKeyInfo keyPressed;

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
        public static void LeftSideRock(bool centre)
        {

            string[] gesture = new string[]
            {
                "      _______",
                "-----'   ____)",
                "        ()____)",
                "        ()____)",
                "        ()___)",
                "-----.__()__)"
            };

            foreach (string item in gesture)
            {
                if (centre)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        public static void LeftSideScissors(bool centre)
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
                if (centre)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        public static void LeftSidePaper(bool centre)
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
                if (centre)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

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

        public static void CentreConsoleOutput(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }
        public static string GetPlayer1Name()
        {
            Console.Clear();
            Console.WriteLine("Player 1. Enter your name : ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("");
            return player1Name;
        }

        public static string GetPlayer2Name()
        {
            Console.WriteLine("Player 2. Enter your name : ");
            string player1Name = Console.ReadLine();
            Console.WriteLine("");
            return player1Name;
        }

        public static bool GetPlayer1Opponent(string player1Name)
        {
            ConsoleKeyInfo keyPressed;

            Console.WriteLine($"Welcome {player1Name}...");
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
    }
}
