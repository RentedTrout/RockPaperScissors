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
        public static HandSignal GetComputerHandSignal(int itemCount)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            return (HandSignal)rnd.Next(1, itemCount);
        }

        /// <summary>
        /// Get handsignal for the computer player which would have beat the last option it chose.
        /// </summary>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        public static HandSignal GetComputerHandSignal(HandSignal previousHandSignal, List<HandSignalConfig> handSignalConfigs)
        {
            return handSignalConfigs.Where(h => h.Beats.Contains(previousHandSignal)).FirstOrDefault().HandSignal;           
        }

        /// <summary>
        /// Display possible choices based on the selected game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="handSignalConfig"></param>
        /// <param name="selectedGame"></param>
        /// <returns></returns>
        public static HandSignal GetPlayerHandSignal(Player player, List<HandSignalConfig> handSignalConfig)
        {
            ConsoleKeyInfo keyPressed;
            HandSignal selectedGesture = HandSignal.Rock;
            int signalNumber = 1;

            // Get the longest string length of the available handsignals for proper centering
            int longestLength = handSignalConfig.OrderByDescending(s => s.HandSignal.ToString().Length)
                .First().HandSignal.ToString().Length;

            // Check length against the input string text
            if (longestLength < $"{player.Name} - please make a choice:".Length)
                longestLength = $"{player.Name} - please make a choice:".Length;

            foreach (HandSignalConfig configItem in handSignalConfig)
            {
                ScreenOutputs.CentreConsoleOutput($"[{signalNumber}] {configItem.HandSignal}", longestLength);
                signalNumber++;
            }            
            ScreenOutputs.CentreConsoleOutputWithFollowingInput($"{player.Name} - please make a choice:");            

            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.D1 && keyPressed.Key != ConsoleKey.NumPad1 &&
                keyPressed.Key != ConsoleKey.D2 && keyPressed.Key != ConsoleKey.NumPad2 &&
                keyPressed.Key != ConsoleKey.D3 && keyPressed.Key != ConsoleKey.NumPad3 &&
                keyPressed.Key != ConsoleKey.D4 && keyPressed.Key != ConsoleKey.NumPad4);

            switch (keyPressed.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    selectedGesture = HandSignal.Rock;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    selectedGesture = HandSignal.Paper;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    selectedGesture = HandSignal.Scissors;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    selectedGesture = HandSignal.FlameThrower;
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
        public static void DetermineWinner(int roundNumber, Player player1, Player player2, List<HandSignalConfig> handSignalConfig)
        {
            Console.Clear();

            if (player1.CurrentHandSignal == player2.CurrentHandSignal)
                OutputWinner(roundNumber, player1, player2, Winner.Tie);
            else
            {
                HandSignalConfig config = handSignalConfig.Where(c => c.HandSignal == player1.CurrentHandSignal).FirstOrDefault();
                if (config.Beats.Contains(player2.CurrentHandSignal))
                {
                    OutputWinner(roundNumber, player1, player2, Winner.Player1);
                    player1.Score++;
                }
                else
                {
                    OutputWinner(roundNumber, player1, player2, Winner.Player2);
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
        public static void OutputWinner(int roundNumber, Player player1, Player player2, Winner winner)
        {
            ScreenOutputs.DisplayRoundNumberAndCurrentScore(roundNumber, player1, player2);
            
            ScreenOutputs.RockPaperScissor();

            ScreenOutputs.CentreConsoleOutput($"{player1.Name} : {player1.CurrentHandSignal} - {player2.Name} : {player2.CurrentHandSignal}");

            Console.ForegroundColor = ConsoleColor.Green;

            if (winner == Winner.Tie)
                ScreenOutputs.CentreConsoleOutput("It is a tie!!");
            else if (winner == Winner.Player1)
                ScreenOutputs.CentreConsoleOutput($"Winner is {player1.Name}!!");
            else
                ScreenOutputs.CentreConsoleOutput($"Winner is {player2.Name}!!");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            ScreenOutputs.PressEnterToContinue();
        }        
    }
}
