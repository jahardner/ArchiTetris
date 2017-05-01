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
        public BoardState bState;
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
        public bool remove = false;

        public ArchiTetris()
        {
            InitializeComponent();
            rwl = new ReadWriteLock(this);
            bState = new WaitingState(this);

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
            blockChooser.SelectedIndex = 0;

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

        public void removeBlockQueue()
        {
            this.Invoke((MethodInvoker)(() => blockQueue.Items.RemoveAt(0)));
            if (blockQueue.Items.Count < 5)
            {
                pickBttn.Enabled = true;
            }
        }

        public void addBlockQueue(string b)
        {
            blockQueue.Items.Add(b);
            if (blockQueue.Items.Count >= 5)
            {
                pickBttn.Enabled = false;
            }
        }

        private void TimerEvent(object source, ElapsedEventArgs e)
        {
            // impliment timer
            string timer = timerBox.Text;
            int single = (int)timer[timer.Length - 1]-48;
            int tens = (int)timer[timer.Length - 2]-48;
            int min = Convert.ToInt32(timer.Substring(0, timer.Length-3));
            single++;
            if (single == 10)
            {
                single = 0;
                tens++;
                if (tens == 6)
                {
                    tens = 0;
                    min++;
                }
            }
            timerBox.Text = min + ":" + tens + single;
        }

        private void MoveEvent(object source, ElapsedEventArgs e)
        {
            WaitingState wState = bState as WaitingState;
            if (wState != null && blockQueue.Items.Count > 0)
            {
                bState.nextState(this);
            }

            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null)
            {
                // move block down
                currentBlock.setBlocksPos(currentBlock.getX(), currentBlock.getY() + 1);
                lastMove = "down";
                CheckState cState = new CheckState(this, bState);
                bState = (BoardState)cState;
            }
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FallingState fs = bState as FallingState;
            if (fs != null)
            {
                if (e.KeyChar == (char)Keys.Up)
                {
                    // rotate through rotate magic
                }
                else if (e.KeyChar == (char)Keys.Left)
                {
                    currentBlock.setBlocksPos(currentBlock.getX() - 1, currentBlock.getY());
                    lastMove = "left";
                    CheckState cState = new CheckState(this, bState);
                    bState = (BoardState)cState;
                }
                else if (e.KeyChar == (char)Keys.Right)
                {
                    currentBlock.setBlocksPos(currentBlock.getX() + 1, currentBlock.getY());
                    lastMove = "right";
                    CheckState cState = new CheckState(this, bState);
                    bState = (BoardState)cState;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String selBlock = blockChooser.SelectedItem.ToString();
            blockChooser.Items.RemoveAt(blockChooser.SelectedIndex);
            updateFreq(selBlock);
            if (checkFreq())
            {
                // add a random block instead
                selBlock = blockList[r.Next(blockList.Length)];
            }
            rwl.addBlock(fact.getColoredBlock(selBlock + "Block"), selBlock);
            blockChooser.Items.Add(blockList[r.Next(blockList.Length)]);
        }
    }
}
