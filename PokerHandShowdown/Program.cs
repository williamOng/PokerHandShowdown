using PokerHandEvaluator.IOHandler;
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
            
            IOHandler game = new IOHandler(new ConsoleInputs());
            game.GameStart();
        }
        
    }
}
