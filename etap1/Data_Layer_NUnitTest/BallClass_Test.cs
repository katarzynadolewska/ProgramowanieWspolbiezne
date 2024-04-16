using Data_Layer;
using System.Windows.Media;

namespace Data_Layer_NUnitTest
{
    public class Ball_Constructor_Tests
    {
        
            static double x = 50;
            static double y = 140;
            static double velocityX = 1;
            static double velocityY = 1;
            static double radius = 15;
            static Color color = Colors.Red;

            Ball ball = new Ball(x, y, velocityX, velocityY, radius, color);
        

        [Test]
        public void Check_Values()
        {
            Assert.That(ball.X, Is.EqualTo(x));
            Assert.That(ball.Y, Is.EqualTo(y));
            Assert.That(ball.VelocityX, Is.EqualTo(velocityX));
            Assert.That(ball.VelocityY, Is.EqualTo(velocityY));
            Assert.That(ball.Radius, Is.EqualTo(radius));
            Assert.That(ball.Color, Is.EqualTo(color));

        }
    }
}