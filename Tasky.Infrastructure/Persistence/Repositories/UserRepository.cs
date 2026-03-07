using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(Guid userId, User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
