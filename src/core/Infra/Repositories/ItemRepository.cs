using Domain.Contracts.Repositories;
using Domain.Entities;
using Infra.Provider;

namespace Infra.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ContextDb context) : base(context)
        {
            
        }

        public IEnumerable<Item> GetAllByOrder(string orderId)
        {
           return Find(s => s.OrderId == orderId).ToList();
        }
    }
}
