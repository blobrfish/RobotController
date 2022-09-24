using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;
namespace RobotController.Core.RobotCommands
{
        public class TurnRightCommand : RobotCommand
        {
            public TurnRightCommand( IRobot robot) : base(robot,'R', "Turn right")
            { }
            public override void Execute()
            {
                this.Robot.TurnRight();
            }
        }
  }


