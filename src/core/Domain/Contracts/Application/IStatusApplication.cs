using Domain.DTO;

namespace Domain.Contracts.Application
{
    public interface IStatusApplication
    {
        StatusResponse GetStatus(StatusRequest statusRequest);
    }
}
