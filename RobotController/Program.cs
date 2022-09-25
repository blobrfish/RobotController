using System;
using RobotController.Core;

namespace RobotController
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Run(new MyUI(), new MyRoom(), new MyRobot());
        }
    }
}
