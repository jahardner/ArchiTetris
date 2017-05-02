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
            
        }

        public override void nextState(ArchiTetris e)
        {
            e.currentBlock = e.rwl.getBlock();
            e.currentBlock.setBlocksPos(4, 1);
            FallingState newState = new FallingState(e);
            e.bState = newState;
        }
    }
}
