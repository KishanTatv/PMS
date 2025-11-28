using Microsoft.AspNetCore.Http;
using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Entity.Models;
using PMS.Repository.Interface;
using System.Security.Claims;

namespace PMS.Repository.Implements
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string? userId;
        public ShoppingCartRepository(IGenericRepository<ShoppingCart> shoppingCartRepository, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _httpContextAccessor = httpContextAccessor;
            userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<CartDto> GetCartInfo()
        {
            IEnumerable<CartProductDto> data = await _shoppingCartRepository.GetAllProjected(
                filter: sc => sc.ApplicationUserId == userId,
                selector: x => new CartProductDto
                {
                    CartId = x.Id,
                    ProductId = x.ProductId,
                    ProductTitle = x.Product!.Title,
                    Price = x.Product.Price,
                    Count = x.Count,
                    TotalPrice = x.Count * x.Product.Price,
                });
            double totalAmount = data.Sum(x => x.TotalPrice);
            return new CartDto { CartProducts = data, CartTotal = totalAmount };
        }

        public async Task<int> CreateShoppingCart(ShoopingCartDto shoppingCart)
        {
            ShoppingCart? alredyInCart = await _shoppingCartRepository.GetFirstOrDefault(filter: sc => sc.ProductId == shoppingCart.ProductId && sc.ApplicationUserId == userId);
            if (alredyInCart != null)
            {
                alredyInCart.Count += shoppingCart.Count;
                await _shoppingCartRepository.Update(alredyInCart);
                return await _shoppingCartRepository.SaveChangesAsync();
            }
            else
            {
                ShoppingCart cartData = new ShoppingCart
                {
                    ProductId = shoppingCart.ProductId,
                    Count = shoppingCart.Count,
                    ApplicationUserId = userId!,
                };
                await _shoppingCartRepository.Add(cartData);
                return await _shoppingCartRepository.SaveChangesAsync();
            }
        }

        public async Task<int> CartCountIncrease(int cartId)
        {
            ShoppingCart? cartData = await _shoppingCartRepository.GetById(cartId);
            if (cartData != null)
            {
                cartData.Count += 1;
                await _shoppingCartRepository.Update(cartData);
                return await _shoppingCartRepository.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> CartCountDecrease(int cartId)
        {
            ShoppingCart? cartData = await _shoppingCartRepository.GetById(cartId);
            if (cartData != null && cartData.Count > 1)
            {
                cartData.Count -= 1;
                await _shoppingCartRepository.Update(cartData);
                return await _shoppingCartRepository.SaveChangesAsync();
            }
            return 0;
        }

    }
}
