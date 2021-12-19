namespace Domain.Contracts.Application
{
    public interface IOrderApplication
    {
        void Insert(DTO.Order order);
        IEnumerable<DTO.Order> GetAll();
        DTO.Order GetbyId(string orderId);
        void Update(DTO.Order order);
        void Delete(string orderId);
    }
}
