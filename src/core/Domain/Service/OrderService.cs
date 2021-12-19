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

        public void Delete(string orderId)
        {
            _orderRepository.Remove(GetById(orderId));
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _orderRepository.GetAll();
            foreach (var order in orders)
            {
                FillOrder(order);
            }
            return orders;
        }

        public Order GetById(string orderId)
        {
            var order = _orderRepository.GetById(orderId);
            return order != null ? FillOrder(order): order;
        }

        public void Insert(Order order)
        {

            _orderRepository.Add(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);

            //var oldItems = _itemRepository.GetAllByOrder(order.Id);
            //foreach (var item in order.Items)
            //{
            //    var oldItem = oldItems.Where(s => s.Id == item.Id).FirstOrDefault();
            //    if (oldItem != null)
            //    {
            //        if (!item.Equals(oldItem))
            //            _itemRepository.Update(item);
            //    }
            //    else
            //        _itemRepository.Add(item);
            //}
            //var newItems = order.Items.Except(oldItems);
            //foreach (var item in newItems)
            //    _itemRepository.Remove(item);
        }

        private Order FillOrder(Order order)
        {
            order.Items = _itemRepository.GetAllByOrder(order.Id);

            return order;
        }
        
    }
}
