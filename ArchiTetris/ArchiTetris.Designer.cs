namespace ArchiTetris
{
    partial class ArchiTetris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.board = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pickBttn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.blockQueue = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.blockChooser = new System.Windows.Forms.ListBox();
            this.timerBox = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.timerBox);
            this.groupBox2.Controls.Add(this.board);
            this.groupBox2.Location = new System.Drawing.Point(185, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player 2";
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.Location = new System.Drawing.Point(8, 42);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(200, 400);
            this.board.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pickBttn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.blockQueue);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.blockChooser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 449);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player 1";
            // 
            // pickBttn
            // 
            this.pickBttn.Location = new System.Drawing.Point(46, 146);
            this.pickBttn.Name = "pickBttn";
            this.pickBttn.Size = new System.Drawing.Size(75, 23);
            this.pickBttn.TabIndex = 5;
            this.pickBttn.Text = "Pick!";
            this.pickBttn.UseVisualStyleBackColor = true;
            this.pickBttn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Block Queue: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose next block: ";
            // 
            // blockQueue
            // 
            this.blockQueue.FormattingEnabled = true;
            this.blockQueue.Location = new System.Drawing.Point(6, 228);
            this.blockQueue.Name = "blockQueue";
            this.blockQueue.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.blockQueue.Size = new System.Drawing.Size(154, 108);
            this.blockQueue.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 342);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(154, 100);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Player 1: Double click on a block in the list to choose it.\r\n\r\nPlayer 2: Use left" +
    " and right arrow keys to move falling block accordingly. Use up arrow to rotate " +
    "the block.";
            // 
            // blockChooser
            // 
            this.blockChooser.FormattingEnabled = true;
            this.blockChooser.Location = new System.Drawing.Point(6, 32);
            this.blockChooser.Name = "blockChooser";
            this.blockChooser.Size = new System.Drawing.Size(154, 108);
            this.blockChooser.TabIndex = 0;
            // 
            // timerBox
            // 
            this.timerBox.BackColor = System.Drawing.Color.Black;
            this.timerBox.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.timerBox.Location = new System.Drawing.Point(104, 10);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(100, 24);
            this.timerBox.TabIndex = 2;
            this.timerBox.Text = "00:00";
            this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ArchiTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArchiTetris";
            this.Text = "ArchiTetris";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox blockChooser;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox blockQueue;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button pickBttn;
        private System.Windows.Forms.TextBox timerBox;
    }
}

