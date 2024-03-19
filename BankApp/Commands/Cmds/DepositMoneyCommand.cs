using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class DepositMoneyCommand : ICommand
    {
        public string Command => "deposit";

        public string Description => "Deposits specified amount of money";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 2)
            {

            }

            response = "Please add arguments";
            return false;
        }
    }
}
