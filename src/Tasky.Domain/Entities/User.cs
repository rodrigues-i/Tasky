namespace Tasky.Domain.Entities
{
    public class User : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public string Role { get; private set; } = "User";

        public User() { }

        public User(Guid id, string name, string email, byte[] hash, byte[] salt, string role = "User")
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = hash;
            PasswordSalt = salt;
            Role = role;
        }

        public void UpdateUserDetails(User user)
        {
            Name = user.Name;
        }
    }
}
