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

        [HttpGet("[action]")]
        public async Task<ActionResult> GetCover([FromQuery] PageCommonDto requestData)
        {
            JsonResult data = await _adminService.GetCover(requestData);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddUpdateCover(CoverDto reqModel)
        {
            JsonResult data = await _adminService.AddUpdateCover(reqModel);
            return data;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProduct([FromQuery] PageCommonDto requestData)
        {
            JsonResult data = await _adminService.GetProduct(requestData);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddUpdateProduct(ProductDetailDto reqModel)
        {
            JsonResult data = await _adminService.AddUpdateProduct(reqModel);
            return data;
        }
    }
}
