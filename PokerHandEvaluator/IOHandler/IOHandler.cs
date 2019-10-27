using PokerHandEvaluator.Player_Components;
using PokerHandEvaluator.RulesEngine;
using System;
using System.Collections.Generic;

namespace PokerHandEvaluator.IOHandler
{
    public class IOHandler
    {

        private const int minNumberOfPlayers = 2;
        private readonly IConsoleInputs _consoleInputs;
     
        public IOHandler(IConsoleInputs consoleInputs)
        {
            _consoleInputs = consoleInputs;
        }

        public void GameStart()
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
                            char userInput = _consoleInputs.GetContinuePrompt();
                            if (userInput == 'y' || userInput == 'Y')
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
                var winners = evaluator.GetWinners(players);
                Console.WriteLine($"Winner(s): ");
                foreach (var winner in winners)
                {
                    Console.WriteLine(winner.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when playing {ex}");
                throw;
            }

        }

        public IPlayer ParseInputForPlayer()
        {
            var playerName = ParsePlayerNameInput();
            var hand = ParsePlayerHandInput();
            return new Player(playerName, hand);
        }

        public IHand ParsePlayerHandInput()
        {
            var cardsInput = "";
            var cards = new List<ICard>();
            var hand = new Hand();

            while (string.IsNullOrEmpty(cardsInput) || cards.Count != PlayerHandEvaluator.ValidNumberOfCards)
            {
                Console.WriteLine($"Please Enter 5 valid cards in the form of Rank-Suit ex) AD (Ace of Diamonds)"); // Input expected will be in the form of AD QD 4S... as shown in the example
                cardsInput = _consoleInputs.GetCards();
                cards = parseCards(cardsInput);
            }
            hand.Cards = cards;
            hand.Cards.Sort();//Sort for easier processing
            return hand;
        } 

        private List<ICard> parseCards(string rawInput)
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

                if (finalOutput.Count > PlayerHandEvaluator.ValidNumberOfCards)//Only take into account 5 cards
                {
                    return new List<ICard>();
                }
            }

            return finalOutput;
        }

        public static Rank parseRank(string rank) => // C# 8 Syntax
        rank switch
        {
            "a" => Rank.Ace,
            "k" => Rank.King,
            "q" => Rank.Queen,
            "j" => Rank.Jack,
            "A" => Rank.Ace,
            "K" => Rank.King,
            "Q" => Rank.Queen,
            "J" => Rank.Jack,
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

        public static Suit parseSuit(char suit) => // C# 8 Syntax
        suit switch
        {
            'd' => Suit.Diamonds,
            'c' => Suit.Clubs,
            's' => Suit.Spades,
            'h' => Suit.Hearts,
            'D' => Suit.Diamonds,
            'C' => Suit.Clubs,
            'S' => Suit.Spades,
            'H' => Suit.Hearts,
            _ => Suit.InValid
        };

        public string ParsePlayerNameInput()
        {
            string playerNameInput = "";
            while (string.IsNullOrEmpty(playerNameInput))
            {
                Console.WriteLine("Please Enter A valid Player Name");
                playerNameInput = _consoleInputs.GetName();
            }
            return playerNameInput;
        } 
    }
}
