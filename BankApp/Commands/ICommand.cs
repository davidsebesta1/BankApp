using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands
{
    public interface ICommand
    {
        public string Command { get; }
        public string Description { get; }

        public abstract bool Execute(ArraySegment<string> args, out string response);
    }
}
