using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;

namespace PMS.Service.Interface
{
    public interface IShoppingCartService
    {
        Task<JsonResult> CreateShoppingCart(ShoopingCartDto shoppingCart);
    }
}
