using Domain.Contracts.Repositories;
using Domain.Entities;
using Infra.Provider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order,string>, IOrderRepository
    {
        private readonly ContextDb _context;
        public OrderRepository(ContextDb contextDb) : base(contextDb) {
            _context = contextDb;
        }

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
