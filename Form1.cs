using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGame
{
    public partial class Form1 : Form
    {
        PictureBox[] cloud;
        int backgroundSpeed;
        Random rand;
        int playerSpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < cloud.Length; i++)
            {
                cloud[i].Left += backgroundSpeed;
                if (cloud[i].Left >= 1280)
                {
                    cloud[i].Left = cloud[i].Height;
                }
            }
            for(int i = cloud.Length; i < cloud.Length; i++)
            {
                cloud[i].Left += backgroundSpeed - 10;
                if(cloud[i].Left >= 1280)
                {
                    cloud[i].Left = cloud[i].Left;
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 5;
            cloud = new PictureBox[20];
            rand = new Random();
            playerSpeed = 1;

            for(int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox();
                cloud[i].BorderStyle = BorderStyle.None;
                cloud[i].Location = new Point(rand.Next(-1000, 1280), rand.Next(140, 380));
                if (i % 2 == 1)
                {
                    cloud[i].Size = new Size(rand.Next(100, 225), rand.Next(30, 70));
                    cloud[i].BackColor = Color.FromArgb(rand.Next(50, 125), 255, 205, 205);
                }
                else
                {
                    cloud[i].Size = new Size(150, 25);
                    cloud[i].BackColor = Color.FromArgb(rand.Next(50, 125), 255, 205, 205);
                }
                this.Controls.Add(cloud[i]);
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if(mainPlayer.Left > 10)
            {
                mainPlayer.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left < 1150)
            {
                mainPlayer.Left += playerSpeed;
            }

        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Top > 10)
            {
                mainPlayer.Top -= playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Top < 600)
            {
                mainPlayer.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                mainPlayer.Image = Properties.Resources.cowboy_run;
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
            }
            if(e.KeyCode == Keys.Escape)
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                mainPlayer.Image = Properties.Resources.cowboy;
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Stop();
                }
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Stop();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Stop();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Stop();
                }
            }

        }
    }
}
