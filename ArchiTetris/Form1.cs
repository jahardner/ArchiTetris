using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiTetris
{
    public partial class Form1 : Form
    {
        PictureBox[,] boardTiles = new PictureBox[10, 20];
        CompositeBlock nextBlock;
        CompositeBlock currentBlock;
        BlockFactory fact = new BlockFactory();
        String[] blockList = new String[] { "Square", "Bar", "T", "L", "N" };

        public Form1()
        {
            InitializeComponent();
            int x = 0, y = 0;
            for (int i = 0; i < 10; i++)
            {
                y = 0;
                for (int j = 0; j < 20; j++)
                {
                    boardTiles[i, j] = new PictureBox();
                    boardTiles[i, j].Size = new Size(20,20);
                    board.Controls.Add(boardTiles[i, j]);
                    boardTiles[i, j].Location = new Point(x,y);
                    y += 20;
                }
                x += 20;
            }

            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                blockChooser.Items.Add(blockList[r.Next(blockList.Length)]);
            }

            //currentBlock = fact.getColoredBlock("SquareBlock");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Down)
            {
                // for each absBlock A in currentBlock
                    // for each simpleBlock S in A
                        // change each singleblock's location down one
            }
            else if (e.KeyChar == (char)Keys.Up)
            {
                // rotate through rotate magic
            }
            else if (e.KeyChar == (char)Keys.Left)
            {

            }
            else if (e.KeyChar == (char)Keys.Right)
            {

            }
            e.Handled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
