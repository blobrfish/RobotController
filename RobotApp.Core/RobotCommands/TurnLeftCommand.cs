using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;

namespace RobotController.Core.RobotCommands
{
        public class TurnLeftCommand : Command
        {
            public TurnLeftCommand(IRobot robot) : base(robot,'L', "Turn left")
            { }
            public override void Execute()
            {
                this.Robot.TurnLeft();
            }
        }
  }


