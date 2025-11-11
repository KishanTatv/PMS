using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<int> AddNewUser(UserDto user);
        Task<IEnumerable<CategoryDto>> GetCategory(PageCommonDto requestData);
    }
}
