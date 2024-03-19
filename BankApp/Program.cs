using BankApp.Commands;
using BankApp.Commands.Cmds;
using BankApp.ConsoleHandler;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandHandler.TryRegisterCommand<CreateAccountCommand>();
            CommandHandler.TryRegisterCommand<DeleteAccountCommand>();
            CommandHandler.TryRegisterCommand<DepositMoneyCommand>();
            CommandHandler.TryRegisterCommand<GetAllAccoundsCommand>();
            CommandHandler.TryRegisterCommand<TransferMoneyCommand>();
            CommandHandler.TryRegisterCommand<WithdrawMoneyCommand>();
            CommandHandler.TryRegisterCommand<GetHistoryCommand>();

            ConsoleManager.Init();
        }
    }
}