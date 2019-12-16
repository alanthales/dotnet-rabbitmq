using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.Entities;
using UseCase.Commands;

namespace Bartender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly GetAllCustomers _getAllCustomers;
        private readonly GetCustomerById _getCustomerById;
        private readonly CreateCustomer _createCustomer;

        public CustomerController(
            ILogger<CustomerController> logger,
            GetAllCustomers getAllCustomers,
            GetCustomerById getCustomerById,
            CreateCustomer createCustomer
        )
        {
            _logger = logger;
            _getAllCustomers = getAllCustomers;
            _getCustomerById = getCustomerById;
            _createCustomer = createCustomer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getAllCustomers.Execute();

            if (result.Error != null)
            {
                _logger.LogError(result.Error, "Get");
                return StatusCode(500, result.Error);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _getCustomerById.Execute(id);

            if (result.Error != null)
            {
                _logger.LogError(result.Error, "Get {id}", id);
                return StatusCode(500, result.Error);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            var result = await _createCustomer.Execute(customer);

            if (result.Error != null)
            {
                _logger.LogError(result.Error, "Post {0}", customer.Id);
                return StatusCode(500, result.Error);
            }

            return CreatedAtAction("Get", new { id = customer.Id }, result.Data);
        }
    }
}
