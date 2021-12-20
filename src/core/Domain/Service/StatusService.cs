using Domain.Config;
using Domain.Contracts.Services;
using Domain.DTO;
using Domain.VO;

namespace Domain.Service
{
    public class StatusService  :IStatusService
    {
        private readonly IList<Validation> _validationsConfigs;
        public StatusService()
        {
            _validationsConfigs = ValidationsConfig.GetValidations();
        }
        public List<string> Validate (TotalOrder totalOrder, StatusRequest statusRequest)
        {
            var status = new List<string>();
            foreach(var validation in _validationsConfigs)
            {
                var exp = validation.Expression.Compile();
                if (exp(totalOrder,statusRequest))
                {
                    status.Add(validation.Status);
                }
            }
            return status;
        }
    }
}
