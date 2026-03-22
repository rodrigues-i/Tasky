using Tasky.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasky.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid id);
        Task AddAsync(Project project);
        void Remove(Project project);
        Task SaveChangesAsync();
        void AddTask(Entities.Task task);
    }
}
