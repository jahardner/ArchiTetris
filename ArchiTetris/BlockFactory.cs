using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ArchiTetris
{
    class BlockFactory
    {
        private Color[] colors = new Color[] {Color.Crimson, Color.DeepSkyBlue, Color.HotPink, Color.SpringGreen,
        Color.MediumPurple, Color.Goldenrod, Color.Chocolate};

        public BlockIF getColoredBlock(string str)
        {
            WrapperBlock wBlock = new WrapperBlock(getBlock(str), getColor());
            return (BlockIF)wBlock;
        }

        private BlockIF getBlock(string str)
        {
            Type blockType = Type.GetType("ArchiTetris." + str);
            return (BlockIF)Activator.CreateInstance(blockType);
        }

        private Color getColor()
        {
            Random r = new Random();
            return colors[r.Next(colors.Length)];
        }
    }
}
