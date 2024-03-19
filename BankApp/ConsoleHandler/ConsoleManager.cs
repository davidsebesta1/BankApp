using BankApp.Commands;
using BankApp.Commands.Cmds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ConsoleHandler
{
    public class ConsoleManager
    {
        public void Init()
        {
            while (true)
            {
                string input = Console.ReadLine();

                foreach (var commandEntry in CommandHandler.RegisteredCommands)
                {
                    Console.WriteLine($"Command: {commandEntry.Key}, Description: {commandEntry.Value.Description}");
                }

            }
        }
    }
}
