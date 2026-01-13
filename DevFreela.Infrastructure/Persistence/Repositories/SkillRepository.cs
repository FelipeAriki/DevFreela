using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevfreelaDbContext _context;

        public SkillRepository(DevfreelaDbContext devfreelaDbContext)
        {
            _context = devfreelaDbContext;
        }

        public async Task<int> CreateSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }
    }
}
