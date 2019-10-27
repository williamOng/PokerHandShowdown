using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandEvaluator.Player_Components;
using PokerHandEvaluator.RulesEngine;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandEvaluatorTests
{
    [TestClass]
    public class PlayerHandEvaluatorTests
    {
        private PlayerHandEvaluator _playerHandEvaluator;
        [TestInitialize]
        public void Setup()
        {
            _playerHandEvaluator = new PlayerHandEvaluator();
        }

        [TestMethod]
        public void Determine_One_Flush_Winner_Beetween_Two_People_With_Flush()
        {
            var HigherFlush = new Hand();
            HigherFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var LowerFlush = new Hand();
            LowerFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Two, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.King, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Diamonds}
            };
            var NoFlush = new Hand();
            NoFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner", HigherFlush),
                new Player("AlmostWinner", LowerFlush),
                new Player("Loser", NoFlush)
            };
            var flushWinners = _playerHandEvaluator.TryDetermineFlushWinners(players, out var winner);
            Assert.IsTrue(flushWinners);
            Assert.IsTrue(winner.Count == 1);
            Assert.IsTrue(winner.First().Name.Equals("Winner"));
        }

        [TestMethod]
        public void Determine_Two_Flush_Winner_Beetween_Two_People_With_Flush()
        {
            var FirstFlush = new Hand();
            FirstFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var SecondFlush = new Hand();
            SecondFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var NoFlush = new Hand();
            NoFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner1", FirstFlush),
                new Player("Winner2", SecondFlush),
                new Player("Loser", NoFlush)
            };
            var flushWinners = _playerHandEvaluator.TryDetermineFlushWinners(players, out var winner);
            Assert.IsTrue(flushWinners);
            Assert.IsTrue(winner.Count == 2);
            Assert.IsTrue(winner[0].Name.Equals("Winner1"));
            Assert.IsTrue(winner[1].Name.Equals("Winner2"));
        }

        [TestMethod]
        public void Determine_No_Flush_Winners()
        {
            var FirstFlush = new Hand();
            FirstFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Spades},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var SecondFlush = new Hand();
            SecondFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var NoFlush = new Hand();
            NoFlush.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Loser1", FirstFlush),
                new Player("Loser2", SecondFlush),
                new Player("Loser3", NoFlush)
            };
            var flushWinners = _playerHandEvaluator.TryDetermineFlushWinners(players, out var winner);
            Assert.IsFalse(flushWinners);
            Assert.IsNull(winner);
        }

        [TestMethod]
        public void Determine_One_Winner_From_Three_Of_A_Kind_Winners()
        {
            var HigherAceThree = new Hand();
            HigherAceThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Spades},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var LowerAceThree = new Hand();
            LowerAceThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var LowerThree = new Hand();
            LowerThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner", HigherAceThree),
                new Player("AlmostWinner", LowerAceThree),
                new Player("Loser", LowerThree)
            };
            var threeOfAKindWinners = _playerHandEvaluator.TryDetermineThreeOfAKindWinners(players, out var winner);
            Assert.IsTrue(threeOfAKindWinners);
            Assert.IsTrue(winner.Count == 1);
            Assert.IsTrue(winner.First().Name.Equals("Winner"));
        }

        [TestMethod]
        public void Determine_Multiple_Winners_From_Three_Of_A_Kind_Winners()
        {
            var HigherAceThree = new Hand();
            HigherAceThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Spades},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var HigherAceThree2 = new Hand();
            HigherAceThree2.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var LowerThree = new Hand();
            LowerThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner1", HigherAceThree),
                new Player("Winner2", HigherAceThree2),
                new Player("Loser", LowerThree)
            };
            var threeOfAKindWinners = _playerHandEvaluator.TryDetermineThreeOfAKindWinners(players, out var winner);
            Assert.IsTrue(threeOfAKindWinners);
            Assert.IsTrue(winner.Count == 2);
            Assert.IsTrue(winner[0].Name.Equals("Winner1"));
            Assert.IsTrue(winner[1].Name.Equals("Winner2"));
        }

        [TestMethod]
        public void Determine_No_Three_Of_A_Kind_Winners()
        {
            var HigherAceThree = new Hand();
            HigherAceThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Spades},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var LowerAceThree = new Hand();
            LowerAceThree.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.King, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var AcePairLow = new Hand();
            AcePairLow.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Loser1", HigherAceThree),
                new Player("Loser2", LowerAceThree),
                new Player("Loser3", AcePairLow)
            };
            var threeOfAKindWinners = _playerHandEvaluator.TryDetermineThreeOfAKindWinners(players, out var winner);
            Assert.IsFalse(threeOfAKindWinners);
            Assert.IsNull(winner);
        }

        [TestMethod]
        public void Determine_Higher_Pair_From_Pair_Winners()
        {
            var HighPair = new Hand();
            HighPair.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var SecondHighPair = new Hand();
            SecondHighPair.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Spades}
            };
            var LowPair = new Hand();
            LowPair.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner", HighPair),
                new Player("AlmostWinner", SecondHighPair),
                new Player("AlmostWinner2", LowPair)
            };
            var pairWinners = _playerHandEvaluator.TryDetermineOnePairWinners(players, out var winner);
            Assert.IsTrue(pairWinners);
            Assert.IsTrue(winner.Count == 1);
            Assert.IsTrue(winner.First().Name.Equals("Winner"));
        }

        [TestMethod]
        public void Determine_Multiple_Winners_From_Pair_Winners()
        {
            var HighPair = new Hand();
            HighPair.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var HighPair2 = new Hand();
            HighPair2.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var LowPair = new Hand();
            LowPair.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Winner", HighPair),
                new Player("Winner2", HighPair2),
                new Player("AlmostWinner2", LowPair)
            };
            var pairWinners = _playerHandEvaluator.TryDetermineOnePairWinners(players, out var winner);
            Assert.IsTrue(pairWinners);
            Assert.IsTrue(winner.Count == 2);
            Assert.IsTrue(winner[0].Name.Equals("Winner"));
            Assert.IsTrue(winner[1].Name.Equals("Winner2"));

        }

        [TestMethod]
        public void Determine_No_Pair_Winners()
        {
            var NoPair1 = new Hand();
            NoPair1.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var NoPair2 = new Hand();
            NoPair2.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var NoPair3 = new Hand();
            NoPair3.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Eight, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", NoPair1),
                new Player("Player2", NoPair2),
                new Player("Player3", NoPair3)
            };

            var pairWinners = _playerHandEvaluator.TryDetermineOnePairWinners(players, out var winner);
            Assert.IsFalse(pairWinners);
            Assert.IsNull(winner);
        }

        [TestMethod]
        public void Determine_One_Winner_From_Highest_Card_Winners()
        {
            var HighestCards = new Hand();
            HighestCards.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Nine, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs}
            };
            var SecondHighest = new Hand();
            SecondHighest.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Spades}
            };
            var Lowest = new Hand();
            Lowest.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Six, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Five, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Three, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Jack, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", HighestCards),
                new Player("Player2", SecondHighest),
                new Player("Player3", Lowest)
            };
            var highestCardWinner = _playerHandEvaluator.DeterminePlayersWithHighestCard(players);
            Assert.IsTrue(highestCardWinner.Count() == 1);
            Assert.AreEqual(players[0].Name, highestCardWinner[0].Name);

        }

        [TestMethod]
        public void Determine_Multiple_Winner_From_Highest_Card_Winners()
        {
            var SameCard1 = new Hand();
            SameCard1.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Spades}
            };
            var SameCard2 = new Hand();
            SameCard2.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Spades}
            };
            var NotSameCards = new Hand();
            NotSameCards.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.Two, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Three, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", SameCard1),
                new Player("Player2", SameCard2),
                new Player("Player3", NotSameCards)
            };
            var highestCardWinner = _playerHandEvaluator.DeterminePlayersWithHighestCard(players);
            Assert.IsTrue(highestCardWinner.Count() == 2);
            Assert.AreEqual(players[0].Name, highestCardWinner[0].Name);
            Assert.AreEqual(players[1].Name, highestCardWinner[1].Name);

        }

        [TestMethod]
        public void Determine_One_Winner_With_Process_Tie_With_Multiple_Possible_Winners()
        {
            var HigherCards = new Hand();
            HigherCards.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Spades}
            };
            var LowerCards = new Hand();
            LowerCards.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Three, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", HigherCards),
                new Player("Player2", LowerCards)
            };

            var winner = _playerHandEvaluator.ProcessTies(players);
            Assert.IsTrue(winner.Count() == 1);
            Assert.IsTrue(winner.First().Name == players.First().Name);

        }

        [TestMethod]
        public void Determine_One_Winner_With_Process_Tie_With_One_Winner_Inputed()
        {
            var HigherCards = new Hand();
            HigherCards.Cards = new List<ICard>
            {
                new Card{CardRank = Rank.King, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Ace, CardSuit = Suit.Diamonds},
                new Card{CardRank = Rank.Queen, CardSuit = Suit.Hearts},
                new Card{CardRank = Rank.Seven, CardSuit = Suit.Clubs},
                new Card{CardRank = Rank.Four, CardSuit = Suit.Spades}
            };
            var players = new List<IPlayer>()
            {
                new Player("Player1", HigherCards)
            };

            var winner = _playerHandEvaluator.ProcessTies(players);
            Assert.IsTrue(winner.Count() == 1);
            Assert.IsTrue(winner.First().Name == players.First().Name);
        }
    }
}
