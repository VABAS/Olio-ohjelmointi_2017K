using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace breakout
{
    class Game
    {
        // timer
        private DispatcherTimer timer;
        // blocks
        private List<Block> blocks;
        // paddle
        public Paddle paddle;
        // ball
        private Ball ball;
        // canvas
        private Canvas canvas;

        public Game(Canvas canvas)
        {
            // canvas in MainPage
            this.canvas = canvas;

            CreatePaddle();
            CreateBall();
            CreateBlocks();
            // Debug:
            //ball.SetLocation();
            //paddle.SetLocation();
        }

        /// <summary>
        /// Initialize audio files.
        /// </summary>
        /// <summary>
        /// Create a paddle.
        /// </summary>
        private void CreatePaddle()
        {
            paddle = new Paddle
            {
                LocationX = 350,
                LocationY = 550
            };
            canvas.Children.Add(paddle);
        }

        /// <summary>
        /// Create a ball.
        /// </summary>
        private void CreateBall()
        {
            ball = new Ball
            {
                LocationX = 390,
                LocationY = 500
            };
            canvas.Children.Add(ball);
        }

        /// <summary>
        /// Create blocks. 12 Cols 10 Rows.
        /// </summary>
        private void CreateBlocks()
        {
            blocks = new List<Block>();

            int blocksCount = 120;
            int cols = 12;
            int xStartPos = 70;
            int yStartPos = 30;
            int step = 5;
            int row = 0;
            int col = 0;
            for (int i = 0; i < blocksCount; i++)
            {
                // is it a new row
                if (i % cols == 0 && i > 0)
                {
                    row++;
                    col = 0;
                }
                else if (i > 0)
                {
                    col++;
                }
                // block position
                int x = (50 + step) * col + xStartPos;
                int y = (20 + step) * row + yStartPos;
                // create a new block
                Block block = new Block
                {
                    LocationX = x,
                    LocationY = y
                };
                // add block to blocks
                blocks.Add(block);
                // add Canvas
                canvas.Children.Add(block);
                // set location
                block.SetLocation();
            }
        }

        /// <summary>
        /// Start game
        /// </summary>
        public void StartGame()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60); // try 60 fps
            timer.Start();
        }

        /// <summary>
        /// GameLoop. Move ball and Check collision.
        /// </summary>
        private void Timer_Tick(object sender, object e)
        {
            ball.Move();
            CheckCollision();
            IsGameOver();
        }

        /// <summary>
        /// Is game over. All blocks destroyed or ball below paddle.
        /// </summary>
        private void IsGameOver()
        {
            // all blocks destroyed
            if (blocks.Count == 0)
            {
                Debug.WriteLine("Game Over - Good Job!");
                timer.Stop();
            }
            // ball below paddle
            if (ball.LocationY > paddle.LocationY)
            {
                Debug.WriteLine("Game Over - Outsh!");
                timer.Stop();
            }
        }

        /// <summary>
        /// Check collision with ball and paddle or ball and blocks.
        /// </summary>
        private void CheckCollision()
        {
            // ball and paddle
            Rect r1 = ball.GetRect();
            r1.Intersect(paddle.GetRect());
            if (!r1.IsEmpty)
            {
                // ballPosition 0 to 100
                double ballPosition = ball.LocationX - paddle.LocationX;
                // hitPercent  -0.5 to 0.5
                double hitPercent = (ballPosition / paddle.Width) - 0.5;
                // set ball speed 
                ball.SetSpeed(hitPercent);

            }
            // ball and blocks
            foreach (Block block in blocks)
            {
                // ball and block
                Rect r3 = ball.GetRect();
                r3.Intersect(block.GetRect());
                if (!r3.IsEmpty)
                {
                    blocks.Remove(block);
                    canvas.Children.Remove(block);
                    // ball hits block left or right edge
                    double ballCenter = ball.LocationX + (ball.Width / 2);
                    if (ballCenter < block.LocationX || ballCenter > (block.LocationX + block.Width)) ball.XSpeed *= -1;
                    // ball hits block top or bottom
                    else ball.YSpeed *= -1;
                    // block removed
                    break;
                }
            }
        }
    }
}