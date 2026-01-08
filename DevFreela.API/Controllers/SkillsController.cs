using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevfreelaDbContext _context;
        public SkillsController(DevfreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSkills()
        {
            var skills = _context.Skills.ToList();
            return Ok(skills);
        }

        [HttpPost]
        public IActionResult CreateSkill(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
