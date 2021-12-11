using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SimpleGame
{
    class Player
    {
        public float x;
        public float y;

        public int size;
        public int score;

        public float gravityValue;

        public ImageSource birdImg;



        public bool isAlive;

        public Player(int x, int y, int sBird)
        {
            switch (sBird)
            {
                case  0:
                    //birdImg = new Bitmap("./../../img/bird1.png");
                    birdImg = new BitmapImage(new Uri("./../../img/bird1.png", UriKind.RelativeOrAbsolute));
                    break;
                case 1:
                    //birdImg = new Bitmap("./../../img/bird2.png");
                    birdImg = new BitmapImage(new Uri("./../../img/bird2.png", UriKind.RelativeOrAbsolute));
                    break;
                case 2:
                    birdImg = new BitmapImage(new Uri("./../../img/bird3.png", UriKind.RelativeOrAbsolute));
                    //birdImg = new Bitmap("./../../img/bird3.png");
                    break;
                default:
                    break;
            }

            this.x = x;
            this.y = y;
            size = 40;
            gravityValue = 0.1f;
            isAlive = true;
            score = 0;
        }
    }
}
