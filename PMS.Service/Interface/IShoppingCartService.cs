using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;

namespace PMS.Service.Interface
{
    public interface IShoppingCartService
    {
        Task<JsonResult> GetCartInfo();
        Task<JsonResult> CreateShoppingCart(ShoopingCartDto shoppingCart);
        Task<JsonResult> CartCountIncrease(int cartId);
        Task<JsonResult> CartCountDecrease(int cartId);
    }
}
