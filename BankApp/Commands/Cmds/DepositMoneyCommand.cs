using BankApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class DepositMoneyCommand : ICommand
    {
        public string Command => "Deposit";

        public string Description => "Deposits specified amount of money, Arguments: [accountID] [amount]";

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
