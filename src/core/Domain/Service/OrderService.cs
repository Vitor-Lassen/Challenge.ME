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


        
    }
}
