using Microsoft.EntityFrameworkCore;
using PMS.Data.Interface;
using System.Linq.Expressions;

namespace PMS.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IReadDbContext _readDbContext;
        protected readonly IWriteDbContext _writeDbContext;
        public GenericRepository(IReadDbContext readDbContext, IWriteDbContext writeDbContext)
        {
            _readDbContext = readDbContext;
            _writeDbContext = writeDbContext;
        }

        public async Task<T?> GetById(int id)
        {
            return await _readDbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        {
            IQueryable<T> query = _readDbContext.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

        public async Task<IQueryable<T>> Query()
        {
            return await Task.FromResult(_readDbContext.Set<T>().AsQueryable());
        }

        public async Task Add(T entity)
        {
            await _writeDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _writeDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _writeDbContext.Set<T>().Update(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _writeDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
