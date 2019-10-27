using PokerHandEvaluator.Player_Components;
using PokerHandEvaluator.RulesEngine;
using System;
using System.Collections.Generic;

namespace PokerHandEvaluator
{
    public static class IOHandler
    {

        private const int minNumberOfPlayers = 2;
        public static void GameStart()
        {
            bool settingUp = true;
            var players = new List<IPlayer>();
            try
            {
                while (players.Count < minNumberOfPlayers || settingUp) // Minimum of two players
                {       
                    var player = ParseInputForPlayer();
                    players.Add(player);   
                    if(players.Count >= minNumberOfPlayers)
                    {
                        Console.WriteLine("Add More Players? enter y or n");
                        bool idleUserInput = true;
                        while (idleUserInput)
                        {
                            char userInput = Console.ReadKey().KeyChar;
                            if(userInput == 'y' || userInput == 'Y')
                            {
                                idleUserInput = false;
                            }
                            else if (userInput == 'n' || userInput == 'N')
                            {
                                idleUserInput = false;
                                settingUp = false;
                            }
                            Console.WriteLine();
                        }
                    }
                }
                var evaluator = new PlayerHandEvaluator();
                var winners = evaluator.PromoteWinners(players);
                Console.WriteLine($"Winner(s): ");
                foreach (var winner in winners)
                {
                    Console.WriteLine(winner.Name);
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured when playing");
                throw;
            }

        }

        private static IPlayer ParseInputForPlayer()
        {
            var playerName = ParsePlayerNameInput();
            var hand = ParsePlayerHandInput();
            return new Player(playerName, hand);
        }

        private static IHand ParsePlayerHandInput()
        {
            var cardsInput = "";
            var cards = new List<ICard>();
            var hand = new Hand();

            while (string.IsNullOrEmpty(cardsInput) || cards.Count != PlayerHandEvaluator.ValidNumberOfCards)
            {
                Console.WriteLine($"Please Enter 5 valid cards in the form of Rank-Suit ex) AD (Ace of Diamonds)"); // Input expected will be in the form of AD QD 4S... as shown in the example
                cardsInput = Console.ReadLine().ToString();
                cards = parseCards(cardsInput);
            }
            hand.Cards = cards;
            hand.Cards.Sort();//Sort for easier processing
            return hand;
        } 

        public static List<ICard> parseCards(string rawInput)
        {
            var finalOutput = new List<ICard>();

            var separatedRawInput = rawInput.ToLower().Split(' ');
            foreach(var candidate in separatedRawInput)
            {
                var card = new Card();
                var rank = Rank.Invalid;
                var suit = Suit.InValid;
                if (candidate.Length > 3 || candidate.Length < 2)
                {
                    break;
                }
                if(candidate.Length == 3)//handle 10 rank
                {
                    rank = parseRank(candidate.Substring(0, 2));
                    suit = parseSuit(candidate[2]);
                }
                else
                {
                    rank = parseRank(candidate.Substring(0, 1));
                    suit = parseSuit(candidate[1]);
                }
                if(rank == Rank.Invalid || suit == Suit.InValid)
                {
                    break;
                }
                card.CardRank = rank;
                card.CardSuit = suit;
                finalOutput.Add(card);

                if (finalOutput.Count > 5)//Only take into account 5 cards
                {
                    return new List<ICard>();
                }
            }

            return finalOutput;
        }

        public static Rank parseRank(string rank) => 
        rank switch
        {
            "a" => Rank.Ace,
            "k" => Rank.King,
            "q" => Rank.Queen,
            "j" => Rank.Jack,
            "10" => Rank.Ten,
            "9" => Rank.Nine,
            "8" => Rank.Eight,
            "7" => Rank.Seven,
            "6" => Rank.Six,
            "5" => Rank.Five,
            "4" => Rank.Four,
            "3" => Rank.Three,
            "2" => Rank.Two,
            _ => Rank.Invalid
        };

        public static Suit parseSuit(char suit) =>
        suit switch
        {
            'd' => Suit.Diamonds,
            'c' => Suit.Clubs,
            's' => Suit.Spades,
            'h' => Suit.Hearts,
            _ => Suit.InValid
        };

        private static string ParsePlayerNameInput()
        {
            string playerNameInput = "";
            while (string.IsNullOrEmpty(playerNameInput))
            {
                Console.WriteLine("Please Enter A valid Player Name");
                playerNameInput = Console.ReadLine().ToString();
            }
            return playerNameInput;
        } 
    }
}
