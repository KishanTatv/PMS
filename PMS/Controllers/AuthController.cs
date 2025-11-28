using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;
using PMS.Service.Interface;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            JsonResult data = await _authService.Register(model);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            JsonResult data = await _authService.Login(model);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            JsonResult data = await _authService.ChangePassword(model);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> ResetPassword(string userName, string password)
        {
            JsonResult data = await _authService.ResetPassword(userName, password);
            return data;
        }
    }
}
