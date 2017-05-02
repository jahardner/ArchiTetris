using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    abstract class AbsBlock : BlockIF
    {
        private int x, y;
        public abstract List<KeyValuePair<int, int>> getPos();
        public abstract void setBlocksPos(int x, int y);
        public abstract void rotate(bool clockwise);

        public AbsBlock()
        {
        }

        public virtual int getX()
        {
            return x;
        }

        public virtual int getY()
        {
            return y;
        }

        public virtual void setX(int x)
        {
            this.x = x;
        }

        public virtual void setY(int y)
        {
            this.y = y;
        }
    }
}
