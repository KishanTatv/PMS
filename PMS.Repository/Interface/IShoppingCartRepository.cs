using PMS.Entity.Models;

namespace PMS.Repository.Interface
{
    public interface IShoppingCartRepository
    {
        Task<int> CreateShoppingCart(ShoopingCartDto shoppingCart);
    }
}
