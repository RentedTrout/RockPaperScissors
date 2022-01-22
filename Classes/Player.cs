using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    /// <summary>
    /// Class to hold player information
    /// Player 1 is always human
    /// Player 2 could be human or Computer
    /// </summary>
    public class Player
    {
        public string Name { get; set; }

        public int Score { get; set; } = 0;

        public GestureChoice CurrentGesture { get; set; }
    }
}
