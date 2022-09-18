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
        public string GetRoomWidthAndDepth()
        {
            Console.WriteLine("Please enter the width and depth of the room seperated by space in format: width depth");
            string input = Console.ReadLine();
            return input;
        }

        public string GetRobotCommands(IEnumerable<Command> availableCommands)
        {
            Console.WriteLine("Please enter the commands for the robot. F=Walk forward, L=Turn left, R=Turn right");
            for (int index = 0; index < availableCommands.Count(); index++)
            {
                Console.WriteLine("{0}", availableCommands.ElementAt(index).CodeAndName);
            }
          
            string input = Console.ReadLine();
            return input;
        }

      
        public void ShowRobotPositionAndFacingDirection(string postion)
        {
            Console.WriteLine(postion);
        }

    
        public string GetRobotStartPositionAndFacingDirection()
        {
            Console.WriteLine("Please enter the  the start position for the robot followed by the direction in format: StartX StartY FacingDirection{N,E,S,W}");
            string input = Console.ReadLine();
            return input;
        }

       
    }
}
