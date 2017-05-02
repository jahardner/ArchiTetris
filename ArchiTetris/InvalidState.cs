using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class InvalidState : BoardState
    {
        bool doneFalling = false;

        public InvalidState(ArchiTetris e)
        {
            if (e.lastMove == "left")
            {
                e.currentBlock.setBlocksPos(e.currentBlock.getX() + 1, e.currentBlock.getY());
            }
            else if (e.lastMove == "right")
            {
                e.currentBlock.setBlocksPos(e.currentBlock.getX() - 1, e.currentBlock.getY());
            }
            else if (e.lastMove == "rotate")
            {
                e.currentBlock.rotate(false);
            }
            else if (e.lastMove == "down")
            {
                e.currentBlock.setBlocksPos(e.currentBlock.getX(), e.currentBlock.getY() - 1);
                doneFalling = true;
                if (e.currentBlock.getY() <= 1)
                {
                    e.gameOver = true;
                    e.pause();
                }
            }
            
            nextState(e);
        }

        public override void nextState(ArchiTetris e)
        {
            BoardState newState;
            FallingState fState = new FallingState(e);
            newState = (BoardState)fState;
            if (doneFalling)
            {
                DoneState dState = new DoneState(e);
                newState = (BoardState)dState;
            }
            e.lastMove = "";
        }
    }
}
