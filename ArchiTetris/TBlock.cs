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

        public override void rotate(bool cw)
        {
            if (cw)
            {
                this.rot++;
            }
            else
            {
                this.rot--;
            }
            if (this.rot > 4)
            {
                this.rot = 1;
            }
            else if (this.rot < 1)
            {
                this.rot = 4;
            }
            this.setBlocksPos(this.x, this.y);
        }

        public override void setBlocksPos(int x, int y)
        {
            SingleBlock b1 = (SingleBlock)blocks[0];
            SingleBlock b2 = (SingleBlock)blocks[1];
            DoubleBlock b3 = (DoubleBlock)blocks[2];
            this.x = x;
            this.y = y;
            switch (this.rot)
            {
                case 1:
                    b1.setBlocksPos(x, y - 1);
                    b2.setBlocksPos(x + 1, y);
                    b3.setBlocksPos(x - 1, y);
                    break;
                case 2:
                    b1.setBlocksPos(x, y - 1);
                    b2.setBlocksPos(x, y + 1);
                    b3.setBlocksPos(x, y);
                    break;
                case 3:
                    b1.setBlocksPos(x - 1, y);
                    b2.setBlocksPos(x, y + 1);
                    b3.setBlocksPos(x, y);
                    break;
                case 4:
                    b1.setBlocksPos(x, y - 1);
                    b2.setBlocksPos(x, y + 1);
                    b3.setBlocksPos(x - 1, y);
                    break;
            }
            blocks[0] = b1;
            blocks[1] = b2;
            blocks[2] = b3;
            
        }
    }
}
