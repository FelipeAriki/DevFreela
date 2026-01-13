using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Skill.GetSkills
{
    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, ResultViewModel<List<SkillViewModel>>>
    {
        private readonly ISkillRepository _repository;

        public GetSkillsQueryHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<SkillViewModel>>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetSkills();
            return ResultViewModel<List<SkillViewModel>>.Success(skills.Select(SkillViewModel.FromEntity).ToList());
        }
    }
}
