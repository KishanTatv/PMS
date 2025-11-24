using PMS.Data.Interface;
using PMS.Data.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implements
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        public OrderDetailRepository(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
    }
}
