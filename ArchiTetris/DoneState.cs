using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class DoneState : BoardState
    {
        public DoneState (ArchiTetris e)
        {
            // place current block on numArray
            List<KeyValuePair<int, int>> poses = e.currentBlock.getPos();
            WrapperBlock wBlock = (WrapperBlock)e.currentBlock;
            foreach (KeyValuePair<int, int> p in poses)
            {
                e.boardArray[p.Key, p.Value] = e.getColorNum(wBlock.c);
            }

            // check for clearing lines
            for (int i = 19; i > 0; i--)
            {
                bool wholeRow = true;
                for (int j = 0; j < 10; j++)
                {
                    if (e.boardArray[i, j] == 0)
                    {
                        wholeRow = false;
                    }
                }
                if (wholeRow)
                {
                    for (int k = i; k > 1; k--)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            e.boardArray[k, j] = e.boardArray[k - 1, j];
                        }
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        e.boardArray[0, j] = 0;
                    }
                }
            }
        }

        public override BoardState nextState(ArchiTetris e)
        {
            WaitingState newState = new WaitingState(e);
            e.bState = (BoardState)newState;
            return newState;
        }
    }
}
