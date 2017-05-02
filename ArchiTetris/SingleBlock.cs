using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    class SingleBlock : AbsBlock
    {

        public override void rotate(bool clockwise)
        {
        }

        public override List<KeyValuePair<int, int>> getPos()
        {
            List<KeyValuePair<int, int>> poses = new List<KeyValuePair<int, int>>();
            poses.Add(new KeyValuePair<int, int>(getX(), getY()));
            return poses;
        }

        public override void setBlocksPos(int x, int y)
        {
            setX(x);
            setY(y);
        }
    }
}
