using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class ValidState : BoardState
    {

        public ValidState(ArchiTetris e)
        {
            nextState(e);
        }

        public override void nextState(ArchiTetris e)
        {
            BoardState newState;
            FallingState fState = new FallingState(e);
            newState = (BoardState)fState;
            e.bState = newState;
            e.lastMove = "";
        }
    }
}
