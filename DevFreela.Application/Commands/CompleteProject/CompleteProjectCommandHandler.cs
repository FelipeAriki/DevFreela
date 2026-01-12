using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CompleteProject
{
    public class CompleteProjectCommandHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public CompleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetProjectById(request.Id);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.Complete();
            await _repository.UpdateProject(project);

            return ResultViewModel.Success();
        }
    }
}
