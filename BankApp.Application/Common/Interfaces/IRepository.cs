using BankApp.Core.Domain.Entities;

namespace BankApp.Application.Common.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
        IAsyncEnumerable<T> Get();
        Task<T?> FindAsync(int id);
        T Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
