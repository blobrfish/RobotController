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

        public Position IncreaseX => new Position(this.X+1, this.Y);

        public Position IncreaseY  => new Position(this.X, this.Y+1);
    
        public Position DecreaseX => new Position(this.X-1, this.Y);
    
        public Position DecreaseY => new Position(this.X, this.Y-1);
  
        public override string ToString()
        {
            return string.Format("{0} {1}", this.X, this.Y);
        }
    }
}

