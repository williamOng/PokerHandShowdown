using PokerHandEvaluator.Player_Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.RulesEngine
{
    public interface IPlayerHandEvaluator
    {
        IList<IPlayer> PromoteWinners(IList<IPlayer> players);
        IList<IPlayer> ProcessTies(IList<IPlayer> players);
        IList<IPlayer> DetermineHighestCard(IList<IPlayer> players);

    }

    public enum HandRank
    {
        Flush = 4,
        ThreeOfAKind = 1,
        OnePair = 2,
        HighCard = 0
    }
}
