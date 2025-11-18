using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<int> AddNewUser(UserDto user);

        Task<IEnumerable<CategoryDto>> GetCategory(PageCommonDto requestData);
        Task<CategoryDto> GetCategoryById(int categoryId);
        Task<int> AddNewCategory(CategoryDto category);
        Task<int> DeleteCategory(int categoryId);


        Task<IEnumerable<CoverDto>> GetCover(PageCommonDto requestData);
        Task<CoverDto> GetCoverById(int coverId);
        Task<int> AddUpdateCover(CoverDto category);
        Task<int> DeleteCover(int coverId);

        Task<IEnumerable<ProductShowDto>> GetProduct(PageCommonDto requestData);
        Task<bool> CheckExistingProduct(string name, int id);
        Task<ProductDetailDto> GetProductById(int productId);
        Task<int> AddUpdateProduct(ProductDetailDto product);
        Task<int> DeleteProduct(int productId);
    }
}
