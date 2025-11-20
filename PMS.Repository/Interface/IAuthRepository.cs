using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<bool> Register(RegisterModel model);
        Task<string> Login(LoginModel model);
    }
}
