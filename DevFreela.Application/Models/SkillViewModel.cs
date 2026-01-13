using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkillViewModel
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public SkillViewModel(int id, string description, DateTime createdAt, bool isDeleted)
        {
            Id = id;
            Description = description;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
        }

        public static SkillViewModel FromEntity(Skill skill) => new(skill.Id, skill.Description, skill.CreatedAt, skill.IsDeleted);
    }
}
