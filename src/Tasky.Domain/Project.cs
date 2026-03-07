using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Domain
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

            _memberships.Add(new ProjectMembership(userId));
        }

        public void CreateTask(Guid taskId, string title)
        {
            _tasks.Add(new Task(taskId, title));
        }

        public void AssignUserToTask(Guid taskId, Guid userId)
        {
            if (!_memberships.Any(m => m.UserId == userId))
                throw new Exception("User is not a project member");
            var task = _tasks.First(task => task.Id == taskId);
            task.AssignUser(userId);
        }
    }
}
