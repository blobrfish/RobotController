using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;

namespace RobotController.Core.Commands
{
        public class TurnLeftCommand : Command
        {
            public TurnLeftCommand(IEnviroment enviroment, IMovable movable) : base(enviroment, movable, 'L', "Turn left")
            { }
            public override void Execute()
            {
                this.Movable.TurnLeft();
            }
        }
  }


