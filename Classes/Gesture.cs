using System;
using System.Threading;
using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    public static class Gesture
    {
        public static GestureChoice GetComputerGesture()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int gestureValue = rnd.Next(1, 3);
            return (GestureChoice)gestureValue;
        }

        public static GestureChoice GetPlayerGesture(Player player)
        {
            ConsoleKeyInfo keyPressed;
            GestureChoice selectedGesture = GestureChoice.Rock;

            foreach (GestureChoice item in Enum.GetValues(typeof(GestureChoice)))
            {
                if ((int)item > 0)
                    Console.WriteLine($"[{(int)item}] {item}");
            }

            Console.WriteLine($"{player.Name} - please make a choice:");

            do
            {
                keyPressed = Console.ReadKey(true);
            } while (keyPressed.Key != ConsoleKey.D1 &&
                        keyPressed.Key != ConsoleKey.D2 &&
                        keyPressed.Key != ConsoleKey.D3);

            switch (keyPressed.Key)
            {
                case ConsoleKey.D1:
                    selectedGesture = GestureChoice.Rock;
                    break;
                case ConsoleKey.D2:
                    selectedGesture = GestureChoice.Paper;
                    break;
                case ConsoleKey.D3:
                    selectedGesture = GestureChoice.Scissors;
                    break;
            }

            return selectedGesture;
        }

        public static void DetermineWinner(Player player1, Player player2)
        {
            Console.Clear();

            if (player1.CurrentGesture == player2.CurrentGesture)
                OutputWinner(player1, player2, Winner.Tie);
            else
            {
                switch (player1.CurrentGesture)
                {
                    case GestureChoice.Rock:
                        if (player2.CurrentGesture == GestureChoice.Paper)
                        {
                            OutputWinner(player1, player2, Winner.Player2);
                            player2.Score++;
                        }
                        else if (player2.CurrentGesture == GestureChoice.Paper)
                        {
                            OutputWinner(player1, player2, Winner.Player1);
                            player1.Score++;
                        }
                        break;

                    case GestureChoice.Paper:
                        if (player2.CurrentGesture == GestureChoice.Scissors)
                        {
                            OutputWinner(player1, player2, Winner.Player2);
                            player2.Score++;
                        }
                        else if (player2.CurrentGesture == GestureChoice.Rock)
                        {
                            OutputWinner(player1, player2, Winner.Player1);
                            player1.Score++;
                        }
                        break;

                    case GestureChoice.Scissors:
                        if (player2.CurrentGesture == GestureChoice.Rock)
                        {
                            OutputWinner(player1, player2, Winner.Player2);
                            player2.Score++;
                        }
                        else if (player2.CurrentGesture == GestureChoice.Paper)
                        {
                            OutputWinner(player1, player2, Winner.Player1);
                            player1.Score++;
                        }
                        break;
                }
            }
        }

        public static void OutputWinner(Player player1, Player player2, Winner winner)
        {
            ScreenOutputs.RockPaperScissor();

            ScreenOutputs.CentreConsoleOutput($"{player1.Name} : {player1.CurrentGesture} ---- {player2.Name} : {player2.CurrentGesture}");
            
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
