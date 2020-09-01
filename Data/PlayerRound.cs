using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {
        public int CurrentSummary { get { return curSum + Result; } set { } }
        public Round RoundName { get; set; }
        public int Order { get; set; }
        public int Trick { get; set; }
        public int Result
        {
            get {
                var res = Trick - Order;
                if (RoundName == Round.Minimal)
                {
                    if (res > 0)
                        return -(res * 10);
                    else
                        return 5;
                }
                if (RoundName == Round.Gold)
                {
                    if (res > 0)
                        return (res * 10);
                    else
                        return -5;
                }
                if (res < 0)
                    return -(res * 10);
                else if (res > 0)
                    return -(res * 5);
                return Trick * 10;
            }
        }
        int curSum;
        public PlayerRound(int sum) {
            curSum = sum;
        }
    }
}