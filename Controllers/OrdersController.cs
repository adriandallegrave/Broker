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
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IBus bus, ILogger<OrdersController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            var orderEvent = new OrderCreatedEvent { OrderId = 1 };
            await _bus.Publish(orderEvent);
            return Ok("Order published");
        }
    }
}
