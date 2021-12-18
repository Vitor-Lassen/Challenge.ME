using Newtonsoft.Json;

namespace Domain.DTO
{
    public class Item
    {
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("precoUnitario")]
        public double UnitPrice { get; set; }
        [JsonProperty("qtd")]
        public int Amount { get; set; }
        public Item()
        {
            
        }
        public Item(Entities.Item item)
        {
            Description = item.Description;
            UnitPrice = item.UnitPrice; 
            Amount = item.Amount;
        }
    }
}
