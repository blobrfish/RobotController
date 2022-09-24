using RobotController.Core.Abstractions;
using RobotController.Core.Interfaces;

namespace RobotController.Core.RobotCommands
{
    public class WalkForwardCommand : RobotCommand
    {
        public WalkForwardCommand(IRobot robot) : base( robot, 'F', "Walk forward")
        { }
        public override void Execute()
        {
            if (App.Room.IsPositionWithinRoom(this.Robot.NextPosition))
            {
                this.Robot.MoveForward();
            }

        }
    }
}


