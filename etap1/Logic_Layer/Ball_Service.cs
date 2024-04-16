using System;
using System.Collections.Generic;
using System.Windows.Media;
using Data_Layer;
using Logic_Layer.Interfaces;



namespace Logic_Layer
{
    public class Ball_Service : IBallService
    {
        public List<Ball> balls = new List<Ball>();
        private Random random = new Random();
        private readonly double canvasWidth;
        private readonly double canvasHeight;

        public Ball_Service(double canvasWidth, double canvasHeight)
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
        }

        public Ball CreateBall()
        {
            double x = random.NextDouble() * canvasWidth;
            double y = random.NextDouble() * canvasHeight;
            double velocityX = random.NextDouble() * 2 - 1;
            double velocityY = random.NextDouble() * 2 - 1;
            double radius = 10;
            Color color = GetRandomColor();

            // Upewnienie si�, �e wsp�rz�dne x i y znajduj� si� w granicach kanwy
            x = Math.Max(radius, Math.Min(x, canvasWidth - radius));
            y = Math.Max(radius, Math.Min(y, canvasHeight - radius));

            Ball ball = new Ball(x, y, velocityX, velocityY, radius, color);
            balls.Add(ball);
            return ball;
        }

        public void UpdateBallPositions(double timeFactor)
        {
            foreach (var ball in balls)
            {
                ball.X += ball.VelocityX * timeFactor;
                ball.Y += ball.VelocityY * timeFactor;
                CheckCollisionWithBounds(ball);
            }
        }

        public void ClearBalls()
        {
            balls.Clear();
        }

        public IEnumerable<Ball> GetAllBalls()
        {
            return balls;
        }

        private void CheckCollisionWithBounds(Ball ball)
        {
            if (ball.X - ball.Radius < 0 || ball.X + ball.Radius > canvasWidth)
            {
                ball.VelocityX = -ball.VelocityX;
            }
            if (ball.Y - ball.Radius < 0 || ball.Y + ball.Radius > canvasHeight)
            {
                ball.VelocityY = -ball.VelocityY;
            }
        }

        private Color GetRandomColor()
        {
            var colors = new Color[] {
                Colors.Pink,
                Colors.Red,
                Colors.DarkOliveGreen,
                Colors.LimeGreen,
                Colors.Blue,
                Colors.LightBlue,
                Colors.Yellow,
                Colors.Orange,
                Colors.Purple,
                Colors.PeachPuff,
                Colors.Magenta,
                Colors.Black,
                Colors.Brown,
                Colors.SteelBlue
            };

            return colors[random.Next(colors.Length)];
        }
    }
}
