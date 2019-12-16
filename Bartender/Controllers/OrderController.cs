using Core.Constants;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Gateway.RabbitMQ;

namespace Bartender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly Publisher _broker;

        public OrderController(ILogger<OrderController> logger, Publisher broker)
        {
            _logger = logger;
            _broker = broker;
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            try
            {
                _broker.Publish(BrokerEvents.ORDER, order);
                return Created(String.Format("/orders/{0}", order.Id), order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Post {0}", order.Id.ToString());
                return StatusCode(500, ex);
            }
        }
    }
}