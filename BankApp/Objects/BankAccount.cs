using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Objects
{
    public class BankAccount : IEquatable<BankAccount?>
    {
        public static List<BankAccount> AllAccounts = new List<BankAccount>();

        public static int LastId { get; private set; } = 0;
        public long AccID;

        public string OwnerFirstName;
        public string OwnerLastName;

        public decimal Finance;

        public BankAccount(string ownerFirstName, string ownerLastName)
        {
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            Finance = 0;
            AccID = LastId++;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BankAccount);
        }

        public bool Equals(BankAccount? other)
        {
            return other is not null &&
                   AccID == other.AccID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccID);
        }

        public static bool operator ==(BankAccount? left, BankAccount? right)
        {
            return EqualityComparer<BankAccount>.Default.Equals(left, right);
        }

        public static bool operator !=(BankAccount? left, BankAccount? right)
        {
            return !(left == right);
        }
    }
}
