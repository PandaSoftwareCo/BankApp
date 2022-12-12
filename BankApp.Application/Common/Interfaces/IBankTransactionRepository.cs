using BankApp.Core.Domain.Entities;

namespace BankApp.Application.Common.Interfaces
{
    public interface IBankTransactionRepository : IRepository<BankTransaction>
    {
        IAsyncEnumerable<BankTransaction> GetTransactions();
    }
}
