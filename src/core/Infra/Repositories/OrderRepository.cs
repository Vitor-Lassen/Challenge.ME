using Domain.Contracts.Repositories;
using Domain.Entities;
using Infra.Provider;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order,string>, IOrderRepository
    {
        public OrderRepository(ContextDb contextDb) : base(contextDb) {}

        public override IEnumerable<Order> GetAll()
        {
            return base.Query().Include(x => x.Items).ToList();
        }
        public override Order GetById(string id)
        {
            return base.Query().Include(x => x.Items).FirstOrDefault(x => x.Id == id);
        }

    }
}
