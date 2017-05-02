using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class LBlock : CompositeBlock
    {
        public LBlock()
        {
            blocks.Add(new DoubleBlock());
            blocks.Add(new DoubleBlock());
        }

        public override void setBlocksPos(int x, int y)
        {
            setX(x);
            setY(y);
            DoubleBlock topBlock = (DoubleBlock)blocks[0];
            topBlock.setBlocksPos(x, y);
            blocks[0] = topBlock;
            DoubleBlock bottomBlock = (DoubleBlock)blocks[1];
            bottomBlock.setBlocksPos(x, y + 1);
            blocks[1] = bottomBlock;
        }
    }
}
