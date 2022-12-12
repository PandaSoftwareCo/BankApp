using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repositories
{
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(BankContext context) : base(context)
        {
        }

        public IAsyncEnumerable<BankTransaction> GetTransactions()
        {
            return _context.BankTransactions.Include(i => i.Account).Include(i => i.Category).AsAsyncEnumerable();
        }

    }
}
