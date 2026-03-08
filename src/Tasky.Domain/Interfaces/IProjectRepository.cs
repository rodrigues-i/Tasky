using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetProjectById(Guid projectId);
        Task CreateProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(Guid projectId);
    }
}
