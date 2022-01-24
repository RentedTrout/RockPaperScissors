using RockPaperScissors.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static RockPaperScissors.Enums.Enums;

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
        public static List<HandSignalConfig> HandSignalConfigs;

        public static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            ScreenOutputs.SplashScreen();

            Console.ForegroundColor = ConsoleColor.White;
            player1.Name = ScreenOutputs.GetPlayer1Name();

            Game selectedGame = ScreenOutputs.GetGameToPlay();
            ConfigureGameHandSignals(selectedGame);

            if (ScreenOutputs.GetPlayer1Opponent())
            {
                player2.Name = ScreenOutputs.GetPlayer2Name();
                PlayGame(true, selectedGame);
            }
            else
            {
                player2.Name = "Computer";
                PlayGame(false, selectedGame);
            }

        }


        public static void ConfigureGameHandSignals(Game selectedGame)
        {
            switch (selectedGame)
            {
                case Game.Classic:
                    // Configure what hand signal beats what...
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
                        }
                    };

                    break;

                case Game.Enhanced:
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
                    break;

                case Game.BigBang:
                    HandSignalConfigs = new()
                    {
                        new HandSignalConfig
                        {
                            HandSignal = HandSignal.Rock,
                            Beats = new List<HandSignal>()
                                { HandSignal.Scissors, HandSignal.Lizard }
                        },
                        new HandSignalConfig
                        {
                            HandSignal = HandSignal.Paper,
                            Beats = new List<HandSignal>()
                                { HandSignal.Rock, HandSignal.Spock }
                        },
                        new HandSignalConfig
                        {
                            HandSignal = HandSignal.Scissors,
                            Beats = new List<HandSignal>()
                                { HandSignal.Paper, HandSignal.Lizard }
                        },
                        new HandSignalConfig
                        {
                            HandSignal = HandSignal.Lizard,
                            Beats = new List<HandSignal>()
                                { HandSignal.Paper, HandSignal.Spock}
                        },
                        new HandSignalConfig
                        {
                            HandSignal = HandSignal.Spock,
                            Beats = new List<HandSignal>()
                                { HandSignal.Scissors, HandSignal.Rock}
                        },
                    };
                    break;

            }
        }

        public static void PlayGame(bool humanOpponent, Game selectedGame)
        {
            int roundNumber = 1;

            while (player1.Score < 3 && player2.Score < 3)
            {
                Console.Clear();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Round {roundNumber}... {player1.Name} Score: {player1.Score}   {player2.Name} Score : {player2.Score}");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                player1.CurrentHandSignal = Gesture.GetPlayerHandSignal(player1, HandSignalConfigs, selectedGame);

                if (humanOpponent)
                {
                    Console.WriteLine();
                    player2.CurrentHandSignal = Gesture.GetPlayerHandSignal(player2, HandSignalConfigs, selectedGame);
                }
                else
                {
                    player2.CurrentHandSignal = Gesture.GetComputerHandSignal(selectedGame);
                }

                Gesture.DetermineWinner(player1, player2, HandSignalConfigs);

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