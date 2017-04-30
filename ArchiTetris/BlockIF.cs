using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public interface BlockIF
    {
        List<KeyValuePair<int, int>> getPos();
        void setBlocksPos(int x, int y);
        int getX();
        int getY();
    }
}
