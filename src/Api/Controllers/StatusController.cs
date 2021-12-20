using Domain.Contracts.Application;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusApplication _statusApplication;
        public StatusController(IStatusApplication statusApplication)
        {
            _statusApplication = statusApplication;
        }
        [HttpPost]
        public IActionResult Post([FromBody] StatusRequest request)
        {
            return Ok(_statusApplication.GetStatus(request));
        }
    }
}
