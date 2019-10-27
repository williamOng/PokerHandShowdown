using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.IOHandler
{
    public class ConsoleInputs : IConsoleInputs
    {
        public string GetCards()
        {
            return Console.ReadLine().ToString();
        }

        public char GetContinuePrompt()
        {
            return Console.ReadKey().KeyChar;
        }

        public string GetName()
        {
            return Console.ReadLine().ToString();
        }
    }
}
