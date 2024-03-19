using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Cmds
{
    public class CreateAccountCommand : ICommand
    {
        public string Command => "AddAccount";

        public string Description => "Adds a user account";

        public bool Execute(ArraySegment<string> args, out string response)
        {
            
        }
    }
}
