using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Core.Interfaces
{
    public interface IRobot
    {
        string CurrentPositionAndFacingDirection { get; }
        void MoveForward();
        void TurnLeft();
        void TurnRight();
        void SetStartPositionAndFacingDirection();


    }
}

