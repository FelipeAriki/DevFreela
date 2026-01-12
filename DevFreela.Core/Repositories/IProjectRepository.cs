using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
        Task<Project?> GetProjectDetailsById(int id);
        Task<Project?> GetProjectById(int id);
        Task<int> CreateProject(Project project);
        Task UpdateProject(Project project);
        Task CreateProjectComment(ProjectComment projectComment);
        Task<bool> ProjectExists(int id);
    }
}
