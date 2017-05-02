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
        public BoardState bState;
        public PictureBox[,] boardTiles = new PictureBox[10, 20];
        public int[,] boardArray = new int[10, 20];
        public BlockIF currentBlock;
        public List<BlockIF> nextBlocks = new List<BlockIF>();
        public String lastMove = "";
        public ReadWriteLock rwl;
        public bool gameOver = false;
        public bool remove = false;
        public bool movingFromWait = false;

        private Random r = new Random();
        private BlockFactory fact = new BlockFactory();
        private String[] blockList = new String[] { "Square", "Bar", "T", "L", "N" };
        private Color[] colors = new Color[] {Color.Black, Color.Crimson, Color.DeepSkyBlue, Color.HotPink, Color.SpringGreen,
        Color.MediumPurple, Color.Goldenrod, Color.Chocolate};    
        private int tooFrequent = 3;
        private List<Button> blockChooser = new List<Button>();
        private System.Timers.Timer tTimer;
        private System.Timers.Timer moveTimer;
        private System.Timers.Timer constantTimer;
        private System.Timers.Timer aiTimer;

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

            blockChooser.Add(button1);
            blockChooser.Add(button2);
            blockChooser.Add(button3);
            blockChooser.Add(button4);
            blockChooser.Add(button5);

            for (int i = 0; i < 5; i++)
            {
                blockChooser[i].Text = blockList[r.Next(blockList.Length)];
            }
            
            tTimer = new System.Timers.Timer();
            tTimer.Elapsed += new ElapsedEventHandler(TimerEvent);
            tTimer.Interval = 1000;
            tTimer.Enabled = false;

            constantTimer = new System.Timers.Timer();
            constantTimer.Elapsed += new ElapsedEventHandler(ConstantEvent);
            constantTimer.Interval = 1000;
            constantTimer.Enabled = true;

            moveTimer = new System.Timers.Timer();
            moveTimer.Elapsed += new ElapsedEventHandler(MoveEvent);
            moveTimer.Interval = 2000;
            moveTimer.Enabled = false;

            aiTimer = new System.Timers.Timer();
            aiTimer.Elapsed += new ElapsedEventHandler(AIEvent);
            aiTimer.Interval = 2000;
            aiTimer.Enabled = true;
        }

        public void pause()
        {
            if (gameOver)
            {
                statusLabel.Text = "Game Over!";
            }
            else
            {
                statusLabel.Text = "Paused";
            }
            tTimer.Enabled = false;
            moveTimer.Enabled = false;
        }

        public void play()
        {
            statusLabel.Text = "";
            tTimer.Enabled = true;
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
                for (int i = 0; i < 5; i++)
                {
                    blockChooser[i].Enabled = true;
                }
            }
        }

        public void addBlockQueue(string b)
        {
            blockQueue.Items.Add(b);
            if (blockQueue.Items.Count >= 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    blockChooser[i].Enabled = false;
                }
            }
        }

        public void replaceBlockQueue(int i, string b)
        {
            blockQueue.Items[i] = b;
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
            bool justMoved = checkWaiting();
            if (!justMoved)
            {
                moveDown();
            }
        }

        private void AIEvent(object source, ElapsedEventArgs e)
        {
            int f = checkFreq();
            if (f != -1)
            {
                string selBlock = blockList[r.Next(blockList.Length)];
                rwl.replaceBlock(fact.getColoredBlock(selBlock + "Block"), f, selBlock);
            }
            
        }

        private int checkFreq()
        {
            int index = -1;
            int[] blockFreq = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < blockQueue.Items.Count; i++)
            {
                for (int j = 0; j < blockList.Length; j++)
                {
                    if (blockList[j].Equals(blockQueue.GetItemText(blockQueue.Items[i])))
                    {
                        blockFreq[j]++;
                        if (blockFreq[j] >= tooFrequent)
                        {
                            index = i;
                        }
                    }
                }
            }
            return index;
        }

        private void ConstantEvent(object source, ElapsedEventArgs e)
        {
            if (!gameOver && blockQueue.Items.Count > 0)
            {
                play();
            }
        }

        private bool checkWaiting()
        {
            bool justMoved = false;
            WaitingState wState = bState as WaitingState;
            
            if (wState != null && !movingFromWait)
            {
                if(blockQueue.Items.Count == 0)
                {
                    pause();
                }
                else
                {
                    justMoved = true;
                    movingFromWait = true;
                    bState.nextState(this);
                }
            }

            return justMoved;
        }

        private void moveDown()
        {
            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null && lastMove.Equals(""))
            {
                // move block down
                currentBlock.setBlocksPos(currentBlock.getX(), currentBlock.getY() + 1);
                lastMove = "down";
                CheckState cState = new CheckState(this);
            }
        }

        private void moveLeft()
        {
            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null && lastMove.Equals(""))
            {
                // move block left
                currentBlock.setBlocksPos(currentBlock.getX() - 1, currentBlock.getY());
                lastMove = "left";
                CheckState cState = new CheckState(this);
            }
        }

        private void moveRight()
        {
            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null && lastMove.Equals(""))
            {
                // move block right
                currentBlock.setBlocksPos(currentBlock.getX() + 1, currentBlock.getY());
                lastMove = "right";
                CheckState cState = new CheckState(this);
            }
        }

        private void rotateBlock()
        {
            FallingState fs = bState as FallingState;
            if (currentBlock != null && fs != null && lastMove.Equals(""))
            {
                // rotates block clockwise
                currentBlock.rotate(true);
                lastMove = "rotate";
                CheckState cState = new CheckState(this);
            }
        }

        private void chooseBlock(String selBlock)
        {
            rwl.addBlock(fact.getColoredBlock(selBlock + "Block"), selBlock);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chooseBlock(button2.Text);
            button2.Text = blockList[r.Next(blockList.Length)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chooseBlock(button3.Text);
            button3.Text = blockList[r.Next(blockList.Length)];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chooseBlock(button4.Text);
            button4.Text = blockList[r.Next(blockList.Length)];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chooseBlock(button5.Text);
            button5.Text = blockList[r.Next(blockList.Length)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseBlock(button1.Text);
            button1.Text = blockList[r.Next(blockList.Length)];
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                moveDown();
            }
            else if (e.KeyCode == Keys.Up)
            {
                rotateBlock();
            }
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                moveRight();
            }
        }

        private void ArchiTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                moveDown();
            }
            else if (e.KeyCode == Keys.Up)
            {
                rotateBlock();
            }
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                moveRight();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Instructions ins = new Instructions();
            ins.Show();
        }
    }
}
