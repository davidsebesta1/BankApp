using BankApp.Objects;

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
                if (!long.TryParse(args[0], out long accId))
                {
                    response = "Account id is invalid";
                    return false;
                }

                response = string.Empty;
                if (AccountLog.Logs.TryGetValue(accId, out var logs))
                {
                    foreach (var log in logs)
                    {
                        response += $"{log.Command.Command} - {log.Stamp}";
                    }

                    return true;
                }


                response = "No logs found for this account";
                return false;
            }

            response = "Please add arguments";
            return false;
        }
    }
}
