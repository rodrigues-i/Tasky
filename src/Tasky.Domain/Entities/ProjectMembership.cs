using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Domain.projects
{
    public class ProjectMembership
    {
        public Guid UserId { get; private set; }

        public ProjectMembership(Guid userId)
        {
            UserId = userId;
        }
    }
}
