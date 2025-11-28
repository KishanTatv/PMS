using PMS.Data.Models;
using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<ApplicationUser?> ValidUserName(string username);
        Task<bool> Register(RegisterModel model);
        Task<string> Login(LoginModel model);
        Task<bool> ChangePassword(ApplicationUser user, ChangePasswordModel model);
        Task<bool> ResetPassword(ApplicationUser user, string password);
    }
}
