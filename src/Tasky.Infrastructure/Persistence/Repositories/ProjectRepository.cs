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
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public Task CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProject(Guid projectId)
        {
            throw new NotImplementedException();
        }
    }
}
