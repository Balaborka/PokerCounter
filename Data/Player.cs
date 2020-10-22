using System;
using System.Collections.Generic;

namespace Poker_Counter.Data
{
    public class Player
    {
        public string Name { get; set; }
        public int Summary { get; set; }
        public List<PlayerRound> Rounds { get; set; }

        public void Recalculate() {
            var score = 0;
            foreach(var round in Rounds) {
                if (round.Order != null) {
                    round.ResultScore = round.RoundScore + score;
                    score = round.ResultScore;
                }
            }
        }
    }
}