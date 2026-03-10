using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;
using Project = Tasky.Domain.Entities.Project;

namespace Tasky.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project?> GetProjectById(Guid projectId)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Memberships)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task CreateProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public Task CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task AddMember(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task AssignUserToUser(Guid taskId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UnassignUserFromTask(Guid taskId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveMember(Guid userId, Project project)
        {
            project.RemoveMember(userId);
            await _context.SaveChangesAsync();
        }
    }
}
