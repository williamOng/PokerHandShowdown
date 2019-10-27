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

        //public static IComparer<ICard> sortRank()
        //{
        //    return new SortRank();
        //}

        public static IComparer<ICard> sortSuit()
        {
            return new SortSuit();
        }

        private class SortSuit : IComparer<ICard>
        {

            public int Compare(ICard x, ICard y)
            {
                if (x.CardSuit > y.CardSuit)
                    return 1;
                if (x.CardSuit < y.CardSuit)
                    return -1;
                else
                    return 0;
            }
        }

        //private class SortRank : IComparer<ICard>
        //{

        //    public int Compare(ICard x, ICard y)
        //    {
        //        if (x.CardRank > y.CardRank)
        //            return 1;
        //        if (x.CardRank < y.CardRank)
        //            return -1;
        //        else
        //            return 0;
        //    }
        //}

    }
}
