using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class ValidState : BoardState
    {
        BoardState prevState;

        public ValidState(ArchiTetris e, BoardState p)
        {
            prevState = p;
            nextState(e);
        }

        public override BoardState nextState(ArchiTetris e)
        {
            BoardState newState;
            FallingState fState = new FallingState(e);
            newState = (BoardState)fState;
            e.bState = newState;
            e.lastMove = "";
            return newState;
        }
    }
}
