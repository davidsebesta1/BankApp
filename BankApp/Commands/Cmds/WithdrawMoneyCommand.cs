using BankApp.Objects;

namespace BankApp.Commands.Cmds
{
    public class WithdrawMoneyCommand : ICommand
    {
        public string Command => "Withdraw";

        public string Description => "Withdraw specified amount of money from specified account, Arguments: [accountID] [amount]";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 2)
            {
                long accId;
                if (!long.TryParse(args[0], out accId))
                {
                    response = "Account id is invalid";
                    return false;
                }

                if (!double.TryParse(args[1], out double amount))
                {
                    response = "Money amount is invalid";
                    return false;
                }

                var account = BankAccount.AllAccounts.FirstOrDefault(n => n.AccID == accId);
                if (account == null)
                {
                    response = "Account id does not exists";
                    return false;
                }

                account.Finance += (decimal)amount;

                response = "Success";
                return true;
            }

            response = "Please add arguments";
            return false;
        }
    }
}
