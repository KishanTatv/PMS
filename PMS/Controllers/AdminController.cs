using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;
using PMS.Service.Interface;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllUsers()
        {
            JsonResult data = await _adminService.GetAllUsers();
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateNewUser(UserDto reqModel)
        {
            JsonResult data = await _adminService.AddNewUser(reqModel);
            return data;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetCategory([FromQuery] PageCommonDto requestData)
        {
            JsonResult data = await _adminService.GetCategory(requestData);
            return data;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult> AddCategory(CategoryDto reqModel)
        {
            JsonResult data = await _adminService.AddCategory(reqModel);
            return data;
        }
    }
}
