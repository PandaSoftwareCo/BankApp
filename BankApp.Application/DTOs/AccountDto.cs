using BankApp.Core.Domain.Entities;
using BankApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
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
