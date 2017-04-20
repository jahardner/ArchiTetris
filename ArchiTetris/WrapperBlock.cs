using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArchiTetris
{
    class WrapperBlock : CompositeBlock
    {
        CompositeBlock cBlock;
        Color c;

        public WrapperBlock(CompositeBlock cb, Color c)
        {
            cBlock = cb;
            this.c = c;
        }
    }
}
