using RobotController.Core.Interfaces;
using RobotController.Core;
using System.Collections.Generic;
using System;
using System.Linq;
namespace RobotController.Core
{
    public class App
    {
        readonly IUI UI;
        readonly IRobot Robot;
        readonly IEnviroment Enviroment;
        readonly CommandService CommandService;
        IMovable Movable => this.Robot;
        ISensible Sensible => this.Robot;
        string EnviromentDimensions => this.Sensible.GetEnviromentDimensions();
        string StartPositionAndFacingDirection => this.Sensible.GetStartPositionAndFacingDirection();
        bool HasAnyErrors => this.Robot == null || Enviroment == null || this.UI == null ?  true : false;
        string ErrorMessage => string.Format("No {0} was found", this.Robot == null ? "robot" : Enviroment == null ? "valid enviroment" : "UI");

        App(IUI uI, IEnviroment enviroment, IRobot robot)
        {
            UI = uI;
            Enviroment = enviroment;
            Robot = robot;

            if (this.HasAnyErrors)
            {
                UI.ShowErrorMessage(this.ErrorMessage);
            }
            else
            {
                CommandService = new CommandService(this.UI,this.Enviroment, this.Movable);
                Enviroment.SetDimensions(this.EnviromentDimensions);
                Movable.SetStartPositionAndFacingDirection(this.StartPositionAndFacingDirection);
                CommandService.Run();
                UI.ShowRobotPositionAndFacingDirection(this.Movable.CurrentPositionAndFacingDirection);
            }
        }

        public static App Run(IUI uI, IEnviroment enviroment, IRobot robot)
        {
            return new App(uI, enviroment, robot);
        }
    }
}
