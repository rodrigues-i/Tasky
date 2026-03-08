using System.Linq.Expressions;
using Tasky.Application.Interfaces;
using Tasky.Domain.Interfaces;
using Tasky.Domain.projects;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Application.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProject(Project project)
        {
            await _repository.CreateProject(project);
        }

        public async Task DeleteProject(Guid projectId)
        {
            var existingProject = await _repository.GetProjectById(projectId);
            if (existingProject is null)
                throw new Exception("Project not found");

            await _repository.DeleteProject(projectId);
        }

        public async Task<Project> GetProjectById(Guid projectId)
        {
            var project = await _repository.GetProjectById(projectId);
            if (project is null)
                throw new Exception("Project not found");
            return project;

        }

        public async Task UpdateProject(Guid projectId, Project project)
        {
            var existingProject = await _repository.GetProjectById(projectId);
            if (existingProject is null)
                throw new Exception("Project not found");

            existingProject.UpdateDetails(project.Name);
            await _repository.UpdateProject(existingProject);
        }
    }
}
