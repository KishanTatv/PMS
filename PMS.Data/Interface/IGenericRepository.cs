using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PMS.Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? skip = null, int? take = null);
        Task<IQueryable<T>> Query();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
