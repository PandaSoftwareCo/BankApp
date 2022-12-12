using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BankContext context) : base(context)
        {
        }
    }
}
