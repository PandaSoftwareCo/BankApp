using BankApp.Core.Domain.Enums;

namespace BankApp.Core.Domain.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? TransitNumber { get; set; }
        public string? BankNumber { get; set; }
        public string? AbaRoutingNumber { get; set; }
        public string? SwiftCode { get; set; }
        public AccountType? AccountType { get; set; }
        public ICollection<BankTransaction>? BankTransactions { get; set; } = new HashSet<BankTransaction>();
        public ICollection<Balance>? Balances { get; set; } = new HashSet<Balance>();
    }
}
