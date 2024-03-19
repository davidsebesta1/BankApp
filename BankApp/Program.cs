using BankApp.Commands.Cmds;
using BankApp.Commands;
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
            CommandHandler.TryRegisterCommand<GetAllAccountsCommand>();
            CommandHandler.TryRegisterCommand<TransferMoneyCommand>();
            CommandHandler.TryRegisterCommand<WithdrawMoneyCommand>();

            ConsoleManager.Init();
        }
    }
}