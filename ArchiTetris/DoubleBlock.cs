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
            poses.Add(new KeyValuePair<int, int>(blocks[0].x, blocks[0].y));
            poses.Add(new KeyValuePair<int, int>(blocks[1].x, blocks[1].y));
            return poses;
        }

        public override void setBlocksPos(int x, int y)
        {
            this.x = x;
            this.y = y;
            blocks[0].x = x;
            blocks[0].y = y;
            blocks[1].x = x + 1;
            blocks[1].y = y;
        }
    }
}
