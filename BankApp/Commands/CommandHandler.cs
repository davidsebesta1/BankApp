using BankApp.ConsoleHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.Commands
{
    public static class CommandHandler
    {
        public static Dictionary<string, ICommand> RegisteredCommands = new Dictionary<string, ICommand>();

        public static bool TryExecuteCommand(string commandName, ArraySegment<string> args, out string response)
        {
            if (RegisteredCommands == null)
            {
                response = "Command not found";
                return false;
            }

            if (RegisteredCommands.TryGetValue(commandName, out ICommand command))
            {
                return command.Execute(args, out response);
            }

            response = "Command not found";
            return false;
        }

        private static bool TryRegisterCommand(Type type)
        {
            if (Activator.CreateInstance(type) is not ICommand command)
            {
                return false;
            }

            RegisteredCommands.Add(command.Command, command);
            return true;
        }

        public static bool TryRegisterCommand<T>() where T : ICommand
        {
            return TryRegisterCommand(typeof(T));
        }
    }
}
