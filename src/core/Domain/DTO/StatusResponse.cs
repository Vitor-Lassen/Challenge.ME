using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class StatusResponse
    {
        public IList<string> Status { get; set; }
        public StatusResponse(IList<string> status)
        {
            Status = status;
        }
    }
}
