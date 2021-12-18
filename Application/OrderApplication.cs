using Domain.Contracts.Application;
using Domain.Contracts.Repositories;
using DTO = Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository; 
        public OrderApplication(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository; 
        }

        public IEnumerable<DTO.Order> GetAllOrders()
        {
            var result = _orderRepository.GetAll();
            return result.Select(x => new DTO.Order(x));
        }

        public void InsertOrder(DTO.Order order)
        {
            _orderRepository.Add(new Order(order));
        }
    }
}
