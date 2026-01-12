using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetProjects
{
    public class GetProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {
    }
}
