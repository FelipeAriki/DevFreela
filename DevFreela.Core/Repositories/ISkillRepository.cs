using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetSkills();
        Task<int> CreateSkill(Skill skill);
    }
}
