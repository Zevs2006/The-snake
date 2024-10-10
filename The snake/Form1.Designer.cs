namespace The_snake
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 150;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(10, 10);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(64, 20);
            lblScore.TabIndex = 0;
            lblScore.Text = "Счет: 0";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._1684168891_new_lv_0_20230515193809__1___2_;
            pictureBox1.Location = new Point(-2, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(619, 851);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(617, 848);
            Controls.Add(lblScore);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Змейка";
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox1;
    }
}
