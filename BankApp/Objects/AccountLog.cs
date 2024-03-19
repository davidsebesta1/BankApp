using BankApp.Commands;

namespace BankApp.Objects
{
    internal class AccountLog
    {
        public static Dictionary<long, List<AccountLog>> Logs = new Dictionary<long, List<AccountLog>>();

        public ICommand Command;
        public DateTime Stamp;

        private AccountLog(ICommand command)
        {
            Command = command;
            Stamp = DateTime.Now;
        }

        public static void Log(long accId, ICommand command)
        {
            if(!Logs.TryGetValue(accId, out List<AccountLog> logs))
            {
                logs = new List<AccountLog>();
                Logs.Add(accId, logs);
            }
            logs.Add(new AccountLog(command));
        }
    }
}
