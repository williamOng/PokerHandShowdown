using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerHandEvaluator.Player_Components;

namespace PokerHandEvaluator.RulesEngine
{
    public class PlayerHandEvaluator : IPlayerHandEvaluator
    {
        public IPlayer[] PromoteWinner(IList<IPlayer> players)
        {
            foreach(var player in players)
            {
                //var players;
            }
            return new IPlayer[3];
        }

        private bool DetermineFlush(IHand hand)
        {
            var suits = hand.Cards.Select(x => x.CardSuit).Distinct();
            if (suits.Count() == 1)
            {
                return true;
            }
            return false;
        }

        private bool DetermineThreeOfAKind(IHand hand)
        {
            var cards = hand.Cards.GroupBy(card => card.CardRank).Where(group => group.Count() == 3);
            if (cards.Any())
            {
                return true;
            }
            return false;
        }

        private bool DetermineOnePair(IHand hand)
        {
            var cards = hand.Cards.GroupBy(card => card.CardSuit).Where(group => group.Count() == 2);
            if (cards.Any())
            {
                return true;
            }
            return true;
        }

    }
}
