using Newtonsoft.Json;

namespace Domain.DTO
{
    public class Order
    {
        [JsonProperty("pedido")]
        public string Id { get; set; }
        [JsonProperty("itens")]
        public IEnumerable<Item> Items { get; set; }
        public Order()
        {

        }
        public Order(Entities.Order order)
        {
            Id = order.Id;
            Items = order.Items.Select(x => new Item(x));
        }
    }
}
