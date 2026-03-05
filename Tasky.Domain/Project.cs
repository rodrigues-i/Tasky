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
    }
}
