using Domain.Contracts.Application;
using Domain.Contracts.Services;
using Domain.Entities;
using DTO = Domain.DTO;

namespace Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderService _orderService; 
        public OrderApplication(IOrderService orderService)
        {
            _orderService = orderService; 
        }

        public IEnumerable<DTO.Order> GetAllOrders()
        {
            var result = _orderService.GetAll();
            return result.Select(x => new DTO.Order(x));
        }

        public void InsertOrder(DTO.Order order)
        {
            _orderService.Insert(new Order(order));
        }
    }
}
