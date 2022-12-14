using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RobotController.Core;
using RobotController.Core.Interfaces;
using RobotController.Core.Enums;
namespace RobotController
{
    public class MyRoom : IEnviroment
    {
        int Width;
        int Depth;
        int MaxX;
        int MaxY;
        readonly int MinXY = 0;

        public bool IsPositionWithinEnviroment(Position position)
        {
            int x = position.X;
            int y = position.Y;
            return (this.MinXY <= x && x <= this.MaxX) && (this.MinXY <= y && y <= this.MaxY);
        }
        public void SetDimensions(string value)
        {
            IList<string> inputSeperated = value.Split(' ');
            this.Width = Int32.Parse(inputSeperated[0]);
            this.Depth = Int32.Parse(inputSeperated[1]);
            this.MaxX = this.Width - 1;
            this.MaxY = this.Depth - 1;
        }
    }

}



