using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UseCase.Commands;

namespace Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly GetOrdersByCustomer _command;

        public OrderController(ILogger<OrderController> logger, GetOrdersByCustomer command)
        {
            _logger = logger;
            _command = command;
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(Guid customerId)
        {
            var result = await _command.Execute(customerId);

            if (result.Error != null)
            {
                _logger.LogError(result.Error, "GetByCustomer {customerId}", customerId);
                return StatusCode(500, new { Message = result.Error.Message });
            }

            return Ok(result.Data);
        }
    }
}
