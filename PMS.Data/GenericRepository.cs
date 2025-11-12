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

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return await _readDbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int? skip = null, 
            int? take = null, 
            params Expression<Func<T, object>>[] includes)
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
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return await query.ToListAsync();
        }


        public async Task<IEnumerable<TResult>> GetAllProjected<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? skip = null,
            int? take = null)
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
            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }
            return await query.Select(selector).ToListAsync();
        }

        public async Task<IQueryable<T>> Query()
        {
            return await Task.FromResult(_readDbContext.Set<T>().AsQueryable());
        }

        public async Task Add(T entity)
        {
            await _writeDbContext.Set<T>().AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _writeDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _writeDbContext.Set<T>().Remove(entity);
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _writeDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
