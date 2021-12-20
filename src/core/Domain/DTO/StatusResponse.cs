using Newtonsoft.Json;
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
        [JsonProperty("pedido")]
        public string OrderId { get; set; }
        public StatusResponse(string orderId, IList<string> status)
        {
            OrderId = orderId;
            Status = status;
        }
    }
}
