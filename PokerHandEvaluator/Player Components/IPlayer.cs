using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public interface IPlayer
    {
        string Name { get; }
        
        IHand PlayerHand { get; }
    }
}
