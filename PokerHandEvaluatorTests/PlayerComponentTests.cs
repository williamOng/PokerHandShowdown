using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandEvaluator.Player_Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluatorTests
{
    [TestClass]
    public class PlayerComponentTests 
    {

        private List<ICard> _cards;
        [TestInitialize]
        public void Setup()
        {
            _cards = new List<ICard>
            {
                new Card{ CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{ CardRank = Rank.King, CardSuit = Suit.Diamonds},
                new Card{ CardRank = Rank.Jack, CardSuit = Suit.Hearts},
                new Card{ CardRank = Rank.Four, CardSuit = Suit.Spades},
                new Card{ CardRank = Rank.Queen, CardSuit = Suit.Spades},
            };
        }

        [TestMethod]
        public void Cards_Are_Sorted_Properly()
        {

            _cards.Sort();

            Assert.AreEqual(_cards[0].CardRank, Rank.Ace);
            Assert.AreEqual(_cards[1].CardRank, Rank.King);
            Assert.AreEqual(_cards[2].CardRank, Rank.Queen);
            Assert.AreEqual(_cards[3].CardRank, Rank.Jack);
            Assert.AreEqual(_cards[4].CardRank, Rank.Four);
        }

        [TestMethod]
        public void Player_Hand_Has_Correct_Highest_Card()
        {
            var hand = new Hand();
            Assert.IsNull(hand.HighestCard);
            hand.Cards = _cards;
            Assert.AreEqual(hand.HighestCard.CardRank, Rank.Ace);
        }

        [TestMethod]
        public void Player_Is_Set_Up_Properly()
        { 
            var hand = new Hand();
            hand.Cards = _cards;
            var player = new Player("TestName", hand);
            Assert.AreEqual(player.Name, "TestName");
            Assert.AreEqual(player.PlayerHand, hand);

        }

        [TestMethod]
        public void Custom_Card_Comparison_Is_Proper()
        {
            var ace = new Card { CardRank = Rank.Ace, CardSuit = Suit.Clubs };
            var king = new Card { CardRank = Rank.King, CardSuit = Suit.Diamonds };
            var ace2 = new Card { CardRank = Rank.Ace, CardSuit = Suit.Clubs };
            Assert.AreEqual(-1, ace.CompareTo(king));
            Assert.AreEqual(0, ace.CompareTo(ace2));
            Assert.AreEqual(1, king.CompareTo(ace));
        }
    }
}
