using System;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse(200, Type = typeof(UserModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Post(UserRequest request)
        {
            try
            {
                var result = await _userService.InsertAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, Type = typeof(UserModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> Put(Guid id, UserRequest request)
        {
            try
            {
                var result = await _userService.UpdateAsync(id, request);
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
                var result = await _userService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, Type = typeof(UserModel))]
        [SwaggerResponse(400, Type = typeof(string))]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _userService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}