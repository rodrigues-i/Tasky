using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(Guid userId);
        public Task CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(Guid userId);
    }
}
