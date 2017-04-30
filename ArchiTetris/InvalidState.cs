using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class InvalidState : BoardState
    {
        BoardState prevState;
        bool doneFalling = false;

        public InvalidState(ArchiTetris e, BoardState p)
        {
            if (e.lastMove == "left")
            {
                e.currentBlock.setBlocksPos(e.currentBlock.getX() + 1, e.currentBlock.getY());
            } else if (e.lastMove == "right")
            {
                e.currentBlock.setBlocksPos(e.currentBlock.getX() - 1, e.currentBlock.getY());
            } else if (e.lastMove == "down")
            {
                doneFalling = true;
            }

            prevState = p;
            nextState(e);
        }

        public override BoardState nextState(ArchiTetris e)
        {
            BoardState newState = prevState;
            if (doneFalling)
            {
                DoneState dState = new DoneState(e);
                newState = (BoardState)dState;
            }
            e.bState = prevState;
            return newState;
        }
    }
}
