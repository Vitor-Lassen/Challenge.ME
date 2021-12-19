namespace Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public Order()
        {

        }
        public Order(DTO.Order order)
        {
            Id = order.Id;
            Items = order.Items.Select(x => new Item(x)).ToList();
        }
    }
}
