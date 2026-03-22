using Tasky.Application.DTOs;
using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetProjectById(Guid projectId);
        Task CreateProject(string projectName);
        Task UpdateProject(Guid projectId, Project project);
        Task DeleteProject(Guid projectId);
        Task CreateTask(Guid projectId, string title);
        Task AddMember(Guid userId, Guid projectId);
        Task AssignTaskToUser(Guid taskId, Guid userId, Guid projectId);
        Task UnassignUserFromTask(Guid projectId, Guid taskId, Guid userId);
        Task DeleteTask(Guid projectId, Guid taskId);
        Task RemoveMember(Guid projectId, Guid userId);
        Task<IEnumerable<ProjectDto>> GetAllProjects();
    }
}
