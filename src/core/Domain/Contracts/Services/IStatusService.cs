using Domain.DTO;
using Domain.VO;

namespace Domain.Contracts.Services
{
    public interface IStatusService
    {
        List<string> Validate(TotalOrder totalOrder, StatusRequest statusRequest);
    }
}
