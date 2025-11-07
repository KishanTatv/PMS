using Microsoft.AspNetCore.Mvc;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implements
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository) {
            _adminRepository = adminRepository;
        }

        public async Task<JsonResult> GetAllUsers()
        {
           IEnumerable<UserDto> userList = await _adminRepository.GetAllUsers();
           return JsonResponse.SuccessResponse(userList, "User list retrieved successfully");
        }

        public async Task<JsonResult> AddNewUser(UserDto user)
        {
            int rowCount = await _adminRepository.AddNewUser(user);
            if (rowCount > 0)
            {
                return JsonResponse.SuccessResponse(string.Empty, "New user added successfully");
            }
            else
            {
                return JsonResponse.FailureResponse("Failed to add new user");
            }
        }
    }
}
