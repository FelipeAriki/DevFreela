using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetProjects();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }
    }
}
