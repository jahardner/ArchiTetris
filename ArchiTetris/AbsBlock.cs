using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    abstract class AbsBlock : BlockIF
    {
        public int x, y;
        public abstract List<KeyValuePair<int, int>> getPos();
        public abstract void setBlocksPos(int x, int y);

        public AbsBlock()
        {
            x = 0;
            y = 0;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }
}
