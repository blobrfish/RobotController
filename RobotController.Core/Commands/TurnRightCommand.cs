using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;
namespace RobotController.Core.Commands
{
        public class TurnRightCommand : Command
        {
            public TurnRightCommand(IEnviroment enviroment, IMovable movable) : base(enviroment, movable,'R', "Turn right")
            { }
            public override void Execute()
            {
                this.Movable.TurnRight();
            }
        }
  }


