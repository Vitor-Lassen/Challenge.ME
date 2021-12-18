using Domain.Contracts.Application;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IOrderApplication _orderApplication;
        public PedidoController(IOrderApplication orderApplication)
        {
            _orderApplication = orderApplication;
        }
        // GET: api/<PedidoController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderApplication.GetAllOrders();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderApplication.InsertOrder(order);
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
