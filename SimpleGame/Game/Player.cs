using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimpleGame
{
    class Player
    {
        public float x;
        public float y;

        public int size;
        public int score;

        public float gravityValue;

        public Image birdImg, birdImg2, birdImg3;



        public bool isAlive;

        public Player(int x, int y)
        {
            birdImg = new Bitmap("C:\\Users\\krave\\OneDrive\\Документы\\Игра\\bird1.png");
            // birdImg2 = new Bitmap("C:\\Users\\krave\\OneDrive\\Документы\\Игра\\bird2.png");
            //  birdImg3 = new Bitmap("C:\\Users\\krave\\OneDrive\\Документы\\Игра\\bird3.png");
            this.x = x;
            this.y = y;
            size = 40;
            gravityValue = 0.1f;
            isAlive = true;
            score = 0;
        }
    }
}
