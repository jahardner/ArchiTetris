using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class TBlock : CompositeBlock
    {
        public TBlock()
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
            SingleBlock rightBlock = (SingleBlock)blocks[1];
            rightBlock.setBlocksPos(x + 1, y + 1);
            blocks[1] = rightBlock;
            DoubleBlock leftBlock = (DoubleBlock)blocks[2];
            leftBlock.setBlocksPos(x - 1, y + 1);
            blocks[2] = leftBlock;
        }
    }
}
