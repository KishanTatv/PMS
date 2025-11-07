using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Entity.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class AdminRepository : IAdminRepository
    {

        private readonly IGenericRepository<User> _userRepository;
        private readonly Mapper _mapper;

        public AdminRepository(IGenericRepository<User> userRepository, Mapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return _mapper.ToListUserResponse(await _userRepository.GetAll());
        }

        public async Task<int> AddNewUser(UserDto user)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNo = user.PhoneNo,
                CreatedBy = "1",
                CreatedDate = DateTime.UtcNow
            };
            await _userRepository.Add(newUser);
            return await _userRepository.SaveChangesAsync();
            
        }
    }
}
