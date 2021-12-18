using Newtonsoft.Json;

namespace Domain.DTO
{
    public class Order
    {
        [JsonProperty("pedido")]
        public string Id { get; set; }
        public Order()
        {

        }
        public Order(Entities.Order order)
        {
            Id = order.Id;      
        }
    }
}
