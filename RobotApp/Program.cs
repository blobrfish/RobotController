using System;
using RobotController.Core;

namespace RobotController
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.TurnOn(new MyUI(), new MyRoom(),  new MyRobot());
        }
    }
}
