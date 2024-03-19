using BankApp.Commands;

namespace BankApp.ConsoleHandler
{
    public static class ConsoleManager
    {
        public static void Init()
        {
            while (true)
            {
                PrintAllCommands();
                string input = Console.ReadLine();
                string[] arguments = input.Split(' ');

                if (!CommandHandler.TryExecuteCommand(arguments[0], new ArraySegment<string>(arguments, 1, arguments.Length - 1), out string response))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(response);
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response);
            }
        }

        public static void PrintAllCommands()
        {
            foreach (var commandEntry in CommandHandler.RegisteredCommands)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(commandEntry.Key);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(commandEntry.Value.Description);
            }
        }
    }
}
