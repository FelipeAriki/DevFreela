using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevfreelaDbContext _context;

        public UserRepository(DevfreelaDbContext devfreelaDbContext)
        {
            _context = devfreelaDbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailPassword(string email, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserDetailsById(int id)
        {
            return await _context.Users
                .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserSkill(List<UserSkill> userSkill)
        {
            await _context.UserSkills.AddRangeAsync(userSkill);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(p => p.Id == id);
        }
    }
}
