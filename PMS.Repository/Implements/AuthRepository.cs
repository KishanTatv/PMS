using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PMS.Common.JWT;
using PMS.Data.Models;
using PMS.Entity.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class AuthRepository : IAuthRepository
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ApplicationUser?> ValidUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var user = new ApplicationUser { Name = model.Name, UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<string> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await ValidUserName(model.Username);
                JwtSettingDto jwtSettingDto = _configuration.GetSection("Jwt").Get<JwtSettingDto>()!;
                jwtSettingDto.ExpiresIn = DateTime.Now.AddMinutes(30);
                var token = JwtToken.GenerateToken(user!, jwtSettingDto);
                await _signInManager.SignInAsync(user!, true);
                return token;
            }
            return string.Empty;
        }

        public async Task<bool> ChangePassword(ApplicationUser user, ChangePasswordModel model)
        {
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result.Succeeded;
        }

        public async Task<bool> ResetPassword(ApplicationUser user, string password)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
            var result = await _userManager.ResetPasswordAsync(user!, token, password);
            return result.Succeeded;
        }
    }
}
