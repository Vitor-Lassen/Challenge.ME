using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;
using Domain.VO;
using Exceptions;

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
            var result = GetById(orderId);
            if (result == null)
                throw new NotFoundException("pedido",orderId);
            _orderRepository.Remove(result);
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
            if (GetById(order.Id) != null)
                throw new AlredyExistsException("Pedido", order.Id);
            _orderRepository.Add(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
        public TotalOrder GetTotalOrder(string orderId)
        {
            var order = GetById(orderId);
            if (order == null)
                return null;
            var totalOrder = new TotalOrder(orderId);

            foreach(Item item in order.Items)
            {
                var amount = item.UnitPrice * item.Qtd;
                totalOrder.Amount += amount;
                totalOrder.Qtd += item.Qtd;
            }
            return totalOrder;
        }

        
    }
}
