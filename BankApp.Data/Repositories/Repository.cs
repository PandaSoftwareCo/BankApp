using BankApp.Application.Common.Interfaces;
using BankApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BankContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public Repository(BankContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAsyncEnumerable<T> Get()
        {
            return _context.Set<T>().AsAsyncEnumerable();
        }

        public async Task<T?> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Add(T item)
        {
            return _context.Set<T>().Add(item).Entity;
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }
    }
}
