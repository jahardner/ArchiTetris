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
            for (int j = 19; j > 0; j--)
            {
                bool wholeRow = true;
                for (int i = 0; i < 10; i++)
                {
                    if (e.boardArray[i, j] == 0)
                    {
                        wholeRow = false;
                    }
                }
                if (wholeRow)
                {
                    for (int k = j; k > 1; k--)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            e.boardArray[i, k] = e.boardArray[i, k - 1];
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        e.boardArray[i, 0] = 0;
                    }
                }
            }
            e.resetBoard();
            nextState(e);
        }

        public override void nextState(ArchiTetris e)
        {
            WaitingState newState = new WaitingState(e);
            e.bState = newState;
        }
    }
}
