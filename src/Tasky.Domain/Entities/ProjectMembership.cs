using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasky.Domain.Entities
{
    public class ProjectMembership
    {
        public Guid ProjectId { get; private set; }
        public Guid UserId { get; private set; }

        public ProjectMembership(Guid projectId, Guid userId)
        {
            ProjectId = projectId;
            UserId = userId;
        }
    }
}
