using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class SingleBlock : AbsBlock
    {
        public override List<KeyValuePair<int, int>> getPos()
        {
            List<KeyValuePair<int, int>> poses = new List<KeyValuePair<int, int>>();
            poses.Add(new KeyValuePair<int, int>(x, y));
            return poses;
        }

        public override void setBlocksPos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
