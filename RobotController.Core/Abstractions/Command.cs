using RobotController.Core.Interfaces;

namespace RobotController.Core.Abstractions
{
    public abstract class Command
    {
        protected IRobot Robot;
        public char Code { get; }

        protected readonly string Name;
        public string CodeAndName => string.Format("{0}={1}", this.Code, this.Name);

        public Command(IRobot robot, char code, string name)
        {
            this.Robot = robot;
            this.Code = code;
            this.Name = name;
        }
        public abstract void Execute();
    }
}
