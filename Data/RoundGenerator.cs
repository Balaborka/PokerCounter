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
        public List<PlayerRound> Generate(Player player, int playersCount)
        {
            rounds = new List<PlayerRound>();

            maxOrder = Convert.ToInt32(Math.Floor(Convert.ToDouble(cardsCount / playersCount)));

            for(int i = 0; i < maxOrder; i++) {
                AddRound(player, Round.Classic, i + 1);
            }
            for(int i = 0; i < playersCount - 2; i++) {
                AddRound(player, Round.Classic, maxOrder);
            }
            for(int i = 0; i < maxOrder; i++) {
                AddRound(player, Round.Classic, maxOrder - i);
            }
            for(int i = 0; i < playersCount - 1; i++) {
                AddRound(player, Round.Classic, 1);
            }

            countNonDefaultRounds = Convert.ToInt32(Math.Floor(Convert.ToDouble(playersCount / 2)));

            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(player, Round.Trumpless, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(player, Round.Blind, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(player, Round.Minimal, maxOrder);
            }
            for (int i = 0; i < countNonDefaultRounds; i++) {
                AddRound(player, Round.Gold, maxOrder);
            }

            return rounds;
        }
        void AddRound(Player player, Round roundName, int maxOrder){
            rounds.Add(new PlayerRound(player) { RoundName = roundName, MaxOrder = maxOrder });
        }
    }
}
    
