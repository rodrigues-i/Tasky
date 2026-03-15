using Tasky.Application.Interfaces;
using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return users;
        }

        public User GetUserById(Guid userId)
        {
            return GetUserById(userId);
        }

        public async Task CreateUser(User user)
        {
            await _repository.CreateUser(user);
        }

        public async System.Threading.Tasks.Task UpdateUser(Guid userId, User userUpdate)
        {
            var user = GetUserById(userId);
            user.UpdateUserDetails(user);
            await _repository.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            await _repository.DeleteUser(user);
        }

        private User GetUser(Guid userId)
        {
            var user = _repository.GetUserById(userId);
            if (user is null)
                throw new Exception("User not found");
            return user;
        }
    }
}
