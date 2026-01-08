using DevFreela.Application.Models;
using DevFreela.Application.Services;
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
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetProjects(string search = "", int page = 0, int size = 3)
        {
            var result = _projectService.GetProjects();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProjectById(int id)
        {
            var result = _projectService.GetProjectById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectInputModel model)
        {
            var result = _projectService.CreateProject(model);

            return CreatedAtAction(nameof(GetProjectById), new { id = result.Data }, model);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProject(int id, UpdateProjectInputModel model)
        {
            var result = _projectService.UpdateProject(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            var result = _projectService.DeleteProject(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id:int}/start")]
        public IActionResult StartProject(int id)
        {
            var result = _projectService.StartProject(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id:int}/complete")]
        public IActionResult CompleteProject(int id)
        {
            var result = _projectService.CompleteProject(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id:int}/comments")]
        public IActionResult CreateProjectComments(int id, CreateProjectCommentInputModel model)
        {
            var result = _projectService.CreateProjectComments(id, model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
