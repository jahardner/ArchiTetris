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

        public CompositeBlock getColoredBlock(string str)
        {
            WrapperBlock wBlock = new WrapperBlock(getBlock(str), getColor());
            return (CompositeBlock)wBlock;
        }

        private CompositeBlock getBlock(string str)
        {
            Type blockType = Type.GetType("ArchiTetris." + str);
            return (CompositeBlock)Activator.CreateInstance(blockType);
        }

        private Color getColor()
        {
            Random r = new Random();
            return colors[r.Next(colors.Length)];
        }
    }
}
