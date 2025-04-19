using Broker.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Broker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IBus _bus;

        public OrdersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var order = new OrderCreatedEvent();

            Console.WriteLine($"Process state: [Controller] - Id: [{order.Id}]");

            await _bus.Publish(order);

            return Ok($"Order created. Id: [{order.Id}]");
        }

        [HttpPost("SimulateResponse")]
        public async Task<IActionResult> SimulateResponse([FromBody] ResponseEvent responseEvent)
        {
            await _bus.Publish(responseEvent);
            return Ok("Response event published");
        }
    }
}
