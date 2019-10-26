using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public class Card : ICard
    {

        public Rank CardRank { get; set; }
        public Suit CardSuit { get; set; }
    }
}
