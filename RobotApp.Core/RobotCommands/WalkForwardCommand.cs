using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;

namespace RobotController.Core.RobotCommands
{
        public class WalkForwardCommand : Command
        {
            public WalkForwardCommand(IRobot robot) : base(robot,'F', "Walk forward")
            { }
            public override void Execute()
            {
                this.Robot.MoveForward();
            }
        }
  }


