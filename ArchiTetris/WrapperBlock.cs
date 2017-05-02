using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArchiTetris
{
    class WrapperBlock : AbsBlock
    {
        public BlockIF block;
        public Color c;

        public override void rotate(bool clockwise)
        {
            this.block.rotate(clockwise);
        }

        public WrapperBlock(BlockIF cb, Color c)
        {
            block = cb;
            this.c = c;
        }

        public override int getX()
        {
            return block.getX();
        }

        public override int getY()
        {
            return block.getY();
        }

        public override List<KeyValuePair<int, int>> getPos()
        {
            return block.getPos();
        }

        public override void setBlocksPos(int x, int y)
        {
            block.setBlocksPos(x, y);
        }
    }
}
