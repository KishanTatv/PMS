using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IShoppingCartRepository
    {
        Task<CartDto> GetCartInfo();
        Task<int> CreateShoppingCart(ShoopingCartDto shoppingCart);
        Task<int> CartCountIncrease(int cartId);
        Task<int> CartCountDecrease(int cartId);
    }
}
