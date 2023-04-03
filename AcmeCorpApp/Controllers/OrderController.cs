using AcmeCorp.Service.Model;
using AcmeCorp.Service.Service;
using AcmeCorp.Service.ViewModel;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly ILogger _logger;
        public OrderController(IOrderRepository OrderRepository, ILogger<OrderController> logger)
        {
            _OrderRepository = OrderRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            try
            {
                var result = await _OrderRepository.GetAllOrderAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Order : GetAllCategoriesAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // POST api/<OrderAPIController>
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderViewModel Order)
        {
            try
            {
                var result = await _OrderRepository.AddOrderAsync(Order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Order : AddOrderAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // GET api/<OrderAPIController>/5
        [HttpGet("{OrderId:int}")]
        public async Task<IActionResult> GetOrderByOrderIdAsync(int OrderId)
        {
            try
            {
                var result = await _OrderRepository.GetOrderByOrderIdAsync(OrderId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }

        // GET api/<CustomerAPIController>/5
        [HttpDelete("{orderId:long}")]
        public async Task<IActionResult> DeleteCustomerAsync(long orderId)
        {
            try
            {
                var result = await _OrderRepository.DeleteOrderAsync(orderId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }
    }
}
