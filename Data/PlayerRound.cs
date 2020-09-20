using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {
        public int CurrentSummary { get; set; }
        public Round RoundName { get; set; }
        int order;
        public int Order { get => order;  set {
                order = value;    
        } }
        int trick;
        public int Trick { get => trick; set {
            trick = value;
            CurrentSummary = curSum + Result;
        } }
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