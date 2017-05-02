using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public class CheckState : BoardState
    {
        bool collision = false;
        BoardState prevState;

        public CheckState(ArchiTetris e, BoardState p)
        {
            prevState = p;
            List<KeyValuePair<int, int>> poses = e.currentBlock.getPos();
            foreach (KeyValuePair<int, int> pos in poses)
            {
                if (e.boardArray[pos.Key, pos.Value] != 0)
                {
                    // collision
                    collision = true;
                }
            }
            nextState(e);
        }

        public override BoardState nextState(ArchiTetris e)
        {
            BoardState newState;
            if (collision)
            {
                InvalidState iState = new InvalidState(e, prevState);
                newState = (BoardState)iState;
            } else
            {
                ValidState vState = new ValidState(e, prevState);
                newState = (BoardState)vState;
            }
            return newState;
        }
    }
}
