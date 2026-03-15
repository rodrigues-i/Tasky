using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(Guid userId);
        public Task CreateUser(User user);
        public Task UpdateUser(Guid userId, User user);
        public Task DeleteUser(Guid userId);
    }
}
