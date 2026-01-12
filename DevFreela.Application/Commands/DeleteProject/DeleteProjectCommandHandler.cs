using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetProjectById(request.Id);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            project.SetAsDeleted();
            await _repository.UpdateProject(project);

            return ResultViewModel.Success();
        }
    }
}
