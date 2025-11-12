using PMS.Data.Models;
using PMS.Entity.Models;
using Riok.Mapperly.Abstractions;

namespace PMS.Repository
{
    [Mapper]
    public partial class Mapper
    {
        public partial IEnumerable<UserDto> ToListUserResponse(IEnumerable<User> request);
        public partial IEnumerable<CategoryDto> ToListCategoryResponse(IEnumerable<Category> request);
    }

    [Mapper]
    public partial class CategoryMapper
    {
        public partial IEnumerable<CategoryDto> MapList(IEnumerable<Category> request);
    }

    [Mapper]
    public partial class CoverMapper
    {
        public partial IEnumerable<CoverDto> MapList(IEnumerable<CoverType> product);
    }

    [Mapper]
    public partial class ProductMapper
    {
        public partial IEnumerable<ProductDto> MapList(IEnumerable<Product> product);
    }


    [Mapper]
    public partial class UserMapper
    {
        public partial IEnumerable<UserDto> MapList(IEnumerable<User> product);
    }
}
