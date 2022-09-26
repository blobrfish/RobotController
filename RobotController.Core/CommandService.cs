using System;
using System.Collections.Generic;
using System.Linq;
using RobotController.Core.Interfaces;
using RobotController.Core.Abstractions;
namespace RobotController.Core
{
    public class CommandService
    {
        IList<Command> AvailableCommands = new List<Command>();
        IList<char> RecievedCommands = new List<char>();
        IEnumerable<Type> AvailableCommandTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(Command).IsAssignableFrom(p) && !p.IsAbstract);
        IUI UI;
        public CommandService(IUI uI, IEnviroment enviroment, IMovable movable)
        {
            this.UI = uI;
            if (this.AvailableCommandTypes != null)
            {
                foreach (var availableCommandType in AvailableCommandTypes)
                {
                    AvailableCommands.Add((Command)Activator.CreateInstance(availableCommandType, enviroment, movable));
                }
            }
        }

        void ExecuteCommands()
        {
            if (this.RecievedCommands != null)
            {
                foreach (char code in RecievedCommands)
                {
                    AvailableCommands.First(command => command.Code == code).Execute();
                }
            }
        }

        public void Run()
        {
            this.ListenForCommands();
            this.ExecuteCommands();
        }

        void ListenForCommands()
        {
            string inputAsString = this.UI.GetCommands(this.AvailableCommands);
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

