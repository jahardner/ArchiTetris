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
            blocks.Add(new SingleBlock());
            blocks.Add(new SingleBlock());
            blocks.Add(new DoubleBlock());
        }

        public override void setBlocksPos(int x, int y)
        {
            this.x = x;
            this.y = y;
            SingleBlock topBlock = (SingleBlock)blocks[0];
            topBlock.setBlocksPos(x, y);
            blocks[0] = topBlock;
            SingleBlock midBlock = (SingleBlock)blocks[1];
            midBlock.setBlocksPos(x, y + 1);
            blocks[1] = midBlock;
            DoubleBlock bottomBlock = (DoubleBlock)blocks[2];
            bottomBlock.setBlocksPos(x, y + 2);
            blocks[2] = bottomBlock;
        }
    }
}
