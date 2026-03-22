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

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Memberships)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Memberships)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void AddTask(Domain.Entities.Task task)
        {
            _context.Tasks.Add(task);
        }
    }
}
