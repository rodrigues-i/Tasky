using Tasky.Application.Interfaces;
using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;

namespace Tasky.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService
        )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async System.Threading.Tasks.Task Register(string name, string email, string password)
        {
            var existing = _userRepository.GetUserByEmail(email);
            if(existing is not null)
            {
                throw new Exception("Email already exists");
            }

            var (hash, salt) = _passwordHasher.Hash(password);
            var user = new User(Guid.NewGuid(), name, email, hash, salt, "User");

            await _userRepository.CreateUser(user);
        }

        public string Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user is null)
                throw new Exception("Invalid credentials");

            var valid = _passwordHasher.Verify(password, user.PasswordHash, user.PasswordSalt);
            if (!valid)
                throw new Exception("Invalid credentials");

            return _tokenService.CreateToken(user);
        }
    }
}
