using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class SquareBlock : CompositeBlock
    {
        public SquareBlock()
        {
            blocks.Add(new DoubleBlock());
            blocks.Add(new DoubleBlock());
        }

        public override void setBlocksPos(int x, int y)
        {
            DoubleBlock b1 = (DoubleBlock)blocks[0];
            DoubleBlock b2 = (DoubleBlock)blocks[1];
            setX(x);
            setY(y);
            b1.setBlocksPos(x, y - 1);
            b2.setBlocksPos(x, y);
            blocks[0] = b1;
            blocks[1] = b2;
        }
    }
}
