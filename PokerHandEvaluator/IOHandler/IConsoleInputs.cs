using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.IOHandler
{
    public interface IConsoleInputs 
    {
        string GetName();

        string GetCards();

        char GetContinuePrompt();
    }
}
