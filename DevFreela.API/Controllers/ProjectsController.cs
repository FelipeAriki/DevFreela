using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevfreelaDbContext _context;
        public ProjectsController(DevfreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProjects(string search = "", int page = 0, int size = 3)
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted && p.Title.Contains(search))
                .Skip(page * size)
                .Take(size)
                .ToList();

            return Ok(projects.Select(p => ProjectItemViewModel.FromEntity(p)).ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            return Ok(ProjectViewModel.FromEntity(project));
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectInputModel model)
        {
            var projects = model.ToEntity();

            _context.Projects.Add(projects);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProjectById), new { id = 1 }, model);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProject(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project != null)
            {
                project.Update(model.Title, model.Description, model.TotalCost);
                _context.Update(project);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null)
            {
                project.SetAsDeleted();
                _context.Update(project);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id:int}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null)
            {
                project.Start();
                _context.Update(project);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id:int}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project != null)
            {
                project.Complete();
                _context.Update(project);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("{id:int}/comments")]
        public IActionResult CreateProjectComments(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null) return NotFound();

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComments.Add(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}
