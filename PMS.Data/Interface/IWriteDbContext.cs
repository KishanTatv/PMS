using Microsoft.EntityFrameworkCore;

namespace PMS.Data.Interface
{
    public interface IWriteDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
