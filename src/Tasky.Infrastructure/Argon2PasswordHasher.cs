using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;
using Tasky.Application.Interfaces;

namespace Tasky.Infrastructure
{
    public class Argon2PasswordHasher : IPasswordHasher
    {
        public (byte[] hash, byte[] salt) Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 2,
                MemorySize = 65536,
                Iterations = 4
            };

            var hash = argon2.GetBytes(32);
            return (hash, salt);
        }

        public bool Verify(string password, byte[] hash, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 2,
                MemorySize = 65536,
                Iterations = 4
            };

            var computedHash = argon2.GetBytes(32);
            return CryptographicOperations.FixedTimeEquals(hash, computedHash);
        }
    }
}
