using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IItemRepository : IBaseRepository<Item,string>
    {
        IEnumerable<Item> GetAllByOrder(string OrderId);
    }
}
