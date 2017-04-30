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
