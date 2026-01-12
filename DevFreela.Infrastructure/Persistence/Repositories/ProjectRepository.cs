using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevfreelaDbContext _context;

        public ProjectRepository(DevfreelaDbContext devfreelaDbContext)
        {
            _context = devfreelaDbContext;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Project?> GetProjectById(int id)
        {
            return await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetProjectDetailsById(int id)
        {
            return await _context.Projects
                 .Include(p => p.Client)
                 .Include(p => p.Freelancer)
                 .Include(p => p.Comments)
                 .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> CreateProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }
        public async Task UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProjectComment(ProjectComment projectComment)
        {
            await _context.ProjectComments.AddAsync(projectComment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ProjectExists(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }
    }
}
