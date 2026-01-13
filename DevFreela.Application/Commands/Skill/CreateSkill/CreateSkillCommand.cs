using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Skill.CreateSkill
{
    public class CreateSkillCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; }

        public Core.Entities.Skill ToEntity() => new(Description);
    }
}
