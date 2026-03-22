namespace Tasky.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User() { }

        public User(Guid id, string name, string email, string hash)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = hash;
        }

        public void UpdateUserDetails(User user)
        {
            Name = user.Name;
        }
    }
}
