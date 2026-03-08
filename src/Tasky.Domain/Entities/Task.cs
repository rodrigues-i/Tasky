namespace Tasky.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid? AssignedUserId { get; private set; }

        public Task(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public void AssignUser(Guid userId)
        {
            AssignedUserId = userId;
        }
    }
}
