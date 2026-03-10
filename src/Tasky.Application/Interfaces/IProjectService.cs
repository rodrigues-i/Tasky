using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetProjectById(Guid projectId);
        Task CreateProject(Project project);
        Task UpdateProject(Guid projectId, Project project);
        Task DeleteProject(Guid projectId);
        Task CreateTask(Task task);
        Task AddMember(Guid userId);
        Task AssignUserToUser(Guid taskId, Guid userId);
        Task UnassignUserFromTask(Guid taskId, Guid userId);
        Task DeleteTask(Guid taskId);
        Task RemoveMember(Guid projectId, Guid userId);
    }
}
