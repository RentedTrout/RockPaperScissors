using System.Collections.Generic;
using static RockPaperScissors.Enums.Enums;

namespace RockPaperScissors.Classes
{
    public class HandSignalConfig
    {        
        public HandSignal HandSignal { get; set; }
        public List<HandSignal> Beats { get; set; }
    }
}
