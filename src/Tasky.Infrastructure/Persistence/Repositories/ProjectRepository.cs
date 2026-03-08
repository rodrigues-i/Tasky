using Tasky.Domain.Interfaces;
using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

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
    }
}
