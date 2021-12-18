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

        public void Delete(string orderId)
        {
            _orderService.Delete(orderId);
        }

        public IEnumerable<DTO.Order> GetAll()
        {
            var result = _orderService.GetAll();
            return result.Select(x => new DTO.Order(x));
        }

        public DTO.Order GetbyId(string orderId)
        {
            var result = _orderService.GetById(orderId);
            return result != null ? new DTO.Order(result) : null;
        }

        public void Insert(DTO.Order order)
        {
            if(GetbyId(order.Id) != null)
                throw new Exception($"Pedido {order.Id} já existe");
            _orderService.Insert(new Order(order));
           
        }

        public void Update(DTO.Order order)
        {
            _orderService.Update(new Order(order));
        }
    }
}
