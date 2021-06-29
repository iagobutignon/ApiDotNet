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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        [SwaggerResponse(200, Type = typeof(AddressModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Post(AddressRequest request)
        {
            try
            {
                var result = await _addressService.InsertAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, Type = typeof(AddressModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Put(Guid id, AddressRequest request)
        {
            try
            {
                var result = await _addressService.UpdateAsync(id, request);
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
                var result = await _addressService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(IEnumerable<AddressModel>))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Get([FromQuery] Guid? customerId, [FromQuery] string cep,
            [FromQuery] string address, [FromQuery] string district, [FromQuery] string city, [FromQuery] string state)
        {
            try
            {
                var result = await _addressService.GetAsync(a =>
                    (!customerId.HasValue || a.CustomerId == customerId)
                    && (string.IsNullOrEmpty(cep) || a.Cep == cep)
                    && (string.IsNullOrEmpty(address) || a.Address.Contains(address))
                    && (string.IsNullOrEmpty(district) || a.Address.Contains(district))
                    && (string.IsNullOrEmpty(city) || a.Address.Contains(city))
                    && (string.IsNullOrEmpty(state) || a.State == state)
                );

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, Type = typeof(AddressModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _addressService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}