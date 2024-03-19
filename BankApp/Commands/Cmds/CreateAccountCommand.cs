using BankApp.Objects;

namespace BankApp.Commands.Cmds
{
    public class CreateAccountCommand : ICommand
    {
        public string Command => "AddAccount";

        public string Description => "Adds a user account, Arguments: [first name] [last name]";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 2)
            {
                BankAccount acc = new BankAccount(args[0], args[1]);
                BankAccount.AllAccounts.Add(acc);

                response = "Account created";
                return true;
            }

            response = "Please add arguments";
            return false;
        }
    }
}
