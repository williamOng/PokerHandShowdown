﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandEvaluator.Player_Components
{
    public interface IHand
    {
        List<ICard> Cards { get; set; }
        ICard HighestCard { get; }

    }
}
