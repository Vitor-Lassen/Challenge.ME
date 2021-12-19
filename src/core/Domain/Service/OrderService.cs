using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(string orderId)
        {
            _orderRepository.Remove(GetById(orderId));
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        
        }

        public Order GetById(string orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public void Insert(Order order)
        {

            _orderRepository.Add(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }


        
    }
}
