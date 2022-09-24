using System;
using System.Collections.Generic;
using RobotController.Core.Abstractions;

namespace RobotController.Core.Interfaces
{
    public interface IUI
    {
        string GetRoomWidthAndDepth();
        string GetRobotStartPositionAndFacingDirection();
        string GetRobotCommands(IEnumerable<RobotCommand> availableCommands);
        void ShowRobotPositionAndFacingDirection(string position);
        void ShowErrorMessage(string message);

    }
}
