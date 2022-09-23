using System;
using System.Collections.Generic;
using System.Linq;
using RobotController.Core.Interfaces;
using RobotController.Core.Abstractions;
namespace RobotController.Core
{
    public class RobotCommandService
    {
        IList<Command> AvailableCommands = new List<Command>();
        IList<char> RecievedCommands = new List<char>();
        IEnumerable<Type> AvailableCommandTypes => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(Command).IsAssignableFrom(p) && !p.IsAbstract);

        public RobotCommandService(IRobot robot)
        {
            foreach (var availableCommandType in AvailableCommandTypes)
            {
                AvailableCommands.Add((Command)Activator.CreateInstance(availableCommandType, robot));
            }
        }

        public void RunCommands()
        {
            if (this.RecievedCommands != null)
            {
                foreach (var code in RecievedCommands)
                {
                    AvailableCommands.First(command => command.Code == code).Execute();
                }
            }
        }

        public void ListenToCommands()
        {
            string inputAsString = App.UI.GetRobotCommands(this.AvailableCommands);
            if (!String.IsNullOrEmpty(inputAsString))
            {
                IEnumerable<char> inputAsChars = inputAsString.ToCharArray();
                foreach (char inputAsChar in inputAsChars)
                {
                    this.RecievedCommands.Add(inputAsChar);
                }
            }

        }
    }
}

