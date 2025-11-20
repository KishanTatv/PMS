using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;

namespace PMS.Service.Interface
{
    public interface IAuthService
    {
        Task<JsonResult> Register(RegisterModel model);
        Task<JsonResult> Login(LoginModel model);
    }
}
