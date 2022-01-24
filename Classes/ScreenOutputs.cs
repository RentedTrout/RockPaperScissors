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

            Console.ForegroundColor = ConsoleColor.Red;
            string text = "Welcome to Rock, Paper, Scissors!";
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
            Console.CursorTop++;

            Console.WriteLine();

            RockPaperScissor();

            Console.WriteLine();

            PressEnterToContinue();

            Console.Clear();
        }
        /// <summary>
        /// Anscii art for ROCK
        /// </summary>
        /// <param name="centreText"></param>
        public static void Rock(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______  ",
                "-----'   ____) ",
                "        ()____)",
                "        ()____)",
                "        ()___) ",
                "-----.__()__)  ",
                "Rock"
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Anscii art for ROCK
        /// To be used to display results in the future
        /// </summary>
        /// <param name="centreText"></param>
        public static void RockRock(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______     _______      ",
                "-----'   ____)   (____   '-----",
                "        ()____) (____()        ",
                "        ()____) (____()        ",
                "        ()___)   (___()        ",
                "-----.__()__)     (__()__.-----",
                "Rock                       Rock"
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
        public static void Scissors(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______      ",
                "-----'   ____)____ ",
                "         _________)",
                "         _________)",
                "        ()___)     ",
                "-----.__()__)      ",
                "Scissors"
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
        /// To be used to display results in the future
        /// </summary>
        /// <param name="centreText"></param>
        public static void ScissorsScissors(bool centreText)
        {

            string[] gesture = new string[]
            {
                "      _______              _______      ",
                "-----'   ____)____    ____(____   '-----",
                "         _________)  (_________         ",
                "         _________)  (_________         ",
                "        ()___)            (___()        ",
                "-----.__()__)              (___()       ",
                "Scissors                         Scissors"
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Anscii art for PAPER
        /// </summary>
        /// <param name="centreText"></param>
        /// 
        public static void Paper(bool centreText)
        {
            string[] gesture = new string[]
            {
                "      _______      ",
                "-----'   ____)____ ",
                "         _________)",
                "         _________)",
                "         ________) ",
                "-----.__________)  ",
                "Paper"
            };

            foreach (string item in gesture)
            {
                if (centreText)
                    Console.SetCursorPosition((Console.WindowWidth - item.Length) / 2, Console.CursorTop);

                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Anscii art for PAPER
        /// To be used to display results in the future
        /// </summary>
        /// <param name="centreText"></param>
        /// 
        public static void PaperPaper(bool centreText)
        {
            string[] gesture = new string[]
            {
                "      _______              _______      ",
                "-----'   ____)____    ____(____   '-----",
                "         _________)  (_________         ",
                "         _________)  (_________         ",
                "         ________)    (________         ",
                "-----.__________)      (_______         ",
                "Paper                               Paper"
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
            Console.ForegroundColor = ConsoleColor.Green;
            Rock(true);

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Paper(true);

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Scissors(true);
            Console.WriteLine();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Handles all Press Enter To Continue
        /// </summary>
        /// <param name="centreText"></param>
        public static bool PlayAgain()
        {
            ConsoleKeyInfo keyPressed;
            string text = "Play again? [Y] to play again or [N] to exit.";

            CentreConsoleOutput(text);

            Console.WriteLine();
            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.Y && keyPressed.Key != ConsoleKey.N);

            return keyPressed.Key == ConsoleKey.Y;
        }

        /// <summary>
        /// Handles all Press Enter To Continue
        /// </summary>
        /// <param name="centreText"></param>
        public static void PressEnterToContinue()
        {
            ConsoleKeyInfo keyPressed;
            string text = "Press [Enter] to continue...";

            CentreConsoleOutput(text);

            Console.WriteLine();
            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.Enter);
        }

        /// <summary>
        /// Centre text in console window based on the length of the current string provided
        /// </summary>
        /// <param name="text"></param>
        public static void CentreConsoleOutputWithFollowingInput(string outputText)
        {
            Console.SetCursorPosition((Console.WindowWidth - outputText.Length) / 2, Console.CursorTop);
            Console.WriteLine(outputText);
            Console.SetCursorPosition((Console.WindowWidth - outputText.Length) / 2, Console.CursorTop);
        }

        /// <summary>
        /// Centre text in console window based on the length of the current string provided
        /// </summary>
        /// <param name="text"></param>
        public static void CentreConsoleOutput(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Centre text in console window based on a predetermined string length
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        public static void CentreConsoleOutput(string text, int length)
        {
            Console.SetCursorPosition((Console.WindowWidth - length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Gets console entry for player name
        /// </summary>
        /// <returns></returns>
        public static string GetPlayerName(int number)
        {
            string playerName;

            Console.WriteLine("");
            string text = $"Player {number}. Enter your name : ";
            int currentCursorTopLocation = Console.CursorTop;

            CentreConsoleOutputWithFollowingInput(text);
            do
            {
                // Save current cursorTop value to keep cursor where is should be for input
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, currentCursorTopLocation+1);
                playerName = Console.ReadLine();
            } while (string.IsNullOrEmpty(playerName));

            Console.WriteLine("");

            return playerName;
        }

        /// <summary>
        /// Determine player 2 - Human or Computer
        /// </summary>
        /// <param name="player1Name"></param>
        /// <returns></returns>
        public static PlayerType GetPlayer1Opponent()
        {
            ConsoleKeyInfo keyPressed;
            PlayerType selectedPlayerType = PlayerType.Human;

            CentreConsoleOutput("Please choose an opponent:              ");
            CentreConsoleOutput("[H] : Human Opponent                    ");
            CentreConsoleOutput("[C] : Computer - Beat Previous Selection");
            CentreConsoleOutput("[R] : Computer - Random Choices         ");

            CentreConsoleOutputWithFollowingInput("please make a choice:                   ");

            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.H &&
                        keyPressed.Key != ConsoleKey.C &&
                        keyPressed.Key != ConsoleKey.R);

            Console.WriteLine("");

            switch (keyPressed.Key)
            {
                case ConsoleKey.H:
                    selectedPlayerType = PlayerType.Human;
                    break;

                case ConsoleKey.C:
                    selectedPlayerType = PlayerType.Computer;
                    break;

                case ConsoleKey.R:
                    selectedPlayerType = PlayerType.RandomComputer;
                    break;
            }

            return selectedPlayerType;
        }

        public static void DisplayRoundNumberAndCurrentScore(int roundNumber, Player player1, Player player2)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            CentreConsoleOutput($"Round {roundNumber}... {player1.Name} Score: {player1.Score} - {player2.Name} Score : {player2.Score}");

            Console.WriteLine();
        }
    }
}






