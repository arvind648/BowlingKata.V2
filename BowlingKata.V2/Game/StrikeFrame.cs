﻿using System;
using System.Collections;

namespace BowlingKata
{

    public class StrikeFrame : Frame
    {

        public StrikeFrame(ArrayList throws) : base(throws)
        {
            throws.Add(10);
        }

        override public int Score()
        {
            return 10 + FirstBonusBall() + SecondBonusBall();
        }

        override protected int FrameSize()
        {
            return 1;
        }
    }
}