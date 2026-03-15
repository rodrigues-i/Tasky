using Tasky.Application.Interfaces;
using Tasky.Domain.Interfaces;
using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task AddMember(Guid userId, Guid projectId)
        {
            var project = await GetProject(projectId);

            project.AddMember(userId);
            await _repository.AddMember();
        }

        public async Task AssignTaskToUser(Guid taskId, Guid userId, Guid projectId)
        {
            var project = await GetProject(projectId);
            project.AssignUserToTask(taskId, userId);
            await _repository.SaveChangesAsync();
        }

        public async Task CreateProject(Project project)
        {
            await _repository.CreateProject(project);
        }

        public async Task CreateTask(Guid projectId, Tasky.Domain.Entities.Task task)
        {
            var project = await GetProject(projectId);
            project.CreateTask(task);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProject(Guid projectId)
        {
            var existingProject = await GetProject(projectId);

            await _repository.DeleteProject(existingProject);
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

            await _repository.RemoveMember();
        }

        public Task UnassignUserFromTask(Guid taskId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProject(Guid projectId, Project project)
        {
            var existingProject = await _repository.GetProjectById(projectId);
            if (existingProject is null)
                throw new Exception("Project not found");

            existingProject.UpdateDetails(project.Name);
            await _repository.UpdateProject();
        }

        private async Task<Project> GetProject(Guid projectId)
        {
            var project = await _repository.GetProjectById(projectId);
            if (project is null)
                throw new Exception("Project not found");

            return project;
        }
    }
}
