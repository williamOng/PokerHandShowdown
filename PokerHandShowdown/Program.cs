using PokerHandEvaluator;
using PokerHandEvaluator.Player_Components;
using PokerHandEvaluator.RulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowdown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new Hand();
            test.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var test2 = new Hand();
            test2.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var test3 = new Hand();
            test3.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},   
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", test),
                new Player("Player2", test2),
                new Player("Player3", test3)
            };
            //var evaluator = new PlayerHandEvaluator();
            //var test4 = evaluator.TryDetermineOnePairWinners(players, out var winners);
            Console.WriteLine(test2.HighestCard.CardRank);
            
            IOHandler.GameStart();
            //Console.ReadKey();
        }
        
    }
}
