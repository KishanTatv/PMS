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

        public async Task<JsonResult> GetCartInfo()
        {
            var cartInfo = await _shoppingCartRepository.GetCartInfo();
            return JsonResponse.SuccessResponse(cartInfo, string.Format(Messages.success, "cart info", "retrieved"));
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

        public async Task<JsonResult> CartCountIncrease(int cartId)
        {
            var isCartCountIncreased = await _shoppingCartRepository.CartCountIncrease(cartId);
            if (isCartCountIncreased > 0)
            {
                return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "cart count", "increased"));
            }
            return JsonResponse.FailureResponse(string.Format(Messages.failure, "cart count", "increase"));
        }

        public async Task<JsonResult> CartCountDecrease(int cartId)
        {
            var isCartCountDecreased = await _shoppingCartRepository.CartCountDecrease(cartId);
            if (isCartCountDecreased > 0)
            {
                return JsonResponse.SuccessResponse(string.Empty, string.Format(Messages.success, "cart count", "decreased"));
            }
            return JsonResponse.FailureResponse(string.Format(Messages.failure, "cart count", "decrease"));
        }
    }
}
