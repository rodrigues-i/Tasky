using Tasky.Domain.Interfaces;
using Tasky.Domain.projects;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Task<Project> GetProjectById(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public Task CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProject(Guid projectId, Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProject(Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
