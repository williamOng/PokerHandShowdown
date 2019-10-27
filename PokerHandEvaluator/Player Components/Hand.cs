using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public class Hand : IHand
    {
        public List<ICard> Cards { get; set; }

        public ICard HighestCard => Cards?.OrderByDescending(i => i.CardRank).FirstOrDefault();
    }
}
