using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Entities;

namespace Domain.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _orderRepository.GetAll();
            foreach (var order in orders)
            {
                order.Items = _itemRepository.GetAllByOrder(order.Id);
            }
            return orders;
        }

        public void Insert(Order order)
        {
            //_itemRepository.AddRange(order.Items);
            _orderRepository.Add(order);
        }
    }
}
