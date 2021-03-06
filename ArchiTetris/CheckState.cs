﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public class CheckState : BoardState
    {
        bool collision = false;

        public CheckState(ArchiTetris e)
        {
            List<KeyValuePair<int, int>> poses = e.currentBlock.getPos();
            foreach (KeyValuePair<int, int> pos in poses)
            {
                if (pos.Key < 0 || pos.Key >= 10 || pos.Value < 0 || pos.Value >= 20)
                {
                    collision = true; // sort of a collision, but actually out of bounds
                }
                else if (e.boardArray[pos.Key, pos.Value] != 0)
                {
                    // collision
                    collision = true;
                }
            }
            nextState(e);
        }

        public override void nextState(ArchiTetris e)
        {
            BoardState newState;
            if (collision)
            {
                InvalidState iState = new InvalidState(e);
                newState = (BoardState)iState;
            } else
            {
                ValidState vState = new ValidState(e);
                newState = (BoardState)vState;
            }
        }
    }
}
