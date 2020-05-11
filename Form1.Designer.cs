namespace FirstGame
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MoveBgTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPlayer = new System.Windows.Forms.PictureBox();
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveBulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.ShootingTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBgTimer
            // 
            this.MoveBgTimer.Enabled = true;
            this.MoveBgTimer.Interval = 10;
            this.MoveBgTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainPlayer
            // 
            this.mainPlayer.BackColor = System.Drawing.Color.Transparent;
            this.mainPlayer.Image = global::FirstGame.Properties.Resources.staying;
            this.mainPlayer.Location = new System.Drawing.Point(548, 484);
            this.mainPlayer.Name = "mainPlayer";
            this.mainPlayer.Size = new System.Drawing.Size(100, 100);
            this.mainPlayer.TabIndex = 0;
            this.mainPlayer.TabStop = false;
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 10;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 10;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 10;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 10;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // MoveBulletsTimer
            // 
            this.MoveBulletsTimer.Enabled = true;
            this.MoveBulletsTimer.Interval = 10;
            this.MoveBulletsTimer.Tick += new System.EventHandler(this.MoveBulletsTimer_Tick);
            // 
            // ShootingTimer
            // 
            this.ShootingTimer.Tick += new System.EventHandler(this.shootingTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Interval = 10;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FirstGame.Properties.Resources.background_01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.mainPlayer);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = "2D Redemption";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        private System.Windows.Forms.PictureBox mainPlayer;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer MoveBulletsTimer;
        private System.Windows.Forms.Timer ShootingTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
    }
}

