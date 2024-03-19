using BankApp.Objects;

namespace BankApp.Commands.Cmds
{
    public class TransferMoneyCommand : ICommand
    {
        public string Command => "Transfer";

        public string Description => "Transfers specified amount of money from one account to another, Arguments: [senderAccId] [targetAccId] [Amount]";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 2)
            {
                long accIdSender;
                if (!long.TryParse(args[0], out accIdSender))
                {
                    response = "Account sender id is invalid";
                    return false;
                }

                long accIdReceiver;
                if (!long.TryParse(args[0], out accIdReceiver))
                {
                    response = "Account receiver id is invalid";
                    return false;
                }

                if (!double.TryParse(args[1], out double amount))
                {
                    response = "Money amount is invalid";
                    return false;
                }

                var accountSender = BankAccount.AllAccounts.FirstOrDefault(n => n.AccID == accIdSender);
                var accountReceiver = BankAccount.AllAccounts.FirstOrDefault(n => n.AccID == accIdSender);
                if (accountSender == null)
                {
                    response = "Account sender id does not exists";
                    return false;
                }

                if (accountReceiver == null)
                {
                    response = "Account receiver id does not exists";
                    return false;
                }

                accountReceiver.Finance += (decimal)amount;
                accountSender.Finance -= (decimal)amount;

                response = "Success";
                return true;
            }

            response = "Please add required arguments";
            return false;
        }
    }
}
