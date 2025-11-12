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
        private readonly IGenericRepository<CoverType> _coverRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public AdminRepository(IGenericRepository<User> userRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<CoverType> coverRepository, IGenericRepository<Product> productRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _coverRepository = coverRepository;
            _productRepository = productRepository;
        }

        #region User Methods
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
        #endregion

        #region Category 
        public async Task<IEnumerable<CategoryDto>> GetCategory(PageCommonDto requestData)
        {
            var categoryData = await _categoryRepository.GetAll(skip: requestData.PageNumber * requestData.PageSize, take: requestData.PageSize);
            return new CategoryMapper().MapList(categoryData);
        }

        public async Task<int> AddNewCategory(CategoryDto category)
        {
            var newCategory = new Category()
            {
                Name = category.Name,
                DisplayOrder = category.DisplayOrder,
                CreatedDateTime = DateTime.UtcNow
            };
            if(category.Id > 0)
            {
                newCategory.Id = category.Id;
                await _categoryRepository.Update(newCategory);
            }
            else
            {
                await _categoryRepository.Add(newCategory);
            }
            return await _categoryRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetById(categoryId);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                return await _categoryRepository.SaveChangesAsync();
            }
            return 0;
        }
        #endregion

        #region Cover
        public async Task<IEnumerable<CoverDto>> GetCover(PageCommonDto requestData)
        {
            var categoryData = await _coverRepository.GetAll(skip: requestData.PageNumber * requestData.PageSize, take: requestData.PageSize);
            return new CoverMapper().MapList(categoryData);
        }

        public async Task<int> AddUpdateCover(CoverDto category)
        {
            CoverType newCover = new CoverType() { Name = category.Name };
            if (category.Id > 0)
            {
                newCover.Id = category.Id;
                await _coverRepository.Update(newCover);
            }
            else
            {
                await _coverRepository.Add(newCover);
            }
            return await _coverRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteCover(int coverId)
        {
            var cover = await _coverRepository.GetById(coverId);
            if (cover != null)
            {
                _coverRepository.Delete(cover);
                return await _coverRepository.SaveChangesAsync();
            }
            return 0;
        }
        #endregion

        #region Product
        public async Task<IEnumerable<ProductShowDto>> GetProduct(PageCommonDto requestData)
        {
            //var productData = await _productRepository.GetAll(
            //    skip: requestData.PageNumber * requestData.PageSize, take: requestData.PageSize,
            //    includes: [p => p.Category, p => p.CoverType]
            //    );
            var productData = await _productRepository.GetAllProjected(
                selector: p => new ProductShowDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    ISBN = p.ISBN,
                    Price = p.Price,
                    CategoryName = p.Category!.Name,
                    CoverTypeName = p.CoverType!.Name
                },
                skip: requestData.PageNumber * requestData.PageSize,
                take: requestData.PageSize
                );
            return productData;
        }

        public async Task<int> AddUpdateProduct(ProductDetailDto product)
        {
            Product newProduct = new Product()
            {
                Title = product.Title,
                Author = product.Author,
                Description = product.Description,
                ISBN = product.ISBN,
                ListPrice = product.ListPrice,
                Price = product.Price,
                Price50 = product.Price50,
                Price100 = product.Price100,
                CategoryId = product.CategoryId,
                CoverTypeId = product.CoverTypeId,
                ImageUrl = product.ImageUrl ?? string.Empty
            };
            if (product.Id > 0)
            {
                newProduct.Id = product.Id;
                await _productRepository.Update(newProduct);
            }
            else
            {
                await _productRepository.Add(newProduct);
            }
            return await _productRepository.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _productRepository.GetById(productId);
            if (product != null)
            {
                _productRepository.Delete(product);
                return await _productRepository.SaveChangesAsync();
            }
            return 0;
        }
        #endregion
    }
}
