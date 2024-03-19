using BankApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Objects
{
    internal class AccountLog
    {
        public static Dictionary<long, List<AccountLog>> Logs = new Dictionary<long, List<AccountLog>>();

        public ICommand Command;
        public ArraySegment<string> Args;
        public string Response;
    }
}
