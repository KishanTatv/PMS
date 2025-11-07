using Microsoft.EntityFrameworkCore;

namespace PMS.Data.Interface
{
    public interface IReadDbContext
    {
        DbSet<T> Set<T>() where T : class;
    }
}
