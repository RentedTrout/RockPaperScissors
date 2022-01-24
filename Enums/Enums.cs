namespace RockPaperScissors.Enums
{
    public class Enums
    {
        public enum Game 
        {
            Classic = 1,
            Enhanced = 2,
            BigBang = 3
        }

        public enum HandSignal
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
            FlameThrower = 4,            
            Lizard = 5,
            Spock = 6
        }

        public enum Winner
        {
            Tie = 1,
            Player1 = 2,
            Player2 = 3
        }
    }
}
