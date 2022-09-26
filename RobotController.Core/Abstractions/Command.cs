using RobotController.Core.Interfaces;

namespace RobotController.Core.Abstractions
{
    public abstract class Command
    {

        protected IMovable Movable;
        protected IEnviroment Enviroment;
        public char Code { get; }

        protected readonly string Name;
        public string CodeAndName => string.Format("{0}={1}", this.Code, this.Name);

        public Command(IEnviroment enviroment, IMovable movable, char code, string name)
        {
            this.Enviroment = enviroment;
            this.Movable = movable;
            this.Code = code;
            this.Name = name;
        }
        public abstract void Execute();
    }
}
