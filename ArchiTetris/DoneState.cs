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
                            e.boardArray[k, i] = e.boardArray[k - 1, i];
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        e.boardArray[0, i] = 0;
                    }
                }
            }
        }

        public override BoardState nextState(ArchiTetris e)
        {
            WaitingState newState = new WaitingState(e);
            e.bState = newState;
            return newState;
        }
    }
}
