using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<int> AddNewUser(UserDto user);
        Task<IEnumerable<CategoryDto>> GetCategory(PageCommonDto requestData);
        Task<int> AddNewCategory(CategoryDto category);


        Task<IEnumerable<CoverDto>> GetCover(PageCommonDto requestData);
        Task<int> AddUpdateCover(CoverDto category);

        Task<IEnumerable<ProductDto>> GetProduct(PageCommonDto requestData);
        Task<int> AddUpdateProduct(ProductDetailDto product);
    }
}
