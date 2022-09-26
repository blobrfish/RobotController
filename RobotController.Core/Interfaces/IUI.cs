using System;
using System.Collections.Generic;
using RobotController.Core.Abstractions;

namespace RobotController.Core.Interfaces
{
    public interface IUI
    {
        string GetCommands(IEnumerable<Command> availableCommands);
        void ShowMovingObjectPositionAndFacingDirection(string position);
        void ShowErrorMessage(string message);
    }
}
