using BankApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class DeleteAccountCommand : ICommand
    {
        public string Command => "DeleteAccount";

        public string Description => "Deletes account with specified ID, Arguments: [accountID]";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 1)
            {
                long accIdSender;
                if (!long.TryParse(args[0], out accIdSender))
                {
                    response = "Account sender id is invalid";
                    return false;
                }

                BankAccount accountSender = BankAccount.AllAccounts.FirstOrDefault(n => n.AccID == accIdSender);
                if (accountSender == null)
                {
                    response = "Account sender id does not exists";
                    return false;
                }

                BankAccount.AllAccounts.Remove(accountSender);
                response = "Deleted account";
                return true;
            }

            response = "Please add required argument(s)";
            return false;
        }
    }
}
