using System.Collections.Generic;

namespace RobotController.Core
{
    public struct Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position IncreaseX(int steps) => new Position(this.X+ steps, this.Y);

        public Position IncreaseY(int steps) => new Position(this.X, this.Y+ steps);
    
        public Position DecreaseX(int steps) => new Position(this.X- steps, this.Y);
    
        public Position DecreaseY(int steps) => new Position(this.X, this.Y- steps);
  
        public override string ToString()
        {
            return string.Format("{0} {1}", this.X, this.Y);
        }
    }
}

