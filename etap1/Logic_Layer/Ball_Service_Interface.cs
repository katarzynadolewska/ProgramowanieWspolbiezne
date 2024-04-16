using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using Data_Layer;


namespace Logic_Layer.Interfaces
{
    public interface IBallService
    {
        Ball CreateBall();

        void UpdateBallPositions(double timeFactor);

        void ClearBalls();

        IEnumerable<Ball> GetAllBalls();
    }
}

 