using System;
using System.Collections.Generic;

namespace Poker_Counter.Data
{
    public class RoundGenerator
    {
        List<PlayerRound> rounds;
        const int cardsCount = 54;
        int maxOrder;
        int countNonDefaultRounds;
        Player player;
        public RoundGenerator(Player player) {
            this.player = player;
        }
        public List<PlayerRound> Generate(int playersCount)
        {
            rounds = new List<PlayerRound>();

            maxOrder = Convert.ToInt32(Math.Floor(Convert.ToDouble(cardsCount / playersCount)));

            for(int i = 0; i < maxOrder; i++) {
                AddRound(Round.Classic, i + 1);
            }
            for(int i = 0; i < playersCount - 2; i++) {
                AddRound(Round.Classic, maxOrder);
            }
            for(int i = 0; i < maxOrder; i++) {
                AddRound(Round.Classic, maxOrder - i);
            }
            for(int i = 0; i < playersCount - 1; i++) {
                AddRound(Round.Classic, 1);
            }

            countNonDefaultRounds = Convert.ToInt32(Math.Floor(Convert.ToDouble(playersCount / 2)));

            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(Round.Trumpless, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(Round.Blind, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(Round.Minimal, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(Round.Gold, maxOrder);
            }

            return rounds;
        }
        void AddRound(Round roundName, int maxOrder){
            rounds.Add(new PlayerRound(player) { RoundName = roundName, MaxOrder = maxOrder });
        }
    }
}
    
