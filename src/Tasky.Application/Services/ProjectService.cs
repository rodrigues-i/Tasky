using Tasky.Application.Interfaces;
using Tasky.Domain.Interfaces;
using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;
using Tasky.Application.DTOs;

namespace Tasky.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            var projects = await _repository.GetAllAsync();
            return projects.Select(p => new ProjectDto(
                p.Id,
                p.Name,
                p.Tasks.Select(t => new TaskDto(
                    t.Id,
                    t.Title,
                    t.AssignedUserId
                 )).ToList()
            ));
        }

        public async Task AddMember(Guid userId, Guid projectId)
        {
            var project = await GetProject(projectId);

            project.AddMember(userId);
            await _repository.SaveChangesAsync();
        }

        public async Task AssignTaskToUser(Guid taskId, Guid userId, Guid projectId)
        {
            var project = await GetProject(projectId);
            project.AssignUserToTask(taskId, userId);
            await _repository.SaveChangesAsync();
        }

        public async Task CreateProject(string projectName)
        {
            var project = new Project(Guid.NewGuid(), projectName);
            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();
        }

        public async Task CreateTask(Guid projectId, string title)
        {
            var project = await GetProject(projectId);
            var task = project.CreateTask(title);
            _repository.AddTask(task);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProject(Guid projectId)
        {
            var existingProject = await GetProject(projectId);

            _repository.Remove(existingProject);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTask(Guid projectId, Guid taskId)
        {
            var project = await GetProject(projectId);
            project.RemoveTask(taskId);
            await _repository.SaveChangesAsync();
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            return await GetProject(projectId);

        }

        public async Task RemoveMember(Guid projectId, Guid userId)
        {
            var project = await GetProject(projectId);

            project.RemoveMember(userId);

            await _repository.SaveChangesAsync();
        }

        public async Task UnassignUserFromTask(Guid projectId, Guid taskId, Guid userId)
        {
            var project = await GetProject(projectId);
            project.UnAssignUserFromTask(taskId, userId);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateProject(Guid projectId, Project project)
        {
            var existingProject = await _repository.GetByIdAsync(projectId);
            if (existingProject is null)
                throw new Exception("Project not found");

            existingProject.UpdateDetails(project.Name);
            await _repository.SaveChangesAsync();
        }

        private async Task<Project> GetProject(Guid projectId)
        {
            var project = await _repository.GetByIdAsync(projectId);
            if (project is null)
                throw new Exception("Project not found");

            return project;
        }
    }
}
