namespace Tasky.Domain.Entities
{
    public class Project
    {
        private readonly List<Task> _tasks = new List<Task>();
        private readonly List<ProjectMembership> _memberships = new List<ProjectMembership>();

        public IReadOnlyCollection<Task> Tasks => _tasks;
        public IReadOnlyCollection<ProjectMembership> Memberships => _memberships;

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Project(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddMember(Guid userId)
        {
            if (_memberships.Any(m => m.UserId == userId))
                throw new Exception("User already member");

            _memberships.Add(new ProjectMembership(Id, userId));
        }

        public Task CreateTask(string title)
        {
            var task = new Task(Guid.NewGuid(), title, Id);
            _tasks.Add(task);
            return task;
        }

        public void AssignUserToTask(Guid taskId, Guid userId)
        {
            if (!_memberships.Any(m => m.UserId == userId))
                throw new Exception("User is not a project member");
            var task = _tasks.First(task => task.Id == taskId);
            task.AssignUser(userId);
        }

        public void UpdateDetails(string name)
        {
            Name = name;
        }

        public void RemoveMember(Guid userId)
        {
            var member = _memberships.FirstOrDefault(m => m.UserId == userId);
            if (member is null)
                throw new Exception("User is not a member of this project");

            _memberships.Remove(member);
        }

        public void RemoveTask(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is null)
                throw new Exception("Task not found");
            _tasks.Remove(task);
        }

        public void UnAssignUserFromTask(Guid taskId, Guid userId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is null)
                throw new Exception("Task not found");
            task.UnassignUser();
        }
    }
}
