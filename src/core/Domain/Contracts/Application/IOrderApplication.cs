using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Application
{
    public interface IOrderApplication
    {
        void InsertOrder(DTO.Order order);
        IEnumerable<DTO.Order> GetAllOrders();
    }
}
