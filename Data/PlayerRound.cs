using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {
        public int MaxOrder { get; set; }
        public int Score { get; 
        set; }
        public int CurrentSummary { get; set; }
        public Round RoundName { get; set; }
        int order = 0;
        public int Order
        {
            get => order;
            set { order = value; }
        }
        int trick;
        public int Trick
        {
            get => trick; set
            {
                trick = value;
                var res = Trick - Order;
                if (RoundName == Round.Minimal)
                {
                    if (res > 0)
                        Score = -(res * 10);
                    else
                        Score = 5;
                }
                if (RoundName == Round.Gold)
                {
                    if (res > 0)
                        Score = (res * 10);
                    else
                        Score = -5;
                }
                if (res < 0)
                    Score = -(res * 10);
                else if (res > 0)
                    Score = -(res * 5);
                else Score = Trick * 10;
            }
        }
    }
}