using PMS.Data.Models;
using PMS.Entity.Models;
using Riok.Mapperly.Abstractions;

namespace PMS.Repository
{
    [Mapper]
    public partial class Mapper
    {
        public partial IEnumerable<UserDto> ToListUserResponse(IEnumerable<User> request);
    }
}
