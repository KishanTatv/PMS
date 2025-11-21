using Microsoft.AspNetCore.Identity;
using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<IdentityUser?> ValidUserName(string username);
        Task<bool> Register(RegisterModel model);
        Task<string> Login(LoginModel model);
        Task<bool> ChangePassword(IdentityUser user, ChangePasswordModel model);
    }
}
