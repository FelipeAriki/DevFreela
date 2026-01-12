using DevFreela.Application.Models;
using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectCommandHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevfreelaDbContext _context;
        private readonly IMediator _mediator;

        public InsertProjectCommandHandler(DevfreelaDbContext devfreelaDbContext, IMediator mediator)
        {
            _context = devfreelaDbContext;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            await _mediator.Publish(new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost));

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
