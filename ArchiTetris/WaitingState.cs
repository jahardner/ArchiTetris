using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class WaitingState : BoardState
    {
        public WaitingState(ArchiTetris e)
        {
            e.currentBlock = e.rwl.getBlock();
            e.currentBlock.setBlocksPos(5, 0);
            nextState(e);
        }

        public override BoardState nextState(ArchiTetris e)
        {
            FallingState newState = new FallingState(e);
            e.bState = newState;
            return newState;
        }
    }
}
