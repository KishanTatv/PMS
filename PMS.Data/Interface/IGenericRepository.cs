using System.Linq.Expressions;

namespace PMS.Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int? skip = null, 
            int? take = null, 
            params Expression<Func<T, object>>[] includes);


        Task<IEnumerable<TResult>> GetAllProjected<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? skip = null,
            int? take = null);

        Task<IQueryable<T>> Query();

        Task Add(T entity);

        Task Update(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
