using System;
using System.Collections.Generic;
using System.Linq;
using RobotController.Core.Interfaces;
using RobotController.Core.Abstractions;
using System.ComponentModel;

namespace RobotController
{
    public class MyUI : IUI
    {
        public string GetCommands(IEnumerable<Command> availableCommands)
        {
            Console.WriteLine("Please enter the commands for the robot. F=Walk forward, L=Turn left, R=Turn right");
            for (int index = 0; index < availableCommands.Count(); index++)
            {
                Console.WriteLine("{0}", availableCommands.ElementAt(index).CodeAndName);
            }

            string input = Console.ReadLine();
            return input;
        }


        public void ShowMovingObjectPositionAndFacingDirection(string postion)
        {
            Console.WriteLine(postion);
        }


        public void ShowErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
