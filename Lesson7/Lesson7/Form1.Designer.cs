namespace Lesson7
{
    partial class Form1
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
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.lblGoalText = new System.Windows.Forms.Label();
            this.lblStepsText = new System.Windows.Forms.Label();
            this.lblStepsCount = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCommand2
            // 
            this.btnCommand2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCommand2.Location = new System.Drawing.Point(215, 71);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(89, 29);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReset.Location = new System.Drawing.Point(215, 106);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCommand1
            // 
            this.btnCommand1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCommand1.Location = new System.Drawing.Point(215, 36);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(89, 29);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.Location = new System.Drawing.Point(132, 75);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(25, 25);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "0";
            // 
            // lblGoal
            // 
            this.lblGoal.AutoSize = true;
            this.lblGoal.Location = new System.Drawing.Point(54, 71);
            this.lblGoal.Name = "lblGoal";
            this.lblGoal.Size = new System.Drawing.Size(13, 13);
            this.lblGoal.TabIndex = 4;
            this.lblGoal.Text = "0";
            // 
            // lblGoalText
            // 
            this.lblGoalText.AutoSize = true;
            this.lblGoalText.Location = new System.Drawing.Point(12, 71);
            this.lblGoalText.Name = "lblGoalText";
            this.lblGoalText.Size = new System.Drawing.Size(36, 13);
            this.lblGoalText.TabIndex = 5;
            this.lblGoalText.Text = "Цель:";
            // 
            // lblStepsText
            // 
            this.lblStepsText.AutoSize = true;
            this.lblStepsText.Location = new System.Drawing.Point(12, 87);
            this.lblStepsText.Name = "lblStepsText";
            this.lblStepsText.Size = new System.Drawing.Size(42, 13);
            this.lblStepsText.TabIndex = 7;
            this.lblStepsText.Text = "Шагов:";
            // 
            // lblStepsCount
            // 
            this.lblStepsCount.AutoSize = true;
            this.lblStepsCount.Location = new System.Drawing.Point(54, 87);
            this.lblStepsCount.Name = "lblStepsCount";
            this.lblStepsCount.Size = new System.Drawing.Size(13, 13);
            this.lblStepsCount.TabIndex = 6;
            this.lblStepsCount.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.menuCancel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.menuStop});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItem.Text = "Игра";
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(180, 22);
            this.menuStart.Text = "Начать игру";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // menuStop
            // 
            this.menuStop.Name = "menuStop";
            this.menuStop.Size = new System.Drawing.Size(180, 22);
            this.menuStop.Text = "Закончить игру";
            this.menuStop.Click += new System.EventHandler(this.menuStop_Click);
            // 
            // menuCancel
            // 
            this.menuCancel.Name = "menuCancel";
            this.menuCancel.Size = new System.Drawing.Size(125, 20);
            this.menuCancel.Text = "Отменить действие";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(316, 151);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblStepsText);
            this.Controls.Add(this.lblStepsCount);
            this.Controls.Add(this.lblGoalText);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Удвоитель";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.Label lblGoalText;
        private System.Windows.Forms.Label lblStepsText;
        private System.Windows.Forms.Label lblStepsCount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.ToolStripMenuItem menuCancel;
    }
}

