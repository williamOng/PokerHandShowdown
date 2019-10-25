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
        
    } 

    public enum Suit
    {
        Clubs = 1,
        Hearts = 2,
        Spades = 3,
        Diamonds = 4
    }
}
