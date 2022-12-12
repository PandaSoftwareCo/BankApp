using BankApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
namespace BankApp.Core.Domain.Entities
{
    public class BankTransaction
    {
        public int BankTransactionId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
