using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandEvaluator.IOHandler;
using PokerHandEvaluator.Player_Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluatorTests
{
    [TestClass]
    public class IOHandlerTests
    {
        private IOHandler _ioHandler;
        [TestInitialize]
        public void Setup()
        {
            _ioHandler = new IOHandler(new DummyCorrectConsoleInput());
        }

        [TestMethod]
        public void Parse_Player_Name_Properly()
        {
            var name = _ioHandler.ParsePlayerNameInput();
            Assert.AreEqual("Will", name);
        }

        [TestMethod]
        public void Parse_Player()
        {
            var player = _ioHandler.ParseInputForPlayer();
            Assert.AreEqual("Will", player.Name);
        }

        [TestMethod]
        public void Parse_Player_Hand_WithGoodInput()
        {
            var hand = _ioHandler.ParsePlayerHandInput();
            var handComparison = new List<ICard>()
            {
                new Card{CardRank = Rank.Ten, CardSuit = Suit.Spades},
                new Card{CardRank = Rank.Eight, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Hearts}
            };
            handComparison.Sort();
            for(int i = 0; i < hand.Cards.Count; i++)
            {
                Assert.AreEqual(handComparison[i].CardRank, hand.Cards[i].CardRank);
                Assert.AreEqual(handComparison[i].CardSuit, hand.Cards[i].CardSuit);
            }
        }

        [TestMethod]
        public void Parse_Rank_With_Multiple_Inputs()
        {
            Assert.AreEqual(Rank.Invalid, IOHandler.parseRank("ads"));
            Assert.AreEqual(Rank.Ace, IOHandler.parseRank("a"));
            Assert.AreEqual(Rank.Ace, IOHandler.parseRank("A"));
            Assert.AreEqual(Rank.King, IOHandler.parseRank("k"));
            Assert.AreEqual(Rank.King, IOHandler.parseRank("K"));
            Assert.AreEqual(Rank.Queen, IOHandler.parseRank("q"));
            Assert.AreEqual(Rank.Queen, IOHandler.parseRank("Q"));
            Assert.AreEqual(Rank.Jack, IOHandler.parseRank("j"));
            Assert.AreEqual(Rank.Jack, IOHandler.parseRank("J"));
            Assert.AreEqual(Rank.Ten, IOHandler.parseRank("10"));
            Assert.AreEqual(Rank.Nine, IOHandler.parseRank("9"));
            Assert.AreEqual(Rank.Eight, IOHandler.parseRank("8"));
            Assert.AreEqual(Rank.Seven, IOHandler.parseRank("7"));
            Assert.AreEqual(Rank.Six, IOHandler.parseRank("6"));
            Assert.AreEqual(Rank.Five, IOHandler.parseRank("5"));
            Assert.AreEqual(Rank.Four, IOHandler.parseRank("4"));
            Assert.AreEqual(Rank.Three, IOHandler.parseRank("3"));
            Assert.AreEqual(Rank.Two, IOHandler.parseRank("2"));
        }

        [TestMethod]
        public void Parse_Suit_With_Multiple_Inputs()
        {
            Assert.AreEqual(Suit.Clubs, IOHandler.parseSuit('C'));
            Assert.AreEqual(Suit.Clubs, IOHandler.parseSuit('c'));
            Assert.AreEqual(Suit.Diamonds, IOHandler.parseSuit('D'));
            Assert.AreEqual(Suit.Diamonds, IOHandler.parseSuit('d'));
            Assert.AreEqual(Suit.Hearts, IOHandler.parseSuit('H'));
            Assert.AreEqual(Suit.Hearts, IOHandler.parseSuit('h'));
            Assert.AreEqual(Suit.InValid, IOHandler.parseSuit('b'));
            Assert.AreEqual(Suit.Spades, IOHandler.parseSuit('S'));
            Assert.AreEqual(Suit.Spades, IOHandler.parseSuit('s'));

        }
    }

    public class DummyCorrectConsoleInput : IConsoleInputs
    {
        public string GetCards()
        {
            return "10S 8D AD QD JH";
        }

        public char GetContinuePrompt()
        {
            return 'y';
        }

        public string GetName()
        {
            return "Will";
        }
    }
}
