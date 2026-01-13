using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Skill.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, ResultViewModel<int>>
    {
        private readonly ISkillRepository _repository;

        public CreateSkillCommandHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var idSkillCreated = await _repository.CreateSkill(request.ToEntity());

            return ResultViewModel<int>.Success(idSkillCreated);
        }
    }
}
