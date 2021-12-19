using Domain.Entities;

namespace Domain.Contracts.Services
{
    public interface IOrderService
    {
        void Insert(Order order);
        IEnumerable<Order> GetAll();
    }
}
