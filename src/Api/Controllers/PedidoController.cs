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
        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _orderApplication.GetAll();
        }

        [HttpGet("{orderId}")]
        public Order Get(string orderId)
        {
            return _orderApplication.GetbyId(orderId);
        }

        [HttpPost]
        public void Post([FromBody] Order order)
        {
                _orderApplication.Insert(order);
        }

        // PUT api/<PedidoController>/5
        [HttpPut]
        public void Put([FromBody] Order order)
        {
             _orderApplication.Update(order);
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{orderId}")]
        public void Delete(string orderId)
        {
            _orderApplication.Delete(orderId);
        }
    }
}
