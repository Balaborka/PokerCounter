using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {
        public int MaxOrder { get; set; }
        public int Score { get; set; }
        public int? CurrentSummary { get; set; }
        public Round RoundName { get; set; }
        public int? Order { get; set; }
        int? trick;
        public int? Trick
        {
            get => trick; set
            {
                trick = value;
                if (Trick != null)
                {
                    if (RoundName == Round.Minimal)
                    {
                        if (Trick > 0)
                            Score = -((int)Trick * 10);
                        else
                            Score = 5;
                        return;
                    }
                    if (RoundName == Round.Gold)
                    {
                        if (Trick > 0)
                            Score = ((int)Trick * 10);
                        else
                            Score = -5;
                        return;
                    }
                    else
                    {
                        var res = (int)Trick - (int)Order;
                        if (res < 0)
                            Score = res * 10;
                        else if (res > 0)
                            Score = -(res * 5);
                        else Score = (int)Trick * 10;
                    }
                }
            }
        }
    }
}