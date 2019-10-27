using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public class Card : ICard, IComparable
    {

        public Rank CardRank { get; set; }
        public Suit CardSuit { get; set; }


        public int CompareTo(object obj)
        {
            if(!(obj is Card))
            {
                throw new ArgumentException("Argument not a card");
            }
            var card = obj as Card;
            if (this.CardRank < card.CardRank)
                return 1;
            if (this.CardRank > card.CardRank)
                return -1;
            return 0;
        }

    }
}
