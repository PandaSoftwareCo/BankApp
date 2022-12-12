using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;

namespace BankApp.Data.Repositories
{
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        public BalanceRepository(BankContext context) : base(context)
        {
        }
    }
}
