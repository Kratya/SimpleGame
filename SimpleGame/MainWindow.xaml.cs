using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Input;
//using System.Windows.Forms;


namespace SimpleGame
{
    public partial class MainWindow : Window
    {
        Player bird;
        TheWall wall1;
        TheWall wall2;
        float gravity;
        private DispatcherTimer aTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameComponent();
        }

        public void Init()
        {
            bird = new Player(200, 200);
            wall1 = new TheWall(500, -100, true);
            wall2 = new TheWall(500, 300);

            gravity = 0;
            //this.Text = "Flappy Bird Score: 0";
            aTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            if (bird.y > 600)
            {
                bird.isAlive = false;
                aTimer.Stop();
                Init();
            }

            if (Collide(bird, wall1) || Collide(bird, wall2))
            {
                bird.isAlive = false;
                aTimer.Stop();
                Init();
            }

            if (bird.gravityValue != 0.1f)
                bird.gravityValue += 0.005f;
            gravity += bird.gravityValue;
            bird.y += gravity;

            if (bird.isAlive)
            {
                MoveWalls();
            }
        }

        private bool Collide(Player bird, TheWall wall1)
        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + wall1.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + wall1.sizeY / 2)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreateNewWall()
        {
            if (wall1.x < bird.x - 100)
            {
                Random r = new Random();
                int y1;
                y1 = r.Next(-200, 000);
                wall1 = new TheWall(500, y1, true);
                wall2 = new TheWall(500, y1 + 400);
                //this.Text = "Flappy Bird Score: " + ++bird.score;
            }
        }

        private void MoveWalls()
        {
            wall1.x -= 2;
            wall2.x -= 2;
            CreateNewWall();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);


            graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y, wall1.sizeX, wall1.sizeY);

            graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {

        }

        private void InitializeGameComponent()
        {
            this.aTimer = new DispatcherTimer();
            this.aTimer.Tick += aTimer_Tick;
            this.aTimer.Interval = TimeSpan.FromMilliseconds(10);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    if (bird.isAlive)
                    {
                        gravity = 0;
                        bird.gravityValue = -0.125f;
                    }
                    break;
                default:
                    break;
            }
        }

        private void GameStart()
        {
            tcGame.SelectedIndex = 1;
            aTimer.Start();
        }
    }
}