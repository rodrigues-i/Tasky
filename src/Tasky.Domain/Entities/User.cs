namespace Tasky.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public User(Guid userId, string name)
        {
            Id = userId;
            Name = name;
        }
    }
}
