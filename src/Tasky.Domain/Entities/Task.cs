namespace Tasky.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid? AssignedUserId { get; private set; }
        public Guid ProjectId { get; private set; }
        public Project? Project { get; private set; }

        public Task(Guid id, string title, Guid projectId)
        {
            Id = id;
            Title = title;
            ProjectId = projectId;
        }

        public void AssignUser(Guid userId)
        {
            AssignedUserId = userId;
        }

        public void UnassignUser()
        {
            AssignedUserId = null;
        }
    }
}
