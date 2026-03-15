using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;
namespace Tasky.Domain.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User? GetUserById(Guid userId);
        public Task CreateUser(User user);
        public Task DeleteUser(User user);
        public Task SaveChangesAsync();
    }
}
