using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        IEnumerable<Item> GetAllByOrder(string OrderId);
    }
}
