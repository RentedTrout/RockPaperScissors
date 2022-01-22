using RockPaperScissors.Classes;
using System;
using System.Runtime.InteropServices;

namespace RockPaperScissors
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        public static Player player1 = new Player();
        public static Player player2 = new Player();

        public static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            ScreenOutputs.SplashScreen();

            Console.ForegroundColor = ConsoleColor.White;
            player1.Name = ScreenOutputs.GetPlayer1Name();

            if (ScreenOutputs.GetPlayer1Opponent(player1.Name))
            {
                player2.Name = ScreenOutputs.GetPlayer2Name();
                PlayGame(true);

            }
            else
            {
                player2.Name = "Computer";
                PlayGame(false);
            }

        }

        public static void PlayGame(bool humanOpponent)
        {
            ConsoleKeyInfo keyPressed;

            int roundNumber = 1;

            while (player1.Score < 3 && player2.Score < 3)
            {
                Console.Clear();
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Round {roundNumber}... {player1.Name} Score: {player1.Score}   {player2.Name} Score : {player2.Score}");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                player1.CurrentGesture = Gesture.GetPlayerGesture(player1);

                if (humanOpponent)
                {
                    Console.WriteLine();
                    player2.CurrentGesture = Gesture.GetPlayerGesture(player2);
                }
                else
                {
                    player2.CurrentGesture = Gesture.GetComputerGesture();
                }

                Gesture.DetermineWinner(player1, player2);

                roundNumber++;
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{player1.Name} Score : {player1.Score} - {player2.Name} Score : {player2.Score}");

            Console.ForegroundColor = ConsoleColor.Green;

            if (player1.Score > player2.Score)
                Console.WriteLine($"Winner is : {player1.Name}");
            else
                Console.WriteLine($"Winner is : {player2.Name}");

            Console.ForegroundColor = ConsoleColor.White;

            ScreenOutputs.PressEnterToContinue(false);

            Environment.Exit(0);
        }
    }
}

