using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services
{
    public interface IProjectService
    {
        ResultViewModel<List<ProjectItemViewModel>> GetProjects(string search = "");
        ResultViewModel<ProjectViewModel> GetProjectById(int id);
        ResultViewModel<int> CreateProject(CreateProjectInputModel model);
        ResultViewModel UpdateProject(UpdateProjectInputModel model);
        ResultViewModel DeleteProject(int id);
        ResultViewModel StartProject(int id);
        ResultViewModel CompleteProject(int id);
        ResultViewModel CreateProjectComments(int id, CreateProjectCommentInputModel model);
    }
}
