using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Entity.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class AdminRepository : IAdminRepository
    {

        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public AdminRepository(IGenericRepository<User> userRepository, IGenericRepository<Category> categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userData = await _userRepository.GetAll(orderBy: o => o.OrderByDescending(u => u.CreatedDate));
            return new UserMapper().MapList(userData);
        }

        public async Task<int> AddNewUser(UserDto user)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNo = user.PhoneNo,
                Email = user.Email,
                CreatedBy = "1",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow
            };
            await _userRepository.Add(newUser);
            return await _userRepository.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<CategoryDto>> GetCategory(PageCommonDto requestData)
        {
            var categoryData = await _categoryRepository.GetAll(skip: requestData.PageNumber * requestData.PageSize, take: requestData.PageSize);
            return new CategoryMapper().MapList(categoryData);
        }
    }
}
