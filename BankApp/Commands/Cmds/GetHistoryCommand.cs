using BankApp.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class GetHistoryCommand : ICommand
    {
        public string Command => "TransferHistory";

        public string Description => "Returns history of specified account id";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            if (args.Count == 1)
            {
                long accId;
                if (!long.TryParse(args[0], out accId))
                {
                    response = "Account id is invalid";
                    return false;
                }

                

                response = "Success";
                return true;
            }

            response = "Please add arguments";
            return false;
        }
    }
}
