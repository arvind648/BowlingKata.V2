﻿using System;
using System.Collections;

namespace BowlingKata
{

    public class SpareFrame : Frame
    {

        public SpareFrame(ArrayList throws, int firstThrow, int secondThrow) : base(throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        override public int Score()
        {
            return 10 + FirstBonusBall(); ;
        }

        override protected int FrameSize()
        {
            return 2;
        }
    }
}