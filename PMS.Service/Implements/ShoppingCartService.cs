using Microsoft.AspNetCore.Mvc;
using PMS.Common;
using PMS.Entity;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implements
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<JsonResult> CreateShoppingCart(ShoopingCartDto shoppingCart)
        {
            var isCartCreated = await _shoppingCartRepository.CreateShoppingCart(shoppingCart);
            if (isCartCreated > 0)
            {
                return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "shopping cart", "created"));
            }
            return JsonResponse.FailureResponse(string.Format(Messages.failure, "shopping cart", "create"));
        }
    }
}
