using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;
namespace Tasky.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid userId);
        Task CreateUser(User user);
        Task UpdateUser(Guid userId, User user);
        Task DeleteUser(Guid userId);
    }
}
