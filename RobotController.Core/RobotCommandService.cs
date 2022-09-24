using System;
using System.Collections.Generic;
using System.Linq;
using RobotController.Core.Interfaces;
using RobotController.Core.Abstractions;
namespace RobotController.Core
{
    public class RobotCommandService
    {
        IList<RobotCommand> AvailableCommands = new List<RobotCommand>();
        IList<char> RecievedCommands = new List<char>();
        IEnumerable<Type> AvailableCommandTypes => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(RobotCommand).IsAssignableFrom(p) && !p.IsAbstract);

        public RobotCommandService(IRobot robot)
        {
            foreach (var availableCommandType in AvailableCommandTypes)
            {
                AvailableCommands.Add((RobotCommand)Activator.CreateInstance(availableCommandType,robot));
            }
        }

        void RunCommands()
        {
            if (this.RecievedCommands != null)
            {
                foreach (var code in RecievedCommands)
                {
                    AvailableCommands.First(command => command.Code == code).Execute();
                }
            }
        }

        public void Run()
        {
            this.ListenToCommands();
            this.RunCommands();
        }

        void ListenToCommands()
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

