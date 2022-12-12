using BankApp.Application.Common.Interfaces;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;

namespace BankApp.Data.Repositories
{
    public class MileageRepository : Repository<Mileage>, IMileageRepository
    {
        public MileageRepository(BankContext context) : base(context)
        {
        }
    }
}
