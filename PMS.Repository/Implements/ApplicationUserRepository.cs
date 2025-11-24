using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IGenericRepository<ApplicationUser> _applicationUserRepository;
        public ApplicationUserRepository(IGenericRepository<ApplicationUser> applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
    }
}
