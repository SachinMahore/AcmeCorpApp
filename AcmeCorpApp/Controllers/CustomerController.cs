using AcmeCorp.Service.Model;
using AcmeCorp.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;
        public CustomerController(ICustomerRepository customerRepository, ILogger<CustomerController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            try
            {
                var result = await _customerRepository.GetAllCustomerAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Customer : GetAllCategoriesAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // POST api/<CustomerAPIController>
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(Customer customer)
        {
            try
            {
                var result = await _customerRepository.AddCustomerAsync(customer);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Customer : AddCustomerAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // GET api/<CustomerAPIController>/5
        [HttpGet("{CustomerId:int}")]
        public async Task<IActionResult> GetCustomerByCustomerIdAsync(int customerId)
        {
            try
            {
                var result = await _customerRepository.GetCustomerByCustomerIdAsync(customerId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }
        // GET api/<CustomerAPIController>/5
        [HttpDelete("{customerId:int}")]
        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                var result = await _customerRepository.DeleteCustomerAsync(customerId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }

    }
}
