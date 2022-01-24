using RockPaperScissors.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors
{
    class Program
    {
        // Maximize the console screen
        #region Max Console Screen
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        #endregion

        public static Player player1; 
        public static Player player2;

        public static List<HandSignalConfig> HandSignalConfigs;

        public static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            do
            {
                Console.Clear();

                player1 = new Player();
                player2 = new Player();

                ScreenOutputs.SplashScreen();

                Console.ForegroundColor = ConsoleColor.White;
                player1.Name = ScreenOutputs.GetPlayerName(1);
                player1.Type = PlayerType.Human;

                ConfigureGameHandSignals();

                PlayerType selectedPlayerType = ScreenOutputs.GetPlayer1Opponent();

                switch (selectedPlayerType)
                {
                    case PlayerType.Human:
                        player2.Name = ScreenOutputs.GetPlayerName(2);
                        player2.Type = PlayerType.Human;
                        PlayGame(selectedPlayerType);
                        break;

                    case PlayerType.Computer:
                        player2.Name = "Computer";
                        player2.Type = PlayerType.Computer;
                        PlayGame(selectedPlayerType);
                        break;

                    case PlayerType.RandomComputer:
                        player2.Name = "Random Computer";
                        player2.Type = PlayerType.RandomComputer;
                        PlayGame(selectedPlayerType);
                        break;
                }
            } while (ScreenOutputs.PlayAgain());
        }

        public static void ConfigureGameHandSignals()
        {
            HandSignalConfigs = new()
            {
                new HandSignalConfig
                {
                    HandSignal = HandSignal.Rock,
                    Beats = new List<HandSignal>()
                                { HandSignal.Scissors }
                },
                new HandSignalConfig
                {
                    HandSignal = HandSignal.Paper,
                    Beats = new List<HandSignal>()
                                { HandSignal.Rock }
                },
                new HandSignalConfig
                {
                    HandSignal = HandSignal.Scissors,
                    Beats = new List<HandSignal>()
                                { HandSignal.Paper }
                },
                new HandSignalConfig
                {
                    HandSignal = HandSignal.FlameThrower,
                    Beats = new List<HandSignal>()
                                { HandSignal.Paper}
                }
            };
        }

        public static void PlayGame(PlayerType selectedPlayerType)
        {

            int roundNumber = 1;

            while (player1.Score < 3 && player2.Score < 3)
            {
                Console.Clear();                

                ScreenOutputs.DisplayRoundNumberAndCurrentScore(roundNumber, player1, player2);

                Console.ForegroundColor = ConsoleColor.White;

                player1.CurrentHandSignal = Gesture.GetPlayerHandSignal(player1, HandSignalConfigs);

                if (selectedPlayerType == PlayerType.Human)
                {
                    Console.WriteLine();
                    player2.CurrentHandSignal = Gesture.GetPlayerHandSignal(player2, HandSignalConfigs);
                }
                else
                {
                    // If Random computer player
                    // or regular computer player and it is only round 1 so there is no previous section
                    if (selectedPlayerType == PlayerType.RandomComputer ||
                        (player2.PreviousHandSignal is null && player2.Type == PlayerType.Computer))
                        player2.CurrentHandSignal = Gesture.GetComputerHandSignal(HandSignalConfigs.Count);
                    else
                        player2.CurrentHandSignal = Gesture.GetComputerHandSignal((HandSignal)player2.PreviousHandSignal, HandSignalConfigs);

                    // Set previous selection
                    player2.PreviousHandSignal = player2.CurrentHandSignal;
                }

                Gesture.DetermineWinner(roundNumber, player1, player2, HandSignalConfigs);

                roundNumber++;
            }

            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2, (Console.WindowHeight / 2) - 2);

            Console.ForegroundColor = ConsoleColor.Red;

            ScreenOutputs.CentreConsoleOutput($"{player1.Name} Score : {player1.Score} - {player2.Name} Score : {player2.Score}");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();

            if (player1.Score > player2.Score)
                ScreenOutputs.CentreConsoleOutput($"Winner is : {player1.Name}");
            else
                ScreenOutputs.CentreConsoleOutput($"Winner is : {player2.Name}");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            ScreenOutputs.PressEnterToContinue();
        }
    }
}