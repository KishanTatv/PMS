using Microsoft.AspNetCore.Mvc;
using PMS.Entity.Models;
using PMS.Service.Interface;

namespace PMS.Controllers
{
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

        [HttpPost("[action]")]
        public async Task<ActionResult> AddToCart(ShoopingCartDto shoppingCartDto)
        {
            JsonResult data = await _shoppingCartService.CreateShoppingCart(shoppingCartDto);
            return data;
        }
    }
}
