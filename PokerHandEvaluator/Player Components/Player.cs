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

        public string Name { get; private set; }
        public IHand PlayerHand { get; private set; }


    }
}
