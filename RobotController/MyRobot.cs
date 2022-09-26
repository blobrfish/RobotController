using RobotController.Core.Enums;
using RobotController.Core;
using System;
using System.Collections.Generic;
using RobotController.Core.Interfaces;

namespace RobotController
{
    public class MyRobot : IMovingObject
    {
        Position Position;
        MovingObjectFacingDirection FacingDirection;
        public string CurrentPositionAndFacingDirection => string.Format("{0} {1}", this.Position.ToString(), (char)this.FacingDirection);

        readonly int StepsForward = 1;
        public Position NextPosition
        {
            get
            {
                switch (this.FacingDirection)
                {
                    case MovingObjectFacingDirection.North:
                        return this.Position.DecreaseY(StepsForward);
                    case MovingObjectFacingDirection.South:
                        return this.Position.IncreaseY(StepsForward);
                    case MovingObjectFacingDirection.West:
                        return this.Position.DecreaseX(StepsForward);
                    default:
                        return this.Position.IncreaseX(StepsForward);
                }
            }
        }

        public void MoveForward() => this.Position = this.NextPosition;


        public void TurnLeft()
        {
            switch (this.FacingDirection)
            {
                case MovingObjectFacingDirection.North:
                    this.FacingDirection = MovingObjectFacingDirection.West;
                    break;
                case MovingObjectFacingDirection.South:
                    this.FacingDirection = MovingObjectFacingDirection.East;
                    break;
                case MovingObjectFacingDirection.West:
                    this.FacingDirection = MovingObjectFacingDirection.South;
                    break;
                default:
                    this.FacingDirection = MovingObjectFacingDirection.North;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (this.FacingDirection)
            {
                case MovingObjectFacingDirection.North:
                    this.FacingDirection = MovingObjectFacingDirection.East;
                    break;
                case MovingObjectFacingDirection.South:
                    this.FacingDirection = MovingObjectFacingDirection.West;
                    break;
                case MovingObjectFacingDirection.West:
                    this.FacingDirection = MovingObjectFacingDirection.North;
                    break;
                default:
                    this.FacingDirection = MovingObjectFacingDirection.South;
                    break;
            }
        }

        public void SetStartPositionAndFacingDirection(string value)
        {
            IList<string> inputSeperated = value.Split(' ');
            int x = Int32.Parse(inputSeperated[0]);
            int y = Int32.Parse(inputSeperated[1]);
            this.Position = new Position(x, y);
            this.FacingDirection = (MovingObjectFacingDirection)Char.Parse(inputSeperated[2]);
        }
        public string GetStartPositionAndFacingDirection()
        {
            Console.WriteLine("Please enter the  the start position for the robot followed by the direction in format: StartX StartY FacingDirection{N,E,S,W}");
            string input = Console.ReadLine();
            return input;
        }

        public string GetEnviromentDimensions()
        {
            Console.WriteLine("Please enter the width and depth of the room seperated by space in format: width depth");
            string input = Console.ReadLine();
            return input;
        }
    }
}
