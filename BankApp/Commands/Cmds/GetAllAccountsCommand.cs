using BankApp.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class GetAllAccountsCommand : ICommand
    {
        public string Command => "GetAll";

        public string Description => "Get all accounts";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if(args.Count == 0) 
            {
                response = "There is no account to delete";
                return false;
            }

            response = "";
            foreach (var account in BankAccount.AllAccounts)
            {
                
                string accound =  $"ID: {account.AccID}, Name: {account.OwnerFirstName}" +
                                  $" {account.OwnerLastName}, Deposit: {account.Finance} Kč \n";
                response += accound;
            }
            return true;
        }
    }
}
