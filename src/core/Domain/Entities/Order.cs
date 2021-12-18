using Domain.VO;

namespace Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public Order()
        {

        }
        public Order(DTO.Order order)
        {
            Id = order.Id;
        }
    }
}
