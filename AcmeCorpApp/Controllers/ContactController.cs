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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _ContactRepository;
        private readonly ILogger _logger;
        public ContactController(IContactRepository ContactRepository, ILogger<ContactController> logger)
        {
            _ContactRepository = ContactRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContactAsync()
        {
            try
            {
                var result = await _ContactRepository.GetAllContactAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Contact : GetAllCategoriesAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // POST api/<ContactAPIController>
        [HttpPost]
        public async Task<IActionResult> AddContactAsync(Contact Contact)
        {
            try
            {
                var result = await _ContactRepository.AddContactAsync(Contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error with Contact : AddContactAsync" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the server");
            }
        }
        // GET api/<ContactAPIController>/5
        [HttpGet("{ContactId:int}")]
        public async Task<IActionResult> GetContactByContactIdAsync(int ContactId)
        {
            try
            {
                var result = await _ContactRepository.GetContactByContactIdAsync(ContactId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data  from the server");
            }
        }


    }
}
