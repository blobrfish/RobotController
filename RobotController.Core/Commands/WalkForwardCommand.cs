using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;

namespace RobotController.Core.Commands
{
    public class WalkForwardCommand : Command
    {
        public WalkForwardCommand(IEnviroment enviroment, IMovable movable) : base(enviroment, movable, 'F', "Walk forward")
        { }
        public override void Execute()
        {
            if (this.Enviroment.IsPositionWithinEnviroment(this.Movable.NextPosition))
            {
                this.Movable.MoveForward();
            }
        }
    }
}


