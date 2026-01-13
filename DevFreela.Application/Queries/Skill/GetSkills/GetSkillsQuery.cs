using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.Skill.GetSkills
{
    public class GetSkillsQuery : IRequest<ResultViewModel<List<SkillViewModel>>>
    {
    }
}
