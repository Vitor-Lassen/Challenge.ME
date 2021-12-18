using Domain.Contracts.Repositories;
using Domain.Entities;
using Infra.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ContextDb contextDb) : base(contextDb) {}
    }
}
