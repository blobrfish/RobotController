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
        readonly IMovingObject MovingObject;
        readonly IEnviroment Enviroment;
        readonly CommandService CommandService;
        IMovable Movable => this.MovingObject;
        ISensible Sensible => this.MovingObject;
        string EnviromentDimensions => this.Sensible.GetEnviromentDimensions();
        string StartPositionAndFacingDirection => this.Sensible.GetStartPositionAndFacingDirection();
        bool HasAnyErrors => this.MovingObject == null || Enviroment == null || this.UI == null ?  true : false;
        string ErrorMessage => string.Format("No {0} was found", this.MovingObject == null ? "moving object" : Enviroment == null ? "valid enviroment" : "UI");

        App(IUI uI, IEnviroment enviroment, IMovingObject movingObject)
        {
            UI = uI;
            Enviroment = enviroment;
            MovingObject = movingObject;

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
                UI.ShowMovingObjectPositionAndFacingDirection(this.Movable.CurrentPositionAndFacingDirection);
            }
        }

        public static App Run(IUI uI, IEnviroment enviroment, IMovingObject movingObject)
        {
            return new App(uI, enviroment, movingObject);
        }
    }
}
