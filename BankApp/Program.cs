using BankApp.Commands.Cmds;
using BankApp.Commands;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandHandler.TryRegisterCommand<CreateAccountCommand>();
        }
    }
}