using Tasky.Domain.projects;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetProjectById(Guid projectId);
        Task CreateProject(Project project);
        Task UpdateProject(Guid projectId, Project project);
        Task DeleteProject(Guid projectId);
    }
}
