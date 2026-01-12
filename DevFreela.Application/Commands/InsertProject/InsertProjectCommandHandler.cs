using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectCommandHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMediator _mediator;

        public InsertProjectCommandHandler(IProjectRepository projectRepository, IMediator mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();
            var idProject = await _projectRepository.CreateProject(project);

            await _mediator.Publish(new ProjectCreatedNotification(idProject, project.Title, project.TotalCost));

            return ResultViewModel<int>.Success(idProject);
        }
    }
}
