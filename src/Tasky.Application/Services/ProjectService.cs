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

        public Task AddMember(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task AssignUserToUser(Guid taskId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProject(Project project)
        {
            await _repository.CreateProject(project);
        }

        public Task CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProject(Guid projectId)
        {
            var existingProject = await _repository.GetProjectById(projectId);
            if (existingProject is null)
                throw new Exception("Project not found");

            await _repository.DeleteProject(existingProject);
        }

        public Task DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            var project = await _repository.GetProjectById(projectId);
            if (project is null)
                throw new Exception("Project not found");
            return project;

        }

        public async Task RemoveMember(Guid projectId, Guid userId)
        {
            var project = await _repository.GetProjectById(projectId);
            if (project is null)
                throw new Exception("Project not found");

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
    }
}
