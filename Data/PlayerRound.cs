using System;

namespace Poker_Counter.Data
{
    public class PlayerRound
    {        
        public int MaxOrder { get; set; }
        public int RoundScore { get; set; }
        public int ResultScore { get; set; }
        public Round RoundName { get; set; }
        public int? Order { get; set; }
        private Player player;
        int? trick;

        public PlayerRound(Player player) {
            this.player = player;
        }
        public int? Trick
        {
            get => trick;
            set
            {
                trick = value;
                if (Trick != null)
                {
                    CalculateScore();
                    player.Recalculate();
                }
            }
        }

        private void CalculateScore()
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
        }
    }
}