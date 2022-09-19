using RobotController.Core.Interfaces;
using RobotController.Core;
using System.Collections.Generic;
using System;
using System.Linq;
namespace RobotController.Core
{
    public class App
    {
        public static IUI UI;
        public IRobot Robot;
        public static IRoom Room;
        public static RobotCommandService CommandService;
        
        App(IUI uI, IRoom room, IRobot robot)
        {
            UI = uI;
            Room = room;
            Robot = robot;

            if (Room != null)
            {
                Room.SetDimensions();
            }

            if (Robot != null)
            {
                Robot.SetStartPositionAndFacingDirection();
            }
            CommandService = new RobotCommandService(this.Robot);
            CommandService.ListenToCommands();
            CommandService.RunCommands();

            UI.ShowRobotPositionAndFacingDirection(Robot.CurrentPositionAndFacingDirection);
            
          
        }

        public static App Run(IUI uI, IRoom room, IRobot robot)
        {
            return new App(uI, room, robot);
        }
    }
}
