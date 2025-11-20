using Microsoft.AspNetCore.Mvc;
using PMS.Common;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<JsonResult> Login(LoginModel model)
        {
            string token = await _authRepository.Login(model);
            if (!string.IsNullOrEmpty(token))
            {
                return JsonResponse.SuccessResponse(token, string.Format(Messages.success, "User", "logged in"));
            }
            return JsonResponse.FailureResponse("Invalid login attempt");
        }

        public async Task<JsonResult> Register(RegisterModel model)
        {
            bool isRegistered = await _authRepository.Register(model);
            if (isRegistered)
            {
                return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "User", "registered"));
            }
            return JsonResponse.FailureResponse("User registration failed");
        }
    }
}
