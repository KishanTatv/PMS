using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;

namespace PMS.Service.Interface
{
    public interface IAdminService
    {
        Task<JsonResult> GetAllUsers();
        Task<JsonResult> AddNewUser(UserDto user);
    }
}
