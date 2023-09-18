using Labs.Api.Contracts.Request;
using Labs.Api.Contracts.Response;
using Labs.Application.DTOs;
using Labs.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Labs.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest personRequest)
        {
            var userDto = new UserDTO()
            {
                Name = personRequest.Name,
                Email = personRequest.Email,
                Password = personRequest.Password
            };

            var response = await UserService.Create(userDto);

            if (response.ValidationMessages.Any())
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, response.ValidationMessages);

            return Created(
                nameof(GetById), 
                new CreateUserResponse 
                { 
                    Id = response.Data 
                });
        }

        [HttpGet("{id}", Name = "[Action]")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await UserService.GetById(id);

            if (response.ValidationMessages.Any())
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, response.ValidationMessages);

            if (response.Data == null)
                return NotFound("Usuário não encontrado");

            return Ok(new UserByIdResponse()
            { 
                Name = response.Data.Name,
                Email = response.Data.Email
            });
        }
    }
}