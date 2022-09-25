using RobotController.Core.Enums;
using RobotController.Core;
using System;
using System.Collections.Generic;
using RobotController.Core.Interfaces;

namespace RobotController
{
    public class MyRobot : IRobot
    {
        Position Position;
        RobotFacingDirection FacingDirection;
        public string CurrentPositionAndFacingDirection => string.Format("{0} {1}", this.Position.ToString(), (char)this.FacingDirection);

        readonly int NumberOfStepsForward = 1;
        public Position NextPosition
        {
            get
            {
                switch(this.FacingDirection)
                {
                    case RobotFacingDirection.North:
                        return this.Position.DecreaseY(NumberOfStepsForward);
                    case RobotFacingDirection.South:
                        return this.Position.IncreaseY(NumberOfStepsForward);
                    case RobotFacingDirection.West:
                        return this.Position.DecreaseX(NumberOfStepsForward);
                    default:
                        return this.Position.IncreaseX(NumberOfStepsForward);
                }
            }
        }

        public void MoveForward() => this.Position = this.NextPosition;
    

        public void TurnLeft()
        {
            switch (this.FacingDirection)
            {
                case RobotFacingDirection.North:
                    this.FacingDirection = RobotFacingDirection.West;
                    break;
                case RobotFacingDirection.South:
                    this.FacingDirection = RobotFacingDirection.East;
                    break;
                case RobotFacingDirection.West:
                    this.FacingDirection = RobotFacingDirection.South;
                    break;
                default:
                    this.FacingDirection = RobotFacingDirection.North;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (this.FacingDirection)
            {
                case RobotFacingDirection.North:
                    this.FacingDirection = RobotFacingDirection.East;
                    break;
                case RobotFacingDirection.South:
                    this.FacingDirection = RobotFacingDirection.West;
                    break;
                case RobotFacingDirection.West:
                    this.FacingDirection = RobotFacingDirection.North;
                    break;
                default:
                    this.FacingDirection = RobotFacingDirection.South;
                    break;
            }
        }

        public void SetStartPositionAndFacingDirection()
        {
            string input = App.UI.GetRobotStartPositionAndFacingDirection();
            IList<string> inputSeperated = input.Split(' ');
            int x = Int32.Parse(inputSeperated[0]);
            int y = Int32.Parse(inputSeperated[1]);
            this.Position = new Position(x, y);
            this.FacingDirection = (RobotFacingDirection)Char.Parse(inputSeperated[2]);
        }
    }
}
