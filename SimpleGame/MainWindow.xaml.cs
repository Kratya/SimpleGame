using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

//Title="MainWindow" Height="450" Width="800" KeyDown="Window_KeyDown" Loaded="Window_Loaded" KeyUp="Window_KeyUp">
namespace SimpleGame
{
    public partial class MainWindow : Window
    {
        //int sBird = 0;
        Player bird =  new Player(200, 200, 1);

        TheWall wall1 = new TheWall(500, -100, "./../../img/dtube.png");
        TheWall wall2 = new TheWall(500, 300, "./../../img/ttube.png");

        TheWall t_wall1 = new TheWall(500, -100, "./../../img/dtube.png");
        TheWall t_wall2 = new TheWall(500, 300, "./../../img/ttube.png");

        float gravity;
        private DispatcherTimer aTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameComponent();
        }

        public void InitGame()
        {
            /*
            bird = new Player(200, 200, sBird);
            wall1 = new TheWall(500, -100, "./../../img/dtube.png");
            wall2 = new TheWall(500, 300, "./../../img/ttube.png");
            */
            bird.isAlive = true;
            bird.x = 200;
            bird.y = 200;
            bird.score = 0;

            wall1.x = 500;
            wall1.y = -100;

            wall2.x = 500;
            wall2.y = 300;

            CreateNewWall();
            /*
            PlayerSprite.Source = bird.birdImg;
            PlayerSprite.Width = bird.size;
            */

            gravity = 0;
            RedrawGame();
            this.gameScore.Text = "0";
            this.gameScore.FontSize = 20;
            this.gameScore.Foreground = new SolidColorBrush(Colors.Red);
            aTimer.Start();
        }

        private void update(object sender, EventArgs e)
        {
            if (bird.y > 600)
            {
                bird.isAlive = false;
                aTimer.Stop();
                InitGame();
            }

            if (Collide(bird, wall1) || Collide(bird, wall2))
            {
                bird.isAlive = false;
                aTimer.Stop();
                InitGame();
            }

            // if (bird.gravityValue != 0.1f)
            bird.gravityValue += 0.005f;
            gravity += bird.gravityValue;
            bird.y += gravity;

            if (bird.isAlive)
            {
                MoveWalls();
                RedrawGame();
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
            if (wall1.x < t_wall1.x - 100)
            {
                DTubeTemp.Visibility = Visibility.Visible;
                TTubeTemp.Visibility = Visibility.Visible;
            }
            if (wall1.x < bird.x - 100)
            {
                Random r = new Random();
                int y1;
                y1 = r.Next(-200, 000);
                wall1 = new TheWall(t_wall1.x, t_wall1.y, "./../../img/dtube.png");
                wall2 = new TheWall(t_wall2.x, t_wall2.y, "./../../img/ttube.png");
                t_wall1 = new TheWall(500, y1, "./../../img/dtube.png");
                t_wall2 = new TheWall(500, y1 + 400, "./../../img/ttube.png");
                //wall1 = new TheWall(500, y1, "./../../img/dtube.png");
                //wall2 = new TheWall(500, y1 + 400, "./../../img/ttube.png");
                ++bird.score;
                this.gameScore.Text = bird.score.ToString();
                this.gameScore.FontSize = 20;
                this.gameScore.Foreground = new SolidColorBrush(Colors.Red);

                DTubeTemp.Visibility = Visibility.Hidden;
                TTubeTemp.Visibility = Visibility.Hidden;
            }
        }

        private void MoveWalls()
        {
            wall1.x -= 2;
            wall2.x -= 2;
            CreateNewWall();
            RedrawGame();
        }


        private void RedrawGame()
        {
            Canvas.SetTop(PlayerSprite, bird.y);
            Canvas.SetLeft(PlayerSprite, bird.x);

            Canvas.SetTop(DTube, wall1.y);
            Canvas.SetLeft(DTube, wall1.x);

            Canvas.SetTop(TTube, wall2.y);
            Canvas.SetLeft(TTube, wall2.x);
        }

        private void InitializeGameComponent()
        {
            this.aTimer = new DispatcherTimer();
            this.aTimer.Tick += new EventHandler(update);
            this.aTimer.Interval = TimeSpan.FromMilliseconds(10);

            //InitGame();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tcGame.SelectedIndex = 1;
            aTimer.Start();
            InitGame();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            bird.birdImg = new BitmapImage(new Uri("./../../img/bird1.png", UriKind.RelativeOrAbsolute));
            PlayerSprite.Source = bird.birdImg;
            PlayerSprite.Width = bird.size;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            bird.birdImg = new BitmapImage(new Uri("./../../img/bird2.png", UriKind.RelativeOrAbsolute)); ;
            PlayerSprite.Source = bird.birdImg;
            PlayerSprite.Width = bird.size;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            bird.birdImg = new BitmapImage(new Uri("./../../img/bird3.png", UriKind.RelativeOrAbsolute)); ;
            PlayerSprite.Source = bird.birdImg;
            PlayerSprite.Width = bird.size;
        }
    }
}