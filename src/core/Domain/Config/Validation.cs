using Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Config
{
    public class Validation
    {
        public Expression<Func<TotalOrder, DTO.StatusRequest, bool>> Expression { get; set; }
        public string Status { get; set; }
    }
}