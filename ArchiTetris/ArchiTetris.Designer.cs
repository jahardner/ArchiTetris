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
            this.timerBox = new System.Windows.Forms.TextBox();
            this.board = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.blockQueue = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.timerBox);
            this.groupBox2.Controls.Add(this.board);
            this.groupBox2.Location = new System.Drawing.Point(185, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player 2";
            // 
            // timerBox
            // 
            this.timerBox.BackColor = System.Drawing.Color.Black;
            this.timerBox.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.timerBox.Location = new System.Drawing.Point(104, 10);
            this.timerBox.Name = "timerBox";
            this.timerBox.ReadOnly = true;
            this.timerBox.Size = new System.Drawing.Size(100, 24);
            this.timerBox.TabIndex = 2;
            this.timerBox.Text = "00:00";
            this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timerBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.Location = new System.Drawing.Point(8, 40);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(200, 400);
            this.board.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.blockQueue);
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player 1";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("OCR A Extended", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Teal;
            this.statusLabel.Location = new System.Drawing.Point(6, 216);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(163, 23);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Paused";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(98, 96);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 10;
            this.button5.Text = "Pick!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(33, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 9;
            this.button4.Text = "Pick!";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 8;
            this.button3.Text = "Pick!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Pick!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Square";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button1_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Block Queue: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose next block: ";
            // 
            // blockQueue
            // 
            this.blockQueue.FormattingEnabled = true;
            this.blockQueue.Location = new System.Drawing.Point(6, 302);
            this.blockQueue.Name = "blockQueue";
            this.blockQueue.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.blockQueue.Size = new System.Drawing.Size(154, 108);
            this.blockQueue.TabIndex = 2;
            this.blockQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArchiTetris_KeyDown);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(48, 421);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Instructions";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ArchiTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ArchiTetris";
            this.Text = "ArchiTetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArchiTetris_KeyDown);
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
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox blockQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox timerBox;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button button6;
    }
}

