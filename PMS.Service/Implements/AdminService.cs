using Microsoft.AspNetCore.Mvc;
using PMS.Common;
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
           return JsonResponse.SuccessResponse(userList, string.Format(Messages.success, "User list", "retrived"));
        }

        public async Task<JsonResult> AddNewUser(UserDto user)
        {
            int rowCount = await _adminRepository.AddNewUser(user);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "add", "new user"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "New user", "added"));
        }

        public async Task<JsonResult> GetCategory(PageCommonDto requestData)
        {
            IEnumerable<CategoryDto> categoryList = await _adminRepository.GetCategory(requestData);
            return JsonResponse.SuccessResponse(categoryList, string.Format(Messages.success, "Category list", "retrived"));
        }

        public async Task<JsonResult> AddCategory(CategoryDto requestModel)
        {
            int rowCount = await _adminRepository.AddNewCategory(requestModel);
            if (rowCount <= 0)
            {
                return JsonResponse.FailureResponse(string.Format(Messages.failure, "add", "new category"));
            }
            return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "New category", "added"));
        }
    }
}
