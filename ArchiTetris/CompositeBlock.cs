using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiTetris
{
    abstract class CompositeBlock : AbsBlock
    {
        public List<BlockIF> blocks = new List<BlockIF>();
        public int rot = 1;

        // idea: pass in vals for key block, set pos of other blocks based on them and shape
        public override abstract void setBlocksPos(int x, int y);

        public override void rotate(bool clockwise)
        {

        }
        
        public override List<KeyValuePair<int, int>> getPos()
        {
            List<KeyValuePair<int,int>> poses = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < blocks.Count; i++)
            {
                DoubleBlock db = blocks[i] as DoubleBlock;
                SingleBlock sb = blocks[i] as SingleBlock;
                if (db != null)
                {
                    // double block
                    List<KeyValuePair<int, int>> dbpos = db.getPos();
                    for (int j = 0; j < dbpos.Count; j++)
                    {
                        poses.Add(dbpos[i]);
                    }
                } else if (sb != null)
                {
                    // is singleblock
                    List<KeyValuePair<int, int>> sbpos = sb.getPos();
                    poses.Add(sbpos[0]);
                }
            }
            return poses;
        }
    }
}
