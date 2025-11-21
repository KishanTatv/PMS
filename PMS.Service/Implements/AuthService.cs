using Microsoft.AspNetCore.Mvc;
using PMS.Common;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;
using System.Net;

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
            return JsonResponse.FailureResponse(Messages.invalidCredential, HttpStatusCode.Unauthorized);
        }

        public async Task<JsonResult> Register(RegisterModel model)
        {
            bool isRegistered = await _authRepository.Register(model);
            if (isRegistered)
            {
                return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "User", "registered"));
            }
            return JsonResponse.FailureResponse(Messages.unExpectedError);
        }

        public async Task<JsonResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _authRepository.ValidUserName(model.Username);
            if (user != null)
            {
                bool isChanged = await _authRepository.ChangePassword(user, model);
                if (isChanged)
                {
                    return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "Password", "changed"));
                }
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "user password", "update"));
            }
            return JsonResponse.FailureResponse(string.Format(Messages.notFound, "User"), HttpStatusCode.NotFound);

        }
    }
}
