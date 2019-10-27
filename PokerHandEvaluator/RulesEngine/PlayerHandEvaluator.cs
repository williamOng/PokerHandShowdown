using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokerHandEvaluator.Player_Components;

namespace PokerHandEvaluator.RulesEngine
{
    public class PlayerHandEvaluator : IPlayerHandEvaluator
    {
        public const int ValidNumberOfCards = 5;

        public IList<IPlayer> GetWinners(IList<IPlayer> players)
        {
            bool anyFlushWinners = TryDetermineFlushWinners(players, out var flushWinners);
            if (anyFlushWinners)
            {
                return flushWinners;
            }
            bool anyThreeOfAKindWinners = TryDetermineThreeOfAKindWinners(players, out var threeOfAKindWinners);
            if (anyThreeOfAKindWinners)
            {
                return threeOfAKindWinners;
            }
            bool anyOnePairWinners = TryDetermineOnePairWinners(players, out var onePairWinners);
            if (anyOnePairWinners)
            {
                return onePairWinners;
            }
            return DeterminePlayersWithHighestCard(players);
            
        }

        public bool TryDetermineFlushWinners(IList<IPlayer> players, out IList<IPlayer> winners) // five cards same suit
        {
            var possibleWinners = new List<IPlayer>();
            foreach(var player in players)
            {
                var suits = player.PlayerHand.Cards.Select(x => x.CardSuit).Distinct();
                if (suits.Count() == 1)
                {
                    possibleWinners.Add(player);
                }
            }

            if (possibleWinners.Any())
            {
                winners = ProcessTies(possibleWinners);
                return true;
            }
            winners = null;
            return false;
        }

        public bool TryDetermineThreeOfAKindWinners(IList<IPlayer> players, out IList<IPlayer> winners) // 3 of the same rank
        {
            var possibleWinners = GetCardsOfSameRank(players, 3);
            if (possibleWinners.Any())
            {
                winners = ProcessTies(possibleWinners);
                return true;
            }

            winners = null;
            return false;
        }

        public bool TryDetermineOnePairWinners(IList<IPlayer> players, out IList<IPlayer> winners) // 2 of the same rank
        {
            var possibleWinners = GetCardsOfSameRank(players, 2);
            if (possibleWinners.Any())
            {
                winners = ProcessTies(possibleWinners);
                return true;
            }
            winners = null;
            return false;
        }

        private IList<IPlayer> GetCardsOfSameRank(IList<IPlayer> players, int grouping)
        {
            var possibleWinners = new List<IPlayer>();
            var max = 0;
            var newMax = 0;
            foreach (var player in players)
            {
                var cardGroups = player.PlayerHand.Cards.GroupBy(card => card.CardRank).Where(group => group.Count() == grouping);
                var cards = cardGroups.SelectMany(x => x).ToList();
                cards.Sort(); //Sort here to get the biggest rank as first value for 2 pair
                if (cards.Any())
                {
                    newMax = (int)cards.FirstOrDefault().CardRank;
                    if (newMax > max)
                    {
                        possibleWinners.Clear();
                        possibleWinners.Add(player);
                        max = newMax;
                    }else if(newMax == max)
                    {
                        possibleWinners.Add(player);
                    }
                }
            }
            return possibleWinners;
        }


        public IList<IPlayer> DeterminePlayersWithHighestCard(IList<IPlayer> players)
        {
            var filteredPlayers = new List<IPlayer>();
            var max = 0;
            for(int i = 0; i < ValidNumberOfCards; i++)//iterate through all cards of all remaining players
            {
                if (filteredPlayers.Count() == 1)
                {
                    break;
                }
                else
                {
                    filteredPlayers.Clear();
                    max = 0;
                }

                foreach (var player in players)
                {
                    var cards = player.PlayerHand.Cards;
                    cards.Sort();
                    int newMax = (int)cards[i].CardRank;
                    if(newMax > max)
                    {
                        filteredPlayers.Clear();
                        filteredPlayers.Add(player);
                        max = newMax;
                    }
                    else if (newMax == max)
                    {
                        filteredPlayers.Add(player);
                        max = newMax;
                    }
                }
            }
            if (filteredPlayers.Any())
            {
                return filteredPlayers;
            }
            return players;//everyone somehow has the same card ranks
        }

        public IList<IPlayer> ProcessTies(IList<IPlayer> players)
        { 
            if (players.Count() >= 2)
            {
                return DeterminePlayersWithHighestCard(players);
            }
            else
            {
                return players;
            }
        }
    }
}
