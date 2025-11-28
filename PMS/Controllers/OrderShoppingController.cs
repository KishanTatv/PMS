using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;
using PMS.Service.Interface;

namespace PMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderShoppingController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderShoppingController(IShoppingCartService shoppingCartService, IOrderDetailService orderDetailService)
        {
            _shoppingCartService = shoppingCartService;
            _orderDetailService = orderDetailService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetCartInfo()
        {
            JsonResult data = await _shoppingCartService.GetCartInfo();
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddToCart(ShoopingCartDto shoppingCartDto)
        {
            JsonResult data = await _shoppingCartService.CreateShoppingCart(shoppingCartDto);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CartCountIncrease(int cartId)
        {
            JsonResult data = await _shoppingCartService.CartCountIncrease(cartId);
            return data;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CartCountDecrease(int cartId)
        {
            JsonResult data = await _shoppingCartService.CartCountDecrease(cartId);
            return data;
        }
    }
}
