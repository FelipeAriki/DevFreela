using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public InsertCommentCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var projectExists = await _repository.ProjectExists(request.IdProject);

            if (!projectExists)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }

            await _repository.CreateProjectComment(new ProjectComment(request.Content, request.IdProject, request.IdUser));

            return ResultViewModel.Success();
        }
    }
}
