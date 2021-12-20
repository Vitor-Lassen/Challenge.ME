using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class StatusRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("itensAprovados")]
        public int ItensApproved { get; set; }
        [JsonProperty("valorAprovado")]
        public int AmountApproved { get; set; }
        [JsonProperty("pedido")]
        public string OrderId { get; set; }
    }
}
