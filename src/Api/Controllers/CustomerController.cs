using System;
using System.Threading.Tasks;
using Api.Interfaces.Services;
using Api.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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