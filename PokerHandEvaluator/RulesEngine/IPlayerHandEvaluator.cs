using PokerHandEvaluator.Player_Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.RulesEngine
{
    public interface IPlayerHandEvaluator
    {
        IList<IPlayer> GetWinners(IList<IPlayer> players);
        IList<IPlayer> ProcessTies(IList<IPlayer> players);
        IList<IPlayer> DeterminePlayersWithHighestCard(IList<IPlayer> players);

    }
}
