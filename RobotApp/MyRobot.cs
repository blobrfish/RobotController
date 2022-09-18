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

        IRoom Room => Controller.Room;
        public string CurrentPositionAndFacingDirection => string.Format("{0} {1}", this.Position.ToString(), (char)this.FacingDirection);

      
        bool CanMoveForward(Position nextPosition)
        {
            return Room.IsPositionWithinTable(nextPosition);
        }

        Position NextPosition
        {
            get
            {
                if (FacingDirection == RobotFacingDirection.North)
                {
                    return this.Position.DecreaseY;
                }
                else if (FacingDirection == RobotFacingDirection.South)
                {
                    return this.Position.IncreaseY;
                }
                else if (FacingDirection == RobotFacingDirection.West)
                {
                    return this.Position.DecreaseX;
                }

              return this.Position.IncreaseX;
           
            }
        }

        public void MoveForward()
        {
            Position nextPosition = this.NextPosition;
            if (CanMoveForward(nextPosition))
            {
                this.Position = nextPosition;
            }
        }

        public void TurnLeft()
        {
            if (FacingDirection == RobotFacingDirection.North)
            {
                this.FacingDirection = RobotFacingDirection.West;
            }
            else if (FacingDirection == RobotFacingDirection.South)
            {
                this.FacingDirection = RobotFacingDirection.East;
            }
            else if (FacingDirection == RobotFacingDirection.West)
            {
                this.FacingDirection = RobotFacingDirection.South;
            }
            else if (FacingDirection == RobotFacingDirection.East)
            {
                this.FacingDirection = RobotFacingDirection.North;
            }
        }

        public void TurnRight()
        {
            if (FacingDirection == RobotFacingDirection.North)
            {
                this.FacingDirection = RobotFacingDirection.East;
            }
            else if (FacingDirection == RobotFacingDirection.South)
            {
                this.FacingDirection = RobotFacingDirection.West;
            }
            else if (FacingDirection == RobotFacingDirection.West)
            {
                this.FacingDirection = RobotFacingDirection.North;
            }
            else if (FacingDirection == RobotFacingDirection.East)
            {
                this.FacingDirection = RobotFacingDirection.South;
            }
        }

        public void SetStartPositionAndFacingDirection()
        {
            string input = Controller.UI.GetRobotStartPositionAndFacingDirection();
            IList<string> inputSeperated = input.Split(' ');
            int x = Int32.Parse(inputSeperated[0]);
            int y = Int32.Parse(inputSeperated[1]);
            this.Position = new Position(x, y);
            this.FacingDirection = (RobotFacingDirection)Char.Parse(inputSeperated[2]);
        }
    }
}
