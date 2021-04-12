using System;
using System.Collections.Generic;
using System.Text;

namespace _4.BetsBusinessEntities.Wrappers
{
    public class Bets_Wrapper
    {
        public long IdBet { get; set; }
        public string IdUser { get; set; }
        public long IdRoulette { get; set; }
        public int BetValue { get; set; }
        public int BetNumber { get; set; }
        public short BetColor { get; set; }
        public bool IsColorBet { get; set; }
        public DateTime DateBet { get; set; }
    }
}
