using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace FirstGame
{
    public partial class Form1 : Form
    {
        PictureBox[] cloud;
        int backgroundSpeed;
        Random rand;
        int playerSpeed;

        PictureBox[] bullets;
        int bulletSpeed;

        PictureBox[] enemies;
        readonly int sizeEnemy;
        int enemiesSpeed;

        WindowsMediaPlayer Shoot;
        WindowsMediaPlayer GameSong;
        WindowsMediaPlayer DeathSound;

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
                    cloud[i].Left = -cloud[i].Width;
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
            playerSpeed = 3;

            bullets = new PictureBox[1];
            bulletSpeed = 80;


            enemies = new PictureBox[4];
            int sizeEnemy = rand.Next(60, 80);
            enemiesSpeed = 3;

            Image easyEnemies = Image.FromFile("assets\\virus.gif");
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox
                {
                    Size = new Size(sizeEnemy, sizeEnemy),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    Image = easyEnemies,
                    Location = new Point((i + 1) * rand.Next(90, 160) + 1080, rand.Next(450, 600))
                };

                this.Controls.Add(enemies[i]);
            }


            Shoot = new WindowsMediaPlayer
            {
                URL = "songs\\shoot.wav"
            };
            Shoot.settings.volume = 5;



            DeathSound = new WindowsMediaPlayer
            {
                URL = "songs\\DeathSound.wav"
            };
            DeathSound.settings.volume = 10;



            GameSong = new WindowsMediaPlayer
            {
                URL = "songs\\bgmusic.mp3"
            };
            GameSong.settings.setMode("loop", true);
            GameSong.settings.volume = 15;

            GameSong.controls.play();

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox
                {
                    BorderStyle = BorderStyle.None,
                    Size = new Size(20, 5),
                    BackColor = Color.White
                };

                this.Controls.Add(bullets[i]);
            }
            

            for(int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox
                {
                    BorderStyle = BorderStyle.None,
                    Location = new Point(rand.Next(-1000, 1280), rand.Next(100, 380))
                };
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
            if(e.KeyCode == Keys.Space)
            {
                ShootingTimer.Start();
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
            if (e.KeyCode == Keys.Space)
            {
                ShootingTimer.Stop();
            }

        }

        private void MoveBulletsTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Left += bulletSpeed;
            }
        }

        private void shootingTimer_Tick(object sender, EventArgs e)
        {
            Shoot.controls.play();
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Left > 1280)
                {
                    bullets[i].Location = new Point(mainPlayer.Location.X + 100 + i * 50, mainPlayer.Location.Y + 50); ;
                }
            }

            Intersect();
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }
        private void MoveEnemies(PictureBox[] enemies, int speed)
        {
            for(int i=0; i<enemies.Length; i++)
            {
                enemies[i].Left -= speed + (int)(Math.Sin(enemies[i].Left * Math.PI / 180) + Math.Cos(enemies[i].Left * Math.PI / 180));

                Intersect();

                if(enemies[i].Left < this.Left)
                {
                    int sizeEnemy = rand.Next(60, 90);
                    enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                    enemies[i].Location = new Point((i + 1) * rand.Next(150, 250) + 1080, rand.Next(450, 650));
                }
            }
        }
        private void Intersect()
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                if (bullets[0].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    enemies[i].Location = new Point(rand.Next(150, 250) + 1280, rand.Next(450, 600));
                    bullets[0].Location = new Point(2000, mainPlayer.Location.Y + 50);
                    DeathSound.controls.play();
                }
                if (mainPlayer.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    mainPlayer.Visible = false;
                }
            }
        }
    }
}
