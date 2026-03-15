using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User? GetUserById(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return user;
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await SaveChangesAsync();
            
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await SaveChangesAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
