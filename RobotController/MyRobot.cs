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

        readonly int StepsForward = 1;
        public Position NextPosition
        {
            get
            {

                switch (this.FacingDirection)
                {
                    case RobotFacingDirection.North:
                        return this.Position.DecreaseY(StepsForward);
                    case RobotFacingDirection.South:
                        return this.Position.IncreaseY(StepsForward);
                    case RobotFacingDirection.West:
                        return this.Position.DecreaseX(StepsForward);
                    default:
                        return this.Position.IncreaseX(StepsForward);
                }
            }
        }

        public void MoveForward()
        {
            Console.WriteLine("My robot moved forward!"); 
            this.Position = this.NextPosition;
        }


        public void TurnLeft()
        {
            Console.WriteLine("My robot turned left!");
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
            Console.WriteLine("My robot turned right!");
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

        public void SetStartPositionAndFacingDirection(string value)
        {
            IList<string> inputSeperated = value.Split(' ');
            int x = Int32.Parse(inputSeperated[0]);
            int y = Int32.Parse(inputSeperated[1]);
            this.Position = new Position(x, y);
            this.FacingDirection = (RobotFacingDirection)Char.Parse(inputSeperated[2]);
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
