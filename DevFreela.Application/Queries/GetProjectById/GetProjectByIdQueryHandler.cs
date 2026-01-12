using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ResultViewModel<ProjectViewModel>>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<ProjectViewModel>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetProjectDetailsById(request.Id);

            if (project is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
            }

            var model = ProjectViewModel.FromEntity(project);

            return ResultViewModel<ProjectViewModel>.Success(model);
        }
    }
}
