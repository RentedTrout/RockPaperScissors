using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    public class Player
    {
        public string Name { get; set; }

        public int Score { get; set; } = 0;

        public GestureChoice CurrentGesture { get; set; }
    }
}
