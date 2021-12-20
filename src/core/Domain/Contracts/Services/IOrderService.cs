using Domain.Entities;
using Domain.VO;

namespace Domain.Contracts.Services
{
    public interface IOrderService
    {
        void Insert(Order order);
        IEnumerable<Order> GetAll();
        Order GetById(string orderId);
        void Delete(string orderId);
        void Update(Order order);
        TotalOrder GetTotalOrder(string orderId);
    }
}
