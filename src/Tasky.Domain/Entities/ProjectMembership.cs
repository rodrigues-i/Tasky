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
