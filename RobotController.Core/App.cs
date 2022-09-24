using RobotController.Core.Interfaces;
using RobotController.Core;
using System.Collections.Generic;
using System;
using System.Linq;
namespace RobotController.Core
{
    public class App
    {
        public static IUI UI { get; private set; }
        IRobot Robot;
        public static IRoom Room { get; private set; }
        public static RobotCommandService CommandService { get; private set; }
        bool HasAnyErrors => this.Robot == null || App.Room == null || App.UI == null ?  true : false;
        string ErrorMessage => string.Format("No {0} was found", this.Robot == null ? "robot" : App.Room == null ? "room" : "UI");
        App(IUI uI, IRoom room, IRobot robot)
        {
            UI = uI;
            Room = room;
            Robot = robot;
            CommandService = new RobotCommandService(this.Robot);

            if (this.HasAnyErrors)
            {
                App.UI.ShowErrorMessage(this.ErrorMessage);
            }
            else
            {
                Room.SetDimensions();
                Robot.SetStartPositionAndFacingDirection();
                CommandService.Run();
                UI.ShowRobotPositionAndFacingDirection(Robot.CurrentPositionAndFacingDirection);
            }
        }

        public static App Run(IUI uI, IRoom room, IRobot robot)
        {
            return new App(uI, room, robot);
        }
    }
}
