using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertProject
{
    public class ValidateInsertProjectCommandBehavior : IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevfreelaDbContext _context;

        public ValidateInsertProjectCommandBehavior(DevfreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientExists = await _context.Users.AnyAsync(u => u.Id == request.IdClient);
            var freenlancerExists = await _context.Users.AnyAsync(u => u.Id == request.IdFreelancer);

            if (!clientExists || !freenlancerExists) return ResultViewModel<int>.Error("Cliente ou Freelancer inválidos.");


            return await next();
        }
    }
}
