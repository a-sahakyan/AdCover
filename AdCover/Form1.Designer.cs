namespace AdCover
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
            this.components = new System.ComponentModel.Container();
            this.clock = new System.Windows.Forms.Label();
            this.hourMinSecTime = new System.Windows.Forms.Timer(this.components);
            this.hourMinTime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hourBox = new System.Windows.Forms.TextBox();
            this.minuteBox = new System.Windows.Forms.TextBox();
            this.secondBox = new System.Windows.Forms.TextBox();
            this.hourLabel = new System.Windows.Forms.Label();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Location = new System.Drawing.Point(12, 9);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(40, 17);
            this.clock.TabIndex = 0;
            this.clock.Text = "clock";
            // 
            // hourMinSecTime
            // 
            this.hourMinSecTime.Interval = 1000;
            this.hourMinSecTime.Tick += new System.EventHandler(this.AddClockSec);
            // 
            // hourMinTime
            // 
            this.hourMinTime.Interval = 1000;
            this.hourMinTime.Tick += new System.EventHandler(this.AddClock);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // hourBox
            // 
            this.hourBox.Location = new System.Drawing.Point(131, 113);
            this.hourBox.Name = "hourBox";
            this.hourBox.Size = new System.Drawing.Size(38, 22);
            this.hourBox.TabIndex = 1;
            // 
            // minuteBox
            // 
            this.minuteBox.Location = new System.Drawing.Point(193, 113);
            this.minuteBox.Name = "minuteBox";
            this.minuteBox.Size = new System.Drawing.Size(38, 22);
            this.minuteBox.TabIndex = 2;
            // 
            // secondBox
            // 
            this.secondBox.Location = new System.Drawing.Point(262, 113);
            this.secondBox.Name = "secondBox";
            this.secondBox.Size = new System.Drawing.Size(38, 22);
            this.secondBox.TabIndex = 3;
            // 
            // hourLabel
            // 
            this.hourLabel.AutoSize = true;
            this.hourLabel.Location = new System.Drawing.Point(141, 82);
            this.hourLabel.Name = "hourLabel";
            this.hourLabel.Size = new System.Drawing.Size(16, 17);
            this.hourLabel.TabIndex = 4;
            this.hourLabel.Text = "0";
            // 
            // minuteLabel
            // 
            this.minuteLabel.AutoSize = true;
            this.minuteLabel.Location = new System.Drawing.Point(205, 82);
            this.minuteLabel.Name = "minuteLabel";
            this.minuteLabel.Size = new System.Drawing.Size(16, 17);
            this.minuteLabel.TabIndex = 5;
            this.minuteLabel.Text = "0";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(271, 82);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(16, 17);
            this.secondLabel.TabIndex = 6;
            this.secondLabel.Text = "0";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(131, 213);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(191, 22);
            this.fileNameBox.TabIndex = 7;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(349, 213);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(37, 23);
            this.openFileButton.TabIndex = 8;
            this.openFileButton.Text = ".....";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(44, 218);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(75, 17);
            this.fileLabel.TabIndex = 9;
            this.fileLabel.Text = "File Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.minuteLabel);
            this.Controls.Add(this.hourLabel);
            this.Controls.Add(this.secondBox);
            this.Controls.Add(this.minuteBox);
            this.Controls.Add(this.hourBox);
            this.Controls.Add(this.clock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.Timer hourMinSecTime;
        private System.Windows.Forms.Timer hourMinTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox hourBox;
        private System.Windows.Forms.TextBox minuteBox;
        private System.Windows.Forms.TextBox secondBox;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label fileLabel;
    }
}

