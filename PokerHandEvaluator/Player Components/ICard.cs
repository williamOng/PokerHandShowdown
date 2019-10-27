using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public interface ICard
    {
        Rank CardRank { get; set; }
        Suit CardSuit { get; set; }
    }

    public enum Rank
    {
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight =  7,
        Nine = 8,
        Ten = 9,
        Jack = 10,
        Queen = 11,
        King = 12,
        Ace = 13,
        Invalid = -1
    } 

    public enum Suit
    {
        Clubs = 1,
        Hearts = 2,
        Spades = 3,
        Diamonds = 4,
        InValid = -1
    }
}
