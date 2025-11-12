using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;

namespace PMS.Service.Interface
{
    public interface IAdminService
    {
        Task<JsonResult> GetAllUsers();
        Task<JsonResult> AddNewUser(UserDto user);
        Task<JsonResult> GetCategory(PageCommonDto requestData);
        Task<JsonResult> AddCategory(CategoryDto category);
        Task<JsonResult> GetCover(PageCommonDto requestData);
        Task<JsonResult> AddUpdateCover(CoverDto category);
        Task<JsonResult> GetProduct(PageCommonDto requestData);
        Task<JsonResult> AddUpdateProduct(ProductDetailDto product);
    }
}
