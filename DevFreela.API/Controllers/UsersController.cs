using DevFreela.Application.Commands.User.CreateUser;
using DevFreela.Application.Commands.User.CreateUserSkill;
using DevFreela.Application.Commands.User.DeleteUser;
using DevFreela.Application.Commands.User.UpdateUser;
using DevFreela.Application.Models;
using DevFreela.Application.Queries.User.GetUserById;
using DevFreela.Application.Queries.User.GetUsers;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("{id:int}/skills")]
        public async Task<IActionResult> CreateUserSkill(CreateUserSkillCommand command)
        {
            var userSkills = await _mediator.Send(command);
            return Ok(userSkills);
        }

        [HttpPut("{id:int}/profile-picture")]
        public IActionResult PostProfilePicture(int id, IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";
            return Ok(description);
        }
    }
}
