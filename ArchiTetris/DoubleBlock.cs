using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class DoubleBlock : AbsBlock
    {
        public SingleBlock[] blocks = new SingleBlock[2];

        public DoubleBlock()
        {
            blocks[0] = new SingleBlock();
            blocks[1] = new SingleBlock();
        }

        public override List<KeyValuePair<int, int>> getPos()
        {
            List<KeyValuePair<int, int>> poses = new List<KeyValuePair<int, int>>();
            poses.Add(new KeyValuePair<int, int>(blocks[0].getX(), blocks[0].getY()));
            poses.Add(new KeyValuePair<int, int>(blocks[1].getX(), blocks[1].getY()));
            return poses;
        }

        public override void setBlocksPos(int nx, int ny)
        {
            setX(nx);
            setY(ny);
            blocks[0].setX(nx);
            blocks[0].setY(ny);
            blocks[1].setX(nx+1);
            blocks[1].setY(ny);
        }
    }
}
