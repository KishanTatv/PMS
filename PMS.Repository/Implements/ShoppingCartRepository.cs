using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Entity.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        public ShoppingCartRepository(IGenericRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<int> CreateShoppingCart(ShoopingCartDto shoppingCart)
        {
            ShoppingCart cartData = new ShoppingCart
            {
                ProductId = shoppingCart.ProductId,
                Count = 1,
                ApplicationUserId = shoppingCart.ApplicationUserId,
            };
            await _shoppingCartRepository.Add(cartData);
            return await _shoppingCartRepository.SaveChangesAsync();
        }
    }
}
