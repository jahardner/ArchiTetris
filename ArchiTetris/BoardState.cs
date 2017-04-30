using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public abstract class BoardState
    {
        public abstract BoardState nextState(ArchiTetris e);
    }
}
