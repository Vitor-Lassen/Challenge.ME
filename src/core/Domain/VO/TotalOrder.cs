using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.VO
{
    public class TotalOrder
    {
        public string OrderID { get; private set;}
        public int Qtd { get; set; }
        public double Amount { get; set; }
        public TotalOrder(string orderId)
        {
            OrderID = orderId;
        }
    }
}
