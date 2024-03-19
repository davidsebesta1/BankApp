using BankApp.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class GetAllAccoundsCommand : ICommand
    {
        public string Command => "GetAll";

        public string Description => "Get all accounds";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            response = "";
            foreach (var account in BankAccount.AllAccounts)
            {
                
                string accound =  $"ID: {account.AccID}, Jméno: {account.OwnerFirstName}" +
                            $" {account.OwnerLastName}, Zůstatek: {account.Finance} Kč";
                response += accound;
            }
            return true;
        }
    }
}
