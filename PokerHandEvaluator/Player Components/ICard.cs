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
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight =  8,
        Nine = 9,
        Ten = 10,
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
