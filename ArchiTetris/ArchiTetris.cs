using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ArchiTetris
{
    public partial class ArchiTetris : Form
    {
        Random r = new Random();
        public FallingState bState;
        public PictureBox[,] boardTiles = new PictureBox[10, 20];
        public int[,] boardArray = new int[10, 20];
        public BlockIF currentBlock;
        BlockFactory fact = new BlockFactory();
        String[] blockList = new String[] { "Square", "Bar", "T", "L", "N" };
        int[] blockFreq = new int[5] {0,0,0,0,0};
        Color[] colors = new Color[] {Color.Black, Color.Crimson, Color.DeepSkyBlue, Color.HotPink, Color.SpringGreen,
        Color.MediumPurple, Color.Goldenrod, Color.Chocolate};
        public Queue<BlockIF> nextBlocks = new Queue<BlockIF>();
        public String lastMove;
        public ReadWriteLock rwl;
        private int tooFrequent = 2;

        public ArchiTetris()
        {
            InitializeComponent();
            rwl = new ReadWriteLock(this);
            new WaitingState(this);

            int x = 0, y = 0;
            for (int i = 0; i < 10; i++)
            {
                y = 0;
                for (int j = 0; j < 20; j++)
                {
                    boardArray[i, j] = 0;
                    boardTiles[i, j] = new PictureBox();
                    boardTiles[i, j].Size = new Size(20,20);
                    board.Controls.Add(boardTiles[i, j]);
                    boardTiles[i, j].Location = new Point(x,y);
                    y += 20;
                }
                x += 20;
            }

            for (int i = 0; i < 5; i++)
            {
                blockChooser.Items.Add(blockList[r.Next(blockList.Length)]);
            }

            System.Timers.Timer tTimer = new System.Timers.Timer();
            tTimer.Elapsed += new ElapsedEventHandler(TimerEvent);
            tTimer.Interval = 1000;
            tTimer.Enabled = true;

            System.Timers.Timer moveTimer = new System.Timers.Timer();
            moveTimer.Elapsed += new ElapsedEventHandler(MoveEvent);
            moveTimer.Interval = 5000;
            moveTimer.Enabled = true;
        }

        public void resetBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    boardTiles[i, j].BackColor = getColor(boardArray[i, j]);
                }
            }
        }

        private Color getColor(int i)
        {
            return colors[i];
        }

        public int getColorNum(Color c)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if (c.Equals(colors[i]))
                {
                    return i;
                }
            }
            return 100;
        }

        private void TimerEvent(object source, ElapsedEventArgs e)
        {
            // impliment timer
        }

        private void MoveEvent(object source, ElapsedEventArgs e)
        {
            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null)
            {
                // move block down
                currentBlock.setBlocksPos(currentBlock.getX(), currentBlock.getY() + 1);
                lastMove = "down";
                new CheckState(this, bState);
            }
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (bState != null)
            {
                if (e.KeyChar == (char)Keys.Up)
                {
                    // rotate through rotate magic
                }
                else if (e.KeyChar == (char)Keys.Left)
                {
                    currentBlock.setBlocksPos(currentBlock.getX() - 1, currentBlock.getY());
                    lastMove = "left";
                    bState.nextState(this);
                }
                else if (e.KeyChar == (char)Keys.Right)
                {
                    currentBlock.setBlocksPos(currentBlock.getX() + 1, currentBlock.getY());
                    lastMove = "right";
                    bState.nextState(this);
                }
            }
            e.Handled = true;
        }

        private void updateFreq (String b)
        {
            int dup = 0;
            for (int i = 0; i < blockList.Length; i++)
            {
                if (b.Equals(blockList[i]))
                {
                    blockFreq[i]++;
                    dup = i;
                }
            }
            for (int j = 0; j < blockFreq.Length; j++)
            {
                if (j != dup)
                {
                    blockFreq[j] = 0;
                }
            }
        }

        private bool checkFreq()
        {
            bool tooFreq = false;
            foreach (int i in blockFreq)
            {
                if (i >= tooFrequent)
                {
                    tooFreq = true;
                }
            }
            return tooFreq;
        }

        private void blockChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selBlock = blockChooser.SelectedItem.ToString();
            updateFreq(selBlock);
            if (checkFreq())
            {
                // add a random block instead
                rwl.addBlock(fact.getColoredBlock(blockList[r.Next(blockList.Length)] + "Block"));
            } else
            {
                rwl.addBlock(fact.getColoredBlock(selBlock + "Block"));
            }
            // remove and replace
        }
    }
}
