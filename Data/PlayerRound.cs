using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {
        public int MaxOrder { get; set; }
        public int RoundScore { get; set; }
        public int ResultScore { get; set; }
        public Round RoundName { get; set; }
        int? order;
        public int? Order
        {
            get => order;
            set
            {
                order = value;
                CalculateScore();
            }
        }
        int? trick;
        public int? Trick
        {
            get => trick;
            set
            {
                trick = value;
                CalculateScore();
            }
        }
        private Player player;

        public PlayerRound(Player player)
        {
            this.player = player;
        }

        private void CalculateScore()
        {
            if (Trick != null && Order != null)
            {
                if (RoundName == Round.Minimal)
                {
                    if (Trick > 0)
                        RoundScore = -((int)Trick * 10);
                    else
                        RoundScore = 5;
                    return;
                }
                if (RoundName == Round.Gold)
                {
                    if (Trick > 0)
                        RoundScore = ((int)Trick * 10);
                    else
                        RoundScore = -5;
                    return;
                }
                else
                {
                    var res = (int)Trick - (int)Order;
                    if (res < 0)
                        RoundScore = res * 10;
                    else if (res > 0)
                        RoundScore = -(res * 5);
                    else RoundScore = (int)Trick * 10;
                }
                player.Recalculate();
            }
        }
    }
}