using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public class FallingState : BoardState
    {
        public FallingState(ArchiTetris e)
        {
            e.resetBoard();
            List<KeyValuePair<int, int>> poses = e.currentBlock.getPos();
            WrapperBlock wBlock = (WrapperBlock)e.currentBlock;
            foreach (KeyValuePair<int, int> p in poses)
            {
                e.boardTiles[p.Key, p.Value].BackColor = wBlock.c;
            }
        }

        public override BoardState nextState(ArchiTetris e)
        {
            CheckState newState = new CheckState(e, this);
            return newState;
        }
    }
}
