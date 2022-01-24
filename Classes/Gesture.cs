using System;
using System.Collections.Generic;
using System.Linq;
using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    public static class Gesture
    {
        /// <summary>
        /// Get a random handsignal for the computer player
        /// </summary>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        public static HandSignal GetComputerHandSignal(Game selectedGame)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            HandSignal randomHandSignal = HandSignal.Rock;

            switch(selectedGame)
            {
                case Game.Classic:
                    randomHandSignal = (HandSignal)rnd.Next(1, 3);
                    break;
                    
                case Game.Enhanced:
                    randomHandSignal = (HandSignal)rnd.Next(1, 4);
                    break;

                case Game.BigBang:
                    randomHandSignal = (HandSignal)rnd.Next(1, 7);

                    // Exclude flamethrower for this game.
                    while (randomHandSignal == HandSignal.FlameThrower)
                        randomHandSignal = (HandSignal)rnd.Next(1, 7);
                    break;
            }

            return randomHandSignal;
        }

        /// <summary>
        /// Display possible choices based on the selected game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="handSignalConfig"></param>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        public static HandSignal GetPlayerHandSignal(Player player, List<HandSignalConfig> handSignalConfig, Game selectedGame)
        {
            ConsoleKeyInfo keyPressed;
            HandSignal selectedGesture = HandSignal.Rock;
            int signalNumber = 1;

            foreach (HandSignalConfig configItem in handSignalConfig)
            {
                Console.WriteLine($"[{signalNumber}] {configItem.HandSignal}");
                signalNumber++;
            }

            Console.WriteLine($"{player.Name} - please make a choice:");
           
            switch (selectedGame)
            {
                case Game.Classic:
                    do
                    {
                        keyPressed = Console.ReadKey(true);
                    } while (keyPressed.Key != ConsoleKey.D1 &&
                        keyPressed.Key != ConsoleKey.D2 &&
                        keyPressed.Key != ConsoleKey.D3);

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                            selectedGesture = HandSignal.Rock;
                            break;
                        case ConsoleKey.D2:
                            selectedGesture = HandSignal.Paper;
                            break;
                        case ConsoleKey.D3:
                            selectedGesture = HandSignal.Scissors;
                            break;
                    }

                    break;

                case Game.Enhanced:
                    do
                    {
                        keyPressed = Console.ReadKey(true);
                    } while (keyPressed.Key != ConsoleKey.D1 &&
                        keyPressed.Key != ConsoleKey.D2 &&
                        keyPressed.Key != ConsoleKey.D3 &&
                        keyPressed.Key != ConsoleKey.D4);

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                            selectedGesture = HandSignal.Rock;
                            break;
                        case ConsoleKey.D2:
                            selectedGesture = HandSignal.Paper;
                            break;
                        case ConsoleKey.D3:
                            selectedGesture = HandSignal.Scissors;
                            break;
                        case ConsoleKey.D4:
                            selectedGesture = HandSignal.FlameThrower;
                            break;
                    }
                    break;

                case Game.BigBang:
                    do
                    {
                        keyPressed = Console.ReadKey(true);
                    } while (keyPressed.Key != ConsoleKey.D1 &&
                        keyPressed.Key != ConsoleKey.D2 &&
                        keyPressed.Key != ConsoleKey.D3 &&
                        keyPressed.Key != ConsoleKey.D4 &&
                        keyPressed.Key != ConsoleKey.D5);

                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                            selectedGesture = HandSignal.Rock;
                            break;
                        case ConsoleKey.D2:
                            selectedGesture = HandSignal.Paper;
                            break;
                        case ConsoleKey.D3:
                            selectedGesture = HandSignal.Scissors;
                            break;
                        case ConsoleKey.D4:
                            selectedGesture = HandSignal.Lizard;
                            break;
                        case ConsoleKey.D5:
                            selectedGesture = HandSignal.Spock;
                            break;

                    }
                    break;
            }
                            
            return selectedGesture;
        }

        /// <summary>
        /// Determine who won the round
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="handSignalConfig"></param>
        public static void DetermineWinner(Player player1, Player player2, List<HandSignalConfig> handSignalConfig)
        {
            Console.Clear();

            if (player1.CurrentHandSignal == player2.CurrentHandSignal)
                OutputWinner(player1, player2, Winner.Tie);
            else
            {
                HandSignalConfig config = handSignalConfig.Where(c => c.HandSignal == player1.CurrentHandSignal).FirstOrDefault();
                if (config.Beats.Contains(player2.CurrentHandSignal))
                {
                    OutputWinner(player1, player2, Winner.Player1);
                    player1.Score++;
                }
                else
                {
                    OutputWinner(player1, player2, Winner.Player2);
                    player2.Score++;
                }                            
            }
        }

        /// <summary>
        /// Display the winner on the console screen and incement scores
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="winner"></param>
        public static void OutputWinner(Player player1, Player player2, Winner winner)
        {
            ScreenOutputs.RockPaperScissor();

            ScreenOutputs.CentreConsoleOutput($"{player1.Name} : {player1.CurrentHandSignal} ---- {player2.Name} : {player2.CurrentHandSignal}");

            Console.ForegroundColor = ConsoleColor.Green;

            if (winner == Winner.Tie)
                ScreenOutputs.CentreConsoleOutput("It is a tie!!");
            else if (winner == Winner.Player1)
                ScreenOutputs.CentreConsoleOutput($"Winner is {player1.Name}!!");
            else
                ScreenOutputs.CentreConsoleOutput($"Winner is {player2.Name}!!");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            ScreenOutputs.PressEnterToContinue(true);
        }
    }
}
