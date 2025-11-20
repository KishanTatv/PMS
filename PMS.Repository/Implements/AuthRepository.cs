using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PMS.Common.JWT;
using PMS.Entity.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class AuthRepository : IAuthRepository
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
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
                var user = await _userManager.FindByNameAsync(model.Username);
                JwtSettingDto jwtSettingDto = _configuration.GetSection("Jwt").Get<JwtSettingDto>()!;
                jwtSettingDto.ExpiresIn = DateTime.Now.AddMinutes(30);
                var token = JwtToken.GenerateToken(user!, jwtSettingDto);
                return token;
            }
            return string.Empty;
        }


    }
}
