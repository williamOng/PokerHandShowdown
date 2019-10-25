using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public class Player : IPlayer
    {
        public Player(string name, IHand playerHand)
        {
            Name = name;
            PlayerHand = playerHand;
        }

        private static string testc(string test) =>
        test switch
        {
            "asd" => "asd",
            _ => "asd"

        };

        public string Name { get; private set; }
        public IHand PlayerHand { get; private set; }
    }
}
