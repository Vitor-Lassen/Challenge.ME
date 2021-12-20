using Domain.Contracts.Application;
using Domain.Contracts.Services;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class StatusApplication : IStatusApplication
    {
        private readonly IStatusService _statusService;
        private readonly IOrderService _orderService;

        public StatusApplication(IOrderService orderService, IStatusService statusService)
        {
            _statusService = statusService;
            _orderService = orderService;
        }

        public StatusResponse GetStatus (StatusRequest statusRequest)
        {
            var totalOrder = _orderService.GetTotalOrder(statusRequest.OrderId);
            if (totalOrder == null)
                return new StatusResponse(statusRequest.OrderId, new List<string>() { "CODIGO_PEDIDO_INVALIDO" });
            return new StatusResponse(statusRequest.OrderId, _statusService.Validate(totalOrder, statusRequest));

        }

    }
}
