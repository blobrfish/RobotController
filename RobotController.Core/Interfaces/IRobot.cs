using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Core.Interfaces
{
    public interface IRobot : IMovable,ISensible
    {}

    public interface IMovable
    {
        void SetStartPositionAndFacingDirection(string value);
        string CurrentPositionAndFacingDirection { get; }
        Position NextPosition { get; }
        void MoveForward();
        void TurnLeft();
        void TurnRight();
    }

    public interface ISensible
    {
        string GetEnviromentDimensions();
        string GetStartPositionAndFacingDirection();

    }
}

