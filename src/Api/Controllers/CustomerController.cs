using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Interfaces.Services;
using Api.Models;
using Api.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [SwaggerResponse(200, Type = typeof(CustomerModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Post(CustomerInsertRequest request)
        {
            try
            {
                var result = await _customerService.InsertAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, Type = typeof(CustomerModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Put(Guid id, CustomerRequest request)
        {
            try
            {
                var result = await _customerService.UpdateAsync(id, request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _customerService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(IEnumerable<CustomerModel>))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] string cpfCnpj, [FromQuery] bool? active)
        {
            try
            {
                var result = await _customerService.GetAsync(x => 
                        (string.IsNullOrEmpty(name) || x.Name.Contains(name))
                        && (string.IsNullOrEmpty(cpfCnpj) || x.CpfCnpj == cpfCnpj)
                        && (!active.HasValue || x.Active == active)
                    );
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, Type = typeof(CustomerModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _customerService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}