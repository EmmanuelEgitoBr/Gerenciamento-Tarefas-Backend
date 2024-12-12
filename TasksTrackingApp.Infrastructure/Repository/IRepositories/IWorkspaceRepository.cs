using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Infrastructure.Repository.IRepositories
{
    public interface IWorkspaceRepository : IBaseRepository<Workspace>
    {
        Task<List<Workspace>> GetAllWorkspacesByUserIdAsync(Guid userId);
    }
}
