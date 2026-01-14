using DevFreela.Application.Commands.Skill.CreateSkill;
using DevFreela.Application.Queries.Skill.GetSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var result = await _mediator.Send(new GetSkillsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(CreateSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
