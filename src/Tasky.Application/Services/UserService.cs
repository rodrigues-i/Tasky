using Tasky.Application.Interfaces;
using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;
using Tasky.Application.DTOs;

namespace Tasky.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _hasher;

        public UserService(IUserRepository repository, IPasswordHasher hasher)
        {
            _repository = repository;
            _hasher = hasher;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return users.Select(u => new UserDto
            (
                u.Name,
                u.Email
            ));
        }

        public User GetUserById(Guid userId)
        {
            return GetUserById(userId);
        }

        public async Task CreateUser(string name, string email, string password)
        {
            var (hash, salt) = _hasher.Hash(password);
            var user = new User(Guid.NewGuid(), name, email, hash, salt);
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
