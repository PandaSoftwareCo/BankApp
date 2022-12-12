using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;

namespace BankApp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BankContext context) : base(context)
        {
        }
    }
}
