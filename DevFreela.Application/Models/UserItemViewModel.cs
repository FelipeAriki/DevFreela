using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class UserItemViewModel
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public UserItemViewModel(int id, string fullName, string email, DateTime birthDate, bool active, DateTime createdAt, bool isDeleted)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
        }

        public static UserItemViewModel FromEntity(User user)
        {
            return new UserItemViewModel(user.Id, user.FullName, user.Email, user.BirthDate, user.Active, user.CreatedAt, user.IsDeleted);
        }
    }
}
