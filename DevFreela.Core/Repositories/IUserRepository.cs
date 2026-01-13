using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserDetailsById(int id);
        Task<User?> GetUserById(int id);
        Task<int> CreateUser(User project);
        Task UpdateUser(User project);
        Task CreateUserSkill(List<UserSkill> userSkill);
        Task<bool> UserExists(int id);
    }
}
