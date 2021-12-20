using Newtonsoft.Json;

namespace Domain.DTO
{
    public class Item
    {
        public virtual string Id { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("precoUnitario")]
        public double UnitPrice { get; set; }
        [JsonProperty("qtd")]
        public int Qtd { get; set; }
        public Item()
        {
            
        }
        public Item(Entities.Item item)
        {
            Id = item.Id;
            Description = item.Description;
            UnitPrice = item.UnitPrice; 
            Qtd = item.Qtd;
        }
    }
}
