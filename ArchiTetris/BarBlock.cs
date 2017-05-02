using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class BarBlock : CompositeBlock
    {
        public BarBlock()
        {
            blocks.Add(new SingleBlock());
            blocks.Add(new SingleBlock());
            blocks.Add(new SingleBlock());
            blocks.Add(new SingleBlock());
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
            this.setBlocksPos(getX(), getY());
        }

        public override void setBlocksPos(int x, int y)
        {
            SingleBlock b1 = (SingleBlock)blocks[0];
            SingleBlock b2 = (SingleBlock)blocks[1];
            SingleBlock b3 = (SingleBlock)blocks[2];
            SingleBlock b4 = (SingleBlock)blocks[3];
            setX(x);
            setY(y);
            switch (this.rot)
            {
                case 1:
                    b1.setBlocksPos(x, y);
                    b2.setBlocksPos(x + 1, y);
                    b3.setBlocksPos(x - 1, y);
                    b4.setBlocksPos(x + 2, y);
                    break;
                case 2:
                    b1.setBlocksPos(x, y);
                    b2.setBlocksPos(x, y - 1);
                    b3.setBlocksPos(x, y + 1);
                    b4.setBlocksPos(x, y + 2);
                    break;
                case 3:
                    b1.setBlocksPos(x, y + 1);
                    b2.setBlocksPos(x + 1, y + 1);
                    b3.setBlocksPos(x - 1, y + 1);
                    b4.setBlocksPos(x + 2, y + 1);
                    break;
                case 4:
                    b1.setBlocksPos(x - 1, y);
                    b2.setBlocksPos(x - 1, y - 1);
                    b3.setBlocksPos(x - 1, y + 1);
                    b4.setBlocksPos(x - 1, y + 2);
                    break;
            }
            blocks[0] = b1;
            blocks[1] = b2;
            blocks[2] = b3;
            blocks[3] = b4;
        }
    }
}
